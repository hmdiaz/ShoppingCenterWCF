using System.Data.Entity;

namespace ShoppingCenterBOL
{
    public class ShoppingCenterDBContext : DbContext
    {
        public ShoppingCenterDBContext()
            : base("name=ShoppingCenterDBContext")
        {

        }

        public  DbSet<User> Users { get; set; }
        public  DbSet<UserInfo> UserInfoes { get; set; }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<ProductInfo> ProductInfoes { get; set; }
        public  DbSet<Provider> Providers { get; set; }
    }
}