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


    public interface IProduct_ProductGroupRepository : IRepository<Product_ProductGroup>
    {
        //------Definition Private Functions Model -------------//
         IEnumerable<Product> GetProduct(int productGroupId);

    }

    public class Product_ProductGroupRepository : Repository<Product_ProductGroup>, IProduct_ProductGroupRepository
    {

        private readonly DbContext db;
        public Product_ProductGroupRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }

        public IEnumerable<Product> GetProduct(int productGroupId)
        {
            List<Product> list = new List<Product>();

             list.AddRange(GetAll().Where(pg=>pg.ProductGroupId==productGroupId).Select(g=>g.Product).ToList());

            return list;
        }

        //public IList<User> GetActiveUsers()
        //{
        //    var users = GetAll().Where(u => u.IsActive)
        //        .ToList();
        //    return users;
        //}



    }

}
