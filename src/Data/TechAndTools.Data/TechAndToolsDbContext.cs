using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechAndTools.Data.Models;
using TechAndTools.Data.Models.Blog;

namespace TechAndTools.Data
{
    public class TechAndToolsDbContext : IdentityDbContext<TechAndToolsUser>
    {
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<DescriptionProperty> DescriptionProperties { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }

        public TechAndToolsDbContext(DbContextOptions<TechAndToolsDbContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BlogComment>()
                .HasKey(x => new { x.BlogPostId, x.UserId });

            builder.Entity<OrderProduct>()
                .HasKey(x => new { x.OrderId, x.ProductId });

            builder.Entity<FavoriteProduct>()
                .HasKey(x => new { x.UserId, x.ProductId });

            builder.Entity<ShoppingCartProduct>()
                .HasKey(x => new { x.ShoppingCardId, x.ProductId });

            builder.Entity<ShoppingCart>()
                .HasOne(x => x.User)
                .WithOne(x => x.ShoppingCart)
                .HasForeignKey<TechAndToolsUser>(x => x.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
