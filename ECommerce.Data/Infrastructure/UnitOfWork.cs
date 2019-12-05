using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data.Repositories;

namespace ECommerce.Data
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()

    {

        #region Fileds
        protected readonly DbContext db;

        #endregion

        #region Ctor
        public UnitOfWork()
        {
            db = new TContext();
        }

        #endregion

        #region Implement

        public void Commit()
        {
            db.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return db.SaveChangesAsync();
        }

        #endregion

        #region Repositories

        private TagRepository tagRepository;
        public TagRepository TagRepository
        {
            get
            {
                if (tagRepository == null)
                {
                    tagRepository = new TagRepository(db);
                }

                return tagRepository;
            }
        }

        private OrderRepository orderRepository;
        public OrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(db);
                }

                return orderRepository;
            }
        }

        private SliderRepository sliderRepository;
        public SliderRepository SliderRepository
        {
            get
            {
                if (sliderRepository == null)
                {
                    sliderRepository = new SliderRepository(db);
                }

                return sliderRepository;
            }
        }

        private FeatureRepository featureRepository;
        public FeatureRepository FeatureRepository
        {
            get
            {
                if (featureRepository == null)
                {
                    featureRepository = new FeatureRepository(db);
                }

                return featureRepository;
            }
        }

        private ProductRepository productRepository;
        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(db);
                }

                return productRepository;
            }
        }

        private OrderDetailRepository orderDetailRepository;
        public OrderDetailRepository OrderDetailRepository
        {
            get
            {
                if (orderDetailRepository == null)
                {
                    orderDetailRepository = new OrderDetailRepository(db);
                }

                return orderDetailRepository;
            }
        }

        private ProductGroupRepository productGroupRepository;
        public ProductGroupRepository ProductGroupRepository
        {
            get
            {
                if (productGroupRepository == null)
                {
                    productGroupRepository = new ProductGroupRepository(db);
                }

                return productGroupRepository;
            }
        }

        private ProductGaleryRepository productGaleryRepository;
        public ProductGaleryRepository ProductGaleryRepository
        {
            get
            {
                if (productGaleryRepository == null)
                {
                    productGaleryRepository = new ProductGaleryRepository(db);
                }

                return productGaleryRepository;
            }
        }

        private Product_FeatureRepository product_FeatureRepository;
        public Product_FeatureRepository Product_FeatureRepository
        {
            get
            {
                if (product_FeatureRepository == null)
                {
                    product_FeatureRepository = new Product_FeatureRepository(db);
                }

                return product_FeatureRepository;
            }
        }


        private Product_ProductGroupRepository product_ProductGroupRepository;
        public Product_ProductGroupRepository Product_ProductGroupRepository
        {
            get
            {
                if (product_ProductGroupRepository == null)
                {
                    product_ProductGroupRepository = new Product_ProductGroupRepository(db);
                }

                return product_ProductGroupRepository;
            }
        }


        #endregion

        #region Dispose

        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}
