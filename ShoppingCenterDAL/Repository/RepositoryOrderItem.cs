using ShoppingCenterBOL;
using ShoppingCenterBOL.Entities;
using ShoppingCenterDAL.IRepository;

namespace ShoppingCenterDAL.Repository
{
    public class RepositoryOrderItem : Repository<OrderItem>, IRepositoryOrderItem
    {
        public RepositoryOrderItem(ShoppingCenterDBContext context)
            : base(context)
        {

        }
    }
}
