using ShoppingCenterBOL;
using ShoppingCenterBOL.Entities;
using ShoppingCenterDAL.IRepository;

namespace ShoppingCenterDAL.Repository
{
    public class RepositoryShoppingCart : Repository<ShoppingCart>, IRepositoryShoppingCart
    {
        public RepositoryShoppingCart(ShoppingCenterDBContext context)
            : base(context)
        {

        }
    }
}
