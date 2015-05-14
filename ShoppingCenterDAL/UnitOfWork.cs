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
                if (this.userInfoRepository == null)
                {
                    this.userInfoRepository = new RepositoryUserInfo(context);
                }
                return userInfoRepository;
            }
        }
        private RepositoryUserInfo userInfoRepository;

        public RepositoryProduct ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new RepositoryProduct(context);
                }
                return productRepository;
            }
        }
        private RepositoryProduct productRepository;

        public RepositoryProductInfo ProductInfoRepository
        {
            get
            {
                if (this.productInfoRepository == null)
                {
                    this.productInfoRepository = new RepositoryProductInfo(context);
                }
                return productInfoRepository;
            }
        }
        private RepositoryProductInfo productInfoRepository;

        public RepositoryProvider ProviderRepository
        {
            get
            {
                if (this.providerRepository == null)
                {
                    this.providerRepository = new RepositoryProvider(context);
                }
                return providerRepository;
            }
        }
        private RepositoryProvider providerRepository;

        public RepositoryCategory CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new RepositoryCategory(context);
                }
                return categoryRepository;
            }
        }
        private RepositoryCategory categoryRepository;

        public RepositoryOrder OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new RepositoryOrder(context);
                }
                return orderRepository;
            }
        }
        private RepositoryOrder orderRepository;

        public RepositoryOrderItem OrderItemRepository
        {
            get
            {
                if (this.orderItemRepository == null)
                {
                    this.orderItemRepository = new RepositoryOrderItem(context);
                }
                return orderItemRepository;
            }
        }
        private RepositoryOrderItem orderItemRepository;

        public RepositoryShoppingCart ShoppingCartRepository
        {
            get
            {
                if (this.shoppingCartRepository == null)
                {
                    this.shoppingCartRepository = new RepositoryShoppingCart(context);
                }
                return shoppingCartRepository;
            }
        }
        private RepositoryShoppingCart shoppingCartRepository;

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