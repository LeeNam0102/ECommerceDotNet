using ECommerceDotNet.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDotNet.Infrastructure.Persistence.DataContexts
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        //Admin
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        //combination table
        public virtual DbSet<UserRole> UserRoles { get; set; }

        //User - UI
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SizeOption> SizeOptions { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        //combination table of product
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductCollection> ProductCollections { get; set; }
        public virtual DbSet<ProductComment> ProductComments { get; set; }
        public virtual DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public virtual DbSet<ProductSizeOption> ProductSizeOptions { get; set; }
        public virtual DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public virtual DbSet<ProductCart> ProductCarts { get; set; }

        //combination table of user
        public virtual DbSet<UserCart> UserCarts { get; set; }
        public virtual DbSet<UserCollection> UserCollections { get; set; }
        public virtual DbSet<UserComment> UserComments { get; set; }
        public virtual DbSet<UserOrder> UserOrders { get; set; }
        public virtual DbSet<UserPayment> UserPayments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // admin
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(m => new { m.UserId, m.RoleId });
            });
            //User - UI
            modelBuilder.Entity<UserCart>(entity =>
            {
                entity.HasKey(m => new { m.UserId, m.CartId });
            });
            modelBuilder.Entity<UserCollection>(entity =>
            {
                entity.HasKey(m => new { m.UserId, m.CollectionId });
            });
            modelBuilder.Entity<UserComment>(entity =>
            {
                entity.HasKey(m => new { m.UserId, m.CommentId });
            });
            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.HasKey(m => new { m.UserId, m.OrderId });
            });
            modelBuilder.Entity<UserPayment>(entity =>
            {
                entity.HasKey(m => new { m.UserId, m.PaymentId });
            });
            modelBuilder.Entity<ProductCart>(entity =>
            {
                entity.HasKey(m => new { m.ProductId, m.CartId });
            });
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(m => new { m.ProductId, m.CategoryId });
            });
            modelBuilder.Entity<ProductComment>(entity =>
            {
                entity.HasKey(m => new { m.ProductId, m.CommentId });
            });
            modelBuilder.Entity<ProductDiscount>(entity =>
            {
                entity.HasKey(m => new { m.ProductId, m.DiscountId });
            });
            modelBuilder.Entity<ProductSizeOption>(entity =>
            {
                entity.HasKey(m => new { m.ProductId, m.Size });
            });
            modelBuilder.Entity<ProductSupplier>(entity =>
            {
                entity.HasKey(m => new { m.ProductId, m.SupplierId });
            });
            modelBuilder.Entity<ProductCollection>(entity =>
            {
                entity.HasKey(pc => new { pc.ProductId, pc.CollectionId });
            });
            ViewModelBuilder(ref modelBuilder);
            StoreModelBuilder(ref modelBuilder);
        }
    }
}
