using System.Data.Entity;

namespace ShoppingCenterBOL
{
    public class ShoppingCenterDBContext : DbContext
    {
        public ShoppingCenterDBContext()
            : base("name=ShoppingCenterDBContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductInfo> ProductInfoes { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
    }
}