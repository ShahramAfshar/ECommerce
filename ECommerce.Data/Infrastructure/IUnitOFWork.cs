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
        OrderRepository OrderRepository { get; }
        SliderRepository SliderRepository { get; }
        FeatureRepository FeatureRepository { get; }
        ProductRepository ProductRepository { get; }
        CommentRepository  CommentRepository { get; }
        ContactUsRepository ContactUsRepository { get; }
        OrderDetailRepository  OrderDetailRepository { get; }
        ProductGroupRepository ProductGroupRepository { get; }
        ProductGaleryRepository ProductGaleryRepository { get; }
        Product_FeatureRepository Product_FeatureRepository { get; }
        Product_ProductGroupRepository Product_ProductGroupRepository { get; }


        void Commit();
        Task<int> CommitAsync();


    }
}
