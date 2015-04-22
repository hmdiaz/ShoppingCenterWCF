using ShoppingCenterBOL;
using ShoppingCenterDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterDAL
{
    public class UnitOfWork : IDisposable
    {
        protected ShoppingCenterDBContext context = new ShoppingCenterDBContext();

        public RepositoryUser UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new RepositoryUser(context);
                }
                return userRepository;
            }
        }
        private RepositoryUser userRepository;

        public RepositoryUserInfo UserInfoRepository
        {
            get
            {
                if(this.userInfoRepository == null)
                {
                    this.userInfoRepository = new RepositoryUserInfo(context);
                }
                return userInfoRepository;
            }
        }
        private RepositoryUserInfo userInfoRepository;

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}