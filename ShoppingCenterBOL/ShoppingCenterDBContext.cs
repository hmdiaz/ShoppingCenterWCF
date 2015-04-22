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
    }
}