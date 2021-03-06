﻿using ShoppingCenterBOL;
using ShoppingCenterBOL.Entities;
using ShoppingCenterDAL.IRepository;

namespace ShoppingCenterDAL.Repository
{
    public class RepositoryProvider : Repository<Provider>, IRepositoryProvider
    {
        public RepositoryProvider(ShoppingCenterDBContext context)
            : base(context)
        {

        }
    }
}
