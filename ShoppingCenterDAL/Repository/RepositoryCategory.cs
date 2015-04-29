using ShoppingCenterBOL;
using ShoppingCenterDAL.IRepository;

namespace ShoppingCenterDAL.Repository
{
    public class RepositoryCategory : Repository<Category>, IRepositoryCategory
    {
        public RepositoryCategory(ShoppingCenterDBContext context)
            : base(context)
        {

        }
    }
}
