using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;


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
        //private UnitRepository unitRepository;
        //public UnitRepository UnitRepository
        //{
        //    get
        //    {
        //        if (unitRepository == null)
        //        {
        //            unitRepository = new UnitRepository(db);
        //        }

        //        return unitRepository;
        //    }
        //}



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
