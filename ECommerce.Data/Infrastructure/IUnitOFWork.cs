using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data.Repositories;


namespace ECommerce.Data
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        //1-Begin TransAction  2-Commit(SaveChange) 3-RollBack
        TagRepository TagRepository { get; }
        ProductRepository ProductRepository { get; }
        ProductGroupRepository ProductGroupRepository { get; }
        Product_ProductGroupRepository Product_ProductGroupRepository { get; }


        void Commit();
        Task<int> CommitAsync();


    }
}
