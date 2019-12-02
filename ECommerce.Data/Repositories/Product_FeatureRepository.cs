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
        //   IList<User> GetActiveUsers();

    }

    public class Product_FeatureRepository : Repository<Product_Feature>, IProduct_FeatureRepository
    {

        private readonly DbContext db;
        public Product_FeatureRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }

        //public IList<User> GetActiveUsers()
        //{
        //    var users = GetAll().Where(u => u.IsActive)
        //        .ToList();
        //    return users;
        //}



    }

}
