using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Whenver.Base.Entities;
using Whenver.Base.Entities.ProductOrder;
using Whenver.Base.Request;

namespace Whenever.Infrastruture.Data;

public class 
    ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserContext userContext)
    : IdentityDbContext<User, Role, Guid, UserClaim,UserRole, UserLogin, RoleClaim, UserToken>(options)
{
    
    //Postgre SQL mặc định là public, đặt schema mới là application sẽ tạo 1 thư mục riêng trong db dễ quản lý
    private readonly string _applicationSchema = "application";
    //Db set
    
    public DbSet<Accessory>  Accessories { get; set; }
    public DbSet<Category>  Categories { get; set; }
    public DbSet<AccessoryCategory>AccessoryCategories { get; set; }
    public DbSet<AccessoryInventory>AccessoryInventories { get; set; }
    public DbSet<ApplicationLog>  ApplicationLogs { get; set; }
    public DbSet<Banner>  Banners { get; set; }
    public DbSet<Colors>   Colors { get; set; }
    public DbSet<Images> Images { get; set; }
    public DbSet<PersonalizationUser> PersonalizationUsers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductColor>  ProductColors { get; set; }
    public DbSet<ProductFabric>  ProductFabrics { get; set; }
    public DbSet<ProductInventory>ProductInventories { get; set; }
    public DbSet<ProductForm>  ProductForms { get; set; }
    public DbSet<ProductSize>  ProductSizes { get; set; }
    public DbSet<Sizes> Sizes { get; set; }
    public DbSet<CartItem>   CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ShippingAddress> ShippingAddresses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Thiết lập Schema
        // Tất cả các bảng đã khai báo ở trên bỏ hết vào schema application
        modelBuilder.HasDefaultSchema(_applicationSchema);
        
        // gọi base để Identity nạp các cấu hình gốc
        base.OnModelCreating(modelBuilder);
        //Kích hoạt các tùy chỉnh tên bảng của tôi
        RegisterUsersRolesMappings(modelBuilder);
    }
    private void RegisterUsersRolesMappings(ModelBuilder builder)
    {
        builder.Entity<User>(entity =>
        {
            entity.ToTable("user");
            entity.HasMany(e => e.UserClaims).WithOne(e => e.User).HasForeignKey(e => e.UserId).IsRequired();
            entity.HasMany(e => e.UserTokens).WithOne(e => e.User).HasForeignKey(e => e.UserId).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.UserLogins).WithOne(e => e.User).HasForeignKey(e => e.UserId).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<RoleClaim>(entity =>
        {
            entity.ToTable("role_claim");
            entity.HasOne(s => s.Role).WithMany().HasForeignKey(s => s.RoleId).OnDelete(DeleteBehavior.ClientNoAction);
        });

        builder.Entity<Role>(entity =>
        {
            entity.ToTable("role");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.HasMany(e => e.RoleClaims).WithOne(e => e.Role).HasForeignKey(e => e.RoleId).IsRequired();
        });

        builder.Entity<UserRole>(entity =>
        {
            entity.ToTable("user_role");
            entity.HasOne(s => s.Role).WithMany(s => s.UserRoles).HasForeignKey(s => s.RoleId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            entity.HasOne(s => s.User).WithMany(s => s.UserRoles).HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        });

        builder.Entity<UserLogin>(entity => { entity.ToTable("user_login"); });
        builder.Entity<UserClaim>(entity => { entity.ToTable("user_claim"); });
        builder.Entity<UserToken>(entity => { entity.ToTable("user_token"); });
        builder.Entity<PersonalizationUser>().HasKey(p => p.Id);

    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Lọc ra các entry đang Added hoặc Modified
        var entries = ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            // Kiểm tra xem Entity có thuộc tính mong muốn không để tránh crash
            // Hoặc tốt hơn là kiểm tra xem nó có kế thừa BaseEntity không
            var createdAtProp = entry.Metadata.FindProperty("CreatedAt");
            var updatedAtProp = entry.Metadata.FindProperty("UpdatedAt");

            if (entry.State == EntityState.Added && createdAtProp != null)
            {
                entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                entry.Property("CreatedBy").CurrentValue = userContext.UserId?.ToString();
            }
    
            if (entry.State == EntityState.Modified && updatedAtProp != null)
            {
                entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                entry.Property("UpdatedBy").CurrentValue = userContext.UserId?.ToString();
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    
}