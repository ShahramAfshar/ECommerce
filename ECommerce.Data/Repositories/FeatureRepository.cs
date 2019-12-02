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

            public interface IFeatureRepository : IRepository<Feature>
    {
        //------Definition Private Functions Model -------------//
        //   IList<User> GetActiveUsers();

    }

    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {

        private readonly DbContext db;
        public FeatureRepository(DbContext dbContext) : base(dbContext)
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
