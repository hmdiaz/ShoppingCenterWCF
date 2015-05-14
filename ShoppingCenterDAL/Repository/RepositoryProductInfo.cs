using ShoppingCenterBOL;
using ShoppingCenterBOL.Entities;
using ShoppingCenterDAL.IRepository;

namespace ShoppingCenterDAL.Repository
{
    public class RepositoryProductInfo : Repository<ProductInfo>, IRepositoryProductInfo
    {
        public RepositoryProductInfo(ShoppingCenterDBContext context)
            : base(context)
        {

        }
    }
}
