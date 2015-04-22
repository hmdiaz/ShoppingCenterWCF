﻿using ShoppingCenterBOL;
using ShoppingCenterDAL.IRepository;

namespace ShoppingCenterDAL.Repository
{
    public class RepositoryUser : Repository<User>, IRepositoryUser
    {
        public RepositoryUser(ShoppingCenterDBContext context)
            : base(context)
        {

        }
    }
}