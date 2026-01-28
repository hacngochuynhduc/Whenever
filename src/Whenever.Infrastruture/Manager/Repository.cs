using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Whenever.Infrastruture.Collection;
using Whenever.Infrastruture.Extension;

namespace Whenever.Infrastruture.Manager;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Repository{TEntity,TKey}" /> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = _dbContext.Set<TEntity>();
    }

    /// <summary>
    ///     Gets all entities. This method is not recommended
    /// </summary>
    /// <returns>The <see cref="IQueryable{TEntity}" />.</returns>
    public IQueryable<TEntity> GetAll()
    {
        return _dbSet;
    }

    /// <summary>
    ///     Gets all entities. This method is not recommended
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="orderBy">A function to order elements.</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="disableTracking">
    ///     <c>true</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>
    ///     .
    /// </param>
    /// <param name="ignoreQueryFilters">Ignore query filters</param>
    /// <returns>
    ///     An <see cref="IPagedList{T}" /> that contains elements that satisfy the condition specified by
    ///     <paramref name="predicate" />.
    /// </returns>
    /// <remarks>Ex: This method defaults to a read-only, no-tracking query.</remarks>
    public IQueryable<TEntity> GetAll(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

        if (orderBy != null) return orderBy(query);

        return query;
    }

    /// <summary>
    ///     Gets all entities. This method is not recommended
    /// </summary>
    /// <param name="selector">The selector for projection.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="orderBy">A function to order elements.</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="disableTracking">
    ///     <c>true</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>
    ///     .
    /// </param>
    /// <param name="ignoreQueryFilters">Ignore query filters</param>
    /// <returns>
    ///     An <see cref="IPagedList{TEntity}" /> that contains elements that satisfy the condition specified by
    ///     <paramref name="predicate" />.
    /// </returns>
    /// <remarks>Ex: This method defaults to a read-only, no-tracking query.</remarks>
    public IQueryable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

        if (orderBy != null) return orderBy(query).Select(selector);

        return query.Select(selector);
    }

    /// <summary>
    ///     Gets the <see cref="IPagedList{TEntity}" /> based on a predicate, orderby delegate and page information. This
    ///     method default no-tracking query.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="orderBy">A function to order elements.</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="pageIndex">The index of page.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <param name="disableTracking">
    ///     <c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>
    ///     .
    /// </param>
    /// <param name="ignoreQueryFilters">Ignore query filters</param>
    /// <returns>
    ///     An <see cref="IPagedList{TEntity}" /> that contains elements that satisfy the condition specified by
    ///     <paramref name="predicate" />.
    /// </returns>
    /// <remarks>This method default no-tracking query.</remarks>
    public IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 20,
        bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

        if (orderBy != null) return orderBy(query).ToPagedList(pageIndex, pageSize);

        return query.ToPagedList(pageIndex, pageSize);
    }

    /// <summary>
    ///     Gets the <see cref="IPagedList{TEntity}" /> based on a predicate, orderby delegate and page information. This
    ///     method default no-tracking query.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="orderBy">A function to order elements.</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="pageIndex">The index of page.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <param name="disableTracking">
    ///     <c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>
    ///     .
    /// </param>
    /// <param name="cancellationToken">
    ///     A <see cref="CancellationToken" /> to observe while waiting for the task to complete.
    /// </param>
    /// <param name="ignoreQueryFilters">Ignore query filters</param>
    /// <returns>
    ///     An <see cref="IPagedList{TEntity}" /> that contains elements that satisfy the condition specified by
    ///     <paramref name="predicate" />.
    /// </returns>
    /// <remarks>This method default no-tracking query.</remarks>
    public Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 20,
        bool disableTracking = true,
        CancellationToken cancellationToken = default,
        bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

        if (orderBy != null) return orderBy(query).ToPagedListAsync(pageIndex, pageSize, cancellationToken);

        return query.ToPagedListAsync(pageIndex, pageSize, cancellationToken);
    }

    /// <summary>
    ///     Gets the <see cref="IPagedList{TResult}" /> based on a predicate, orderby delegate and page information. This
    ///     method default no-tracking query.
    /// </summary>
    /// <param name="selector">The selector for projection.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="orderBy">A function to order elements.</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="pageIndex">The index of page.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <param name="disableTracking">
    ///     <c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>
    ///     .
    /// </param>
    /// <param name="ignoreQueryFilters">Ignore query filters</param>
    /// <returns>
    ///     An <see cref="IPagedList{TResult}" /> that contains elements that satisfy the condition specified by
    ///     <paramref name="predicate" />.
    /// </returns>
    /// <remarks>This method default no-tracking query.</remarks>
    public IPagedList<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 20,
        bool disableTracking = true,
        bool ignoreQueryFilters = false)
        where TResult : class
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

        if (orderBy != null) return orderBy(query).Select(selector).ToPagedList(pageIndex, pageSize);

        return query.Select(selector).ToPagedList(pageIndex, pageSize);
    }

    /// <summary>
    ///     Gets the <see cref="IPagedList{TEntity}" /> based on a predicate, orderby delegate and page information. This
    ///     method default no-tracking query.
    /// </summary>
    /// <param name="selector">The selector for projection.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="orderBy">A function to order elements.</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="pageIndex">The index of page.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <param name="disableTracking">
    ///     <c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>
    ///     .
    /// </param>
    /// <param name="cancellationToken">
    ///     A <see cref="CancellationToken" /> to observe while waiting for the task to complete.
    /// </param>
    /// <param name="ignoreQueryFilters">Ignore query filters</param>
    /// <returns>
    ///     An <see cref="IPagedList{TEntity}" /> that contains elements that satisfy the condition specified by
    ///     <paramref name="predicate" />.
    /// </returns>
    /// <remarks>This method default no-tracking query.</remarks>
    public Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 20,
        bool disableTracking = true,
        CancellationToken cancellationToken = default,
        bool ignoreQueryFilters = false)
        where TResult : class
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

        if (orderBy != null)
            return orderBy(query).Select(selector).ToPagedListAsync(pageIndex, pageSize, cancellationToken);

        return query.Select(selector).ToPagedListAsync(pageIndex, pageSize, cancellationToken);
    }

    /// <summary>
    ///     Gets the first or default entity based on a predicate, orderby delegate and include delegate. This method default
    ///     no-tracking query.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="orderBy">A function to order elements.</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="disableTracking">
    ///     <c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>
    ///     .
    /// </param>
    /// <param name="ignoreQueryFilters">Ignore query filters</param>
    /// <returns>
    ///     An <see cref="IPagedList{TEntity}" /> that contains elements that satisfy the condition specified by
    ///     <paramref name="predicate" />.
    /// </returns>
    /// <remarks>This method default no-tracking query.</remarks>
    public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

        if (orderBy != null) return orderBy(query).FirstOrDefault();

        return query.FirstOrDefault();
    }

    /// <summary>
    ///     Gets the first or default entity based on a predicate, orderby delegate and include delegate. This method default
    ///     no-tracking query.
    /// </summary>
    /// <param name="selector">The selector for projection.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="orderBy">A function to order elements.</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="disableTracking">
    ///     <c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>
    ///     .
    /// </param>
    /// <param name="ignoreQueryFilters">Ignore query filters</param>
    /// <returns>
    ///     An <see cref="IPagedList{TEntity}" /> that contains elements that satisfy the condition specified by
    ///     <paramref name="predicate" />.
    /// </returns>
    /// <remarks>This method default no-tracking query.</remarks>
    public TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

        if (orderBy != null) return orderBy(query).Select(selector).FirstOrDefault();

        return query.Select(selector).FirstOrDefault();
    }

    /// <inheritdoc />
    public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

        if (orderBy != null) return await orderBy(query).Select(selector).FirstOrDefaultAsync();

        return await query.Select(selector).FirstOrDefaultAsync();
    }

    public async Task<TEntity?> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        string? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking)
            query = query.AsNoTracking();

        if (ignoreQueryFilters)
            query = query.IgnoreQueryFilters();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);

        if (!string.IsNullOrWhiteSpace(orderBy))
            query = query.OrderBy(orderBy); // Dynamic order by string (e.g., "Name desc")

        return await query.FirstOrDefaultAsync();
    }

    /// <summary>
    ///     Uses raw SQL queries to fetch the specified <typeparamref name="TEntity" /> data.
    /// </summary>
    /// <param name="sql">The raw SQL.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns>An <see cref="IQueryable{TEntity}" /> that contains elements that satisfy the condition specified by raw SQL.</returns>
    public IQueryable<TEntity> FromSql(string sql, params object[] parameters)
    {
        return _dbSet.FromSqlRaw(sql, parameters);
    }

    /// <summary>
    ///     Finds an entity with the given primary key values. If found, is attached to the context and returned. If no entity
    ///     is found, then null is returned.
    /// </summary>
    /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
    /// <returns>The found entity or null.</returns>
    public TEntity Find(params object[] keyValues)
    {
        return _dbSet.Find(keyValues);
    }

    /// <summary>
    ///     Finds an entity with the given primary key values. If found, is attached to the context and returned. If no entity
    ///     is found, then null is returned.
    /// </summary>
    /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
    /// <returns>A <see cref="Task{TEntity}" /> that represents the asynchronous insert operation.</returns>
    public ValueTask<TEntity> FindAsync(params object[] keyValues)
    {
        return _dbSet.FindAsync(keyValues);
    }

    /// <summary>
    ///     Finds an entity with the given primary key values. If found, is attached to the context and returned. If no entity
    ///     is found, then null is returned.
    /// </summary>
    /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     A <see cref="Task{TEntity}" /> that represents the asynchronous find operation. The task result contains the
    ///     found entity or null.
    /// </returns>
    public ValueTask<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
    {
        return _dbSet.FindAsync(keyValues, cancellationToken);
    }

    /// <summary>
    ///     Gets the count based on a predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public int Count(Expression<Func<TEntity, bool>>? predicate = null)
    {
        if (predicate == null) return _dbSet.Count();

        return _dbSet.Count(predicate);
    }

    /// <summary>
    ///     Gets async the count based on a predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        if (predicate == null) return await _dbSet.CountAsync();

        return await _dbSet.CountAsync(predicate);
    }

    /// <summary>
    ///     Gets the max based on a predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// ///
    /// <param name="selector"></param>
    /// <returns>decimal</returns>
    public T Max<T>(Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, T>> selector = null)
    {
        if (predicate == null)
            return _dbSet.Max(selector);
        return _dbSet.Where(predicate).Max(selector);
    }

    /// <summary>
    ///     Gets the async max based on a predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// ///
    /// <param name="selector"></param>
    /// <returns>decimal</returns>
    public async Task<T> MaxAsync<T>(Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, T>> selector = null)
    {
        if (predicate == null)
            return await _dbSet.MaxAsync(selector);
        return await _dbSet.Where(predicate).MaxAsync(selector);
    }

    /// <summary>
    ///     Gets the min based on a predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// ///
    /// <param name="selector"></param>
    /// <returns>decimal</returns>
    public T Min<T>(Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, T>> selector = null)
    {
        if (predicate == null)
            return _dbSet.Min(selector);
        return _dbSet.Where(predicate).Min(selector);
    }

    /// <summary>
    ///     Gets the async min based on a predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// ///
    /// <param name="selector"></param>
    /// <returns>decimal</returns>
    public async Task<T> MinAsync<T>(Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, T>> selector = null)
    {
        if (predicate == null)
            return await _dbSet.MinAsync(selector);
        return await _dbSet.Where(predicate).MinAsync(selector);
    }

    /// <summary>
    ///     Gets the average based on a predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// ///
    /// <param name="selector"></param>
    /// <returns>decimal</returns>
    public decimal Average(Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, decimal>> selector = null)
    {
        if (predicate == null)
            return _dbSet.Average(selector);
        return _dbSet.Where(predicate).Average(selector);
    }

    /// <summary>
    ///     Gets the async average based on a predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// ///
    /// <param name="selector"></param>
    /// <returns>decimal</returns>
    public async Task<decimal> AverageAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, decimal>> selector = null)
    {
        if (predicate == null)
            return await _dbSet.AverageAsync(selector);
        return await _dbSet.Where(predicate).AverageAsync(selector);
    }

    /// <summary>
    ///     Gets the sum based on a predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// ///
    /// <param name="selector"></param>
    /// <returns>decimal</returns>
    public decimal Sum(Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, decimal>> selector = null)
    {
        if (predicate == null)
            return _dbSet.Sum(selector);
        return _dbSet.Where(predicate).Sum(selector);
    }

    /// <summary>
    ///     Gets the async sum based on a predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// ///
    /// <param name="selector"></param>
    /// <returns>decimal</returns>
    public async Task<decimal> SumAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, decimal>> selector = null)
    {
        if (predicate == null)
            return await _dbSet.SumAsync(selector);
        return await _dbSet.Where(predicate).SumAsync(selector);
    }

    /// <summary>
    ///     Gets the exists based on a predicate.
    /// </summary>
    /// <param name="selector"></param>
    /// <returns></returns>
    public bool Exists(Expression<Func<TEntity, bool>>? selector = null)
    {
        if (selector == null) return _dbSet.Any();

        return _dbSet.Any(selector);
    }

    /// <summary>
    ///     Gets the async exists based on a predicate.
    /// </summary>
    /// <param name="selector"></param>
    /// <returns></returns>
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? selector = null)
    {
        if (selector == null) return await _dbSet.AnyAsync();

        return await _dbSet.AnyAsync(selector);
    }

    /// <summary>
    ///     Inserts a new entity synchronously.
    /// </summary>
    /// <param name="entity">The entity to insert.</param>
    public TEntity Insert(TEntity entity)
    {
        return _dbSet.Add(entity).Entity;
    }

    /// <summary>
    ///     Inserts a range of entities synchronously.
    /// </summary>
    /// <param name="entities">The entities to insert.</param>
    public void Insert(params TEntity[] entities)
    {
        _dbSet.AddRange(entities);
    }

    /// <summary>
    ///     Inserts a range of entities synchronously.
    /// </summary>
    /// <param name="entities">The entities to insert.</param>
    public void Insert(IEnumerable<TEntity> entities)
    {
        _dbSet.AddRange(entities);
    }

    /// <summary>
    ///     Inserts a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to insert.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task" /> that represents the asynchronous insert operation.</returns>
    public ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity,
        CancellationToken cancellationToken = default)
    {
        return _dbSet.AddAsync(entity, cancellationToken);
        // Shadow properties?
        //var property = _dbContext.Entry(entity).Property("Created");
        //if (property != null) {
        //property.CurrentValue = DateTime.Now;
        //}
    }

    /// <summary>
    ///     Inserts a range of entities asynchronously.
    /// </summary>
    /// <param name="entities">The entities to insert.</param>
    /// <returns>A <see cref="Task" /> that represents the asynchronous insert operation.</returns>
    public Task InsertAsync(params TEntity[] entities)
    {
        return _dbSet.AddRangeAsync(entities);
    }

    /// <summary>
    ///     Inserts a range of entities asynchronously.
    /// </summary>
    /// <param name="entities">The entities to insert.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task" /> that represents the asynchronous insert operation.</returns>
    public Task InsertAsync(IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default)
    {
        return _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    /// <summary>
    ///     Update Async the specified entities.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public async Task UpdateAsync(IEnumerable<TEntity> entities)
    {
        await Task.Factory.StartNew(() => _dbSet.UpdateRange(entities));
    }

    /// <summary>
    ///     Deletes the specified entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    public async Task DeleteAsync(TEntity entity)
    {
        await Task.Factory.StartNew(() => _dbSet.Remove(entity));
    }

    /// <summary>
    ///     Deletes the entity by the specified primary key.
    /// </summary>
    /// <param name="id">The primary key value.</param>
    public async Task DeleteAsync(object id)
    {
        // using a stub entity to mark for deletion
        var typeInfo = typeof(TEntity).GetTypeInfo();
        var key = _dbContext.Model.FindEntityType(typeInfo)?.FindPrimaryKey()?.Properties.FirstOrDefault();
        var property = typeInfo.GetProperty(key?.Name);
        if (property != null)
        {
            var entity = Activator.CreateInstance<TEntity>();
            property.SetValue(entity, id);
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
        else
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null) await DeleteAsync(entity);
        }
    }

    /// <summary>
    ///     Gets all entities. This method is not recommended
    /// </summary>
    /// <returns>The <see cref="IQueryable{TEntity}" />.</returns>
    public async Task<IList<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    ///     Gets all entities. This method is not recommended
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="orderBy">A function to order elements.</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="disableTracking">
    ///     <c>true</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>
    ///     .
    /// </param>
    /// <param name="ignoreQueryFilters">Ignore query filters</param>
    /// <returns>
    ///     An <see cref="IPagedList{TEntity}" /> that contains elements that satisfy the condition specified by
    ///     <paramref name="predicate" />.
    /// </returns>
    /// <remarks>Ex: This method defaults to a read-only, no-tracking query.</remarks>
    public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

        if (orderBy != null) return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    /// <summary>
    ///     Gets all entities. This method is not recommended
    /// </summary>
    /// <param name="selector">The selector for projection.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="orderBy">A function to order elements.</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="disableTracking">
    ///     <c>true</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>
    ///     .
    /// </param>
    /// <param name="ignoreQueryFilters">Ignore query filters</param>
    /// <returns>
    ///     An <see cref="IPagedList{TEntity}" /> that contains elements that satisfy the condition specified by
    ///     <paramref name="predicate" />.
    /// </returns>
    /// <remarks>Ex: This method defaults to a read-only, no-tracking query.</remarks>
    public async Task<IList<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = true, bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbSet;

        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (ignoreQueryFilters) query = query.IgnoreQueryFilters();


        if (orderBy != null) return await orderBy(query).Select(selector).ToListAsync();

        return await query.Select(selector).ToListAsync();
    }

    /// <summary>
    ///     Change entity state for patch method on web api.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// ///
    /// <param name="state">The entity state.</param>
    public void ChangeEntityState(TEntity entity, EntityState state)
    {
        _dbContext.Entry(entity).State = state;
    }

    /// <summary>
    ///     Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public async Task UpdateAsync(TEntity entity)
    {
        await Task.Factory.StartNew(() => _dbSet.Update(entity));
    }

    /// <summary>
    ///     Deletes the specified entities.
    /// </summary>
    /// <param name="entities">The entities.</param>
    public async Task DeleteAsync(IEnumerable<TEntity> entities)
    {
        await Task.Factory.StartNew(() => _dbSet.RemoveRange(entities));
    }

    /// <summary>
    ///     Deletes the specified entities.
    /// </summary>
    /// <param name="entities">The entities.</param>
    public async Task DeleteAsync(params TEntity[] entities)
    {
        await Task.Factory.StartNew(() => _dbSet.RemoveRange(entities));
        ;
    }
}