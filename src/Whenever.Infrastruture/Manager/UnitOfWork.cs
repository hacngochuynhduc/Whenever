using System.Data;
using System.Text.RegularExpressions;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Whenever.Infrastruture.Extension;
using Whenver.Base.Helpers;
using Whenver.Base.Models;

namespace Whenever.Infrastruture.Manager;

public class UnitOfWork<TContext> : IRepositoryExtension, IUnitOfWork<TContext>, IUnitOfWork where TContext : DbContext
{
    private readonly ApplicationUser _currentUser;
    private bool _disposed;
    private Dictionary<Type, object>? _repositories;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOfWork{TContext}" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public UnitOfWork(TContext context, IHttpContextAccessor httpContextAccessor)
    {
        _currentUser = new ApplicationUser(httpContextAccessor.HttpContext);
        DbContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    ///     GetRepository
    /// </summary>
    /// <param name="hasCustomRepository"></param>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>(bool hasCustomRepository = false)
        where TEntity : class
    {
        if (_repositories == null) _repositories = new Dictionary<Type, object>();

        // what's the best way to support custom reposity?
        if (hasCustomRepository)
        {
            var customRepo = DbContext.GetService<IRepository<TEntity, TKey>>();
            return customRepo;
        }

        var type = typeof(TEntity);
        if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity, TKey>(DbContext);

        return (IRepository<TEntity, TKey>)_repositories[type];
    }

    /// <summary>
    ///     Gets the db context.
    /// </summary>
    /// <returns>The instance of type <typeparamref name="TContext" />.</returns>
    public TContext DbContext { get; }

    /// <summary>
    ///     Changes the database name. This require the databases in the same machine. NOTE: This only work for MySQL right
    ///     now.
    /// </summary>
    /// <param name="database">The database name.</param>
    /// <remarks>
    ///     This only been used for supporting multiple databases in the same model. This require the databases in the same
    ///     machine.
    /// </remarks>
    public void ChangeDatabase(string database)
    {
        var connection = DbContext.Database.GetDbConnection();
        if (connection.State.HasFlag(ConnectionState.Open))
        {
            connection.ChangeDatabase(database);
        }
        else
        {
            var connectionString = Regex.Replace(connection.ConnectionString.Replace(" ", ""),
                @"(?<=[Dd]atabase=)\w+(?=;)", database, RegexOptions.Singleline);
            connection.ConnectionString = connectionString;
        }

        // Following code only working for mysql.
        var items = DbContext.Model.GetEntityTypes();
        foreach (var item in items)
            if (item is IConventionEntityType entityType)
                entityType.SetSchema(database);
    }


    /// <summary>
    ///     Executes the specified raw SQL command.
    /// </summary>
    /// <param name="sql">The raw SQL.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns>The number of state entities written to database.</returns>
    public int ExecuteSqlCommand(string sql, params object[] parameters)
    {
        return DbContext.Database.ExecuteSqlRaw(sql, parameters);
    }

    /// <summary>
    ///     Uses raw SQL queries to fetch the specified <typeparamref name="TEntity" /> data.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="sql">The raw SQL.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns>An <see cref="IQueryable{T}" /> that contains elements that satisfy the condition specified by raw SQL.</returns>
    public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class
    {
        return DbContext.Set<TEntity>().FromSqlRaw(sql, parameters);
    }

    /// <summary>
    ///     Saves all changes made in this context to the database.
    /// </summary>
    /// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
    /// <returns>The number of state entries written to the database.</returns>
    public int SaveChanges(bool ensureAutoHistory = false)
    {
        if (ensureAutoHistory) DbContext.EnsureAutoHistory();

        return DbContext.SaveChanges();
    }

    /// <summary>
    ///     Asynchronously saves all changes made in this unit of work to the database.
    /// </summary>
    /// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
    /// <returns>
    ///     A <see cref="Task{TResult}" /> that represents the asynchronous save operation. The task result contains the
    ///     number of state entities written to database.
    /// </returns>
    public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
    {
        if (ensureAutoHistory) DbContext.EnsureAutoHistory();

        DbContext.ChangeTracker.DetectChanges();
        var entitiesTrack = DbContext.ChangeTracker.Entries<BaseEntity<Guid>>()
            .Where(s => s.State == EntityState.Modified);
        foreach (var e in entitiesTrack)
        {
            e.Entity.UpdatedDate = DateTime.UtcNow;
            if (_currentUser.UserId != default)
                e.Entity.UpdateBy = _currentUser.UserId;
        }

        return await DbContext.SaveChangesAsync();
    }

    /// <summary>
    ///     Saves all changes made in this context to the database with distributed transaction.
    /// </summary>
    /// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
    /// <param name="unitOfWorks">An optional <see cref="IUnitOfWork" /> array.</param>
    /// <returns>
    ///     A <see cref="Task{TResult}" /> that represents the asynchronous save operation. The task result contains the
    ///     number of state entities written to database.
    /// </returns>
    public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false, params IUnitOfWork[] unitOfWorks)
    {
        using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            var count = 0;
            foreach (var unitOfWork in unitOfWorks)
                count += await unitOfWork.SaveChangesAsync(ensureAutoHistory).ConfigureAwait(false);

            count += await SaveChangesAsync(ensureAutoHistory);

            ts.Complete();

            return count;
        }
    }

    /// <summary>
    ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    /// <summary>
    ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    /// <param name="disposing">The disposing.</param>
    private void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
            {
                // clear repositories
                if (_repositories != null) _repositories.Clear();

                // dispose the db context.
                DbContext.Dispose();
            }

        _disposed = true;
    }
}