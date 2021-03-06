﻿using ShoppingCenterBOL;
using ShoppingCenterBOL.Entities;
using ShoppingCenterDAL.IRepository;

namespace ShoppingCenterDAL.Repository
{
    public class RepositoryUserInfo : Repository<UserInfo>, IRepositoryUserInfo
    {
        public RepositoryUserInfo(ShoppingCenterDBContext context)
            : base(context)
        {

        }
    }
}
