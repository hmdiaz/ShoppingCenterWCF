using ShoppingCenterBOL.Entities;
using System.Data.Entity;

namespace ShoppingCenterBOL
{
    public class ShoppingCenterDBContext : DbContext
    {
        public ShoppingCenterDBContext()
            : base("name=ShoppingCenterDBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductInfo> ProductInfoes { get; set; }
        
        public virtual DbSet<Provider> Providers { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}