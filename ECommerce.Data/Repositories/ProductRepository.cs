using ECommerce.Data.DatabaseContext;
using ECommerce.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{


    public interface IProductRepository : IRepository<Product>
    {
        //------Definition Private Functions Model -------------//
         IList<Product> GetMaxSale(int skip,int take);
         IList<Product> GetLastAdd(int skip,int take);
         IEnumerable<Product> GetSameGroup(int productId);
        IEnumerable<Product> Search(string q);

    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly DbContext db;
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }

        public IList<Product> GetMaxSale(int skip, int take)
        {
            var products = GetAll().OrderByDescending(p => p.CountSale).Skip(skip).Take(take).ToList();

            return products;
        }

        public IList<Product> GetLastAdd(int skip, int take)
        {
            var products = GetAll().OrderByDescending(p => p.CreateDate).Skip(skip).Take(take).ToList();

            return products;
        }

        public IEnumerable<Product> GetSameGroup(int producGrouptId)
        {


         //   var products = GetAll().Where(p => p.ProductId==productId).ToList();

            return null;
        }

        public IEnumerable<Product> Search(string q)
        {
            var res = GetAll().Where(p => p.ProductTitle.Contains(q) || p.ShortDescription.Contains(q) || p.Text.Contains(q)).ToList();

            return res;
        }
    }


}
