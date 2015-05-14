using ShoppingCenterBOL;
using ShoppingCenterBOL.Entities;
using ShoppingCenterDAL.IRepository;

namespace ShoppingCenterDAL.Repository
{
    public class RepositoryOrder : Repository<Order>, IRepositoryOrder
    {
        public RepositoryOrder(ShoppingCenterDBContext context)
            : base(context)
        {

        }
    }
}
