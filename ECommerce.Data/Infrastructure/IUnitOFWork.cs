using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
   public interface IUnitOfWork<TContext> : IDisposable where TContext:DbContext 
    {
        //1-Begin TransAction  2-Commit(SaveChange) 3-RollBack
      // UnitRepository UnitRepository { get; } //Read Only


        void Commit();
        Task<int> CommitAsync();


    }
}
