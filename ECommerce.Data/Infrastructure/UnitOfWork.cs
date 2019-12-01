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
