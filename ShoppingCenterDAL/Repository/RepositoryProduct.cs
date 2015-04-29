﻿using ShoppingCenterBOL;
using ShoppingCenterDAL.IRepository;

namespace ShoppingCenterDAL.Repository
{
    public class RepositoryProduct : Repository<Product>, IRepositoryProduct
    {
        public RepositoryProduct(ShoppingCenterDBContext context)
            : base(context)
        {

        }
    }
}