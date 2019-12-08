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


    public interface IProduct_FeatureRepository : IRepository<Product_Feature>
    {
        //------Definition Private Functions Model -------------//
          //IEnumerable<Feature> GetFoProduct();

    }

    public class Product_FeatureRepository : Repository<Product_Feature>, IProduct_FeatureRepository
    {

        private readonly DbContext db;
        public Product_FeatureRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }

        //public IEnumerable<Feature> GetFoProduct()
        //{
        //    GetAll().Where(fe => fe.FeatureID == f.FeatureID))

        //    //db.Product_Features.Where(fe => fe.FeatureID == f.FeatureID).Select(fe => fe.Value).ToList()
        //    //}).ToList()
        //}

        //public IList<User> GetActiveUsers()
        //{
        //    var users = GetAll().Where(u => u.IsActive)
        //        .ToList();
        //    return users;
        //}



    }

}
