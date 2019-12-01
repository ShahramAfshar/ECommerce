using ECommerce.Data.DatabaseContext;
using ECommerce.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace ECommerce.Data.Repositories
{
    public interface IProductGroupRepository : IRepository<ProductGroup>
    {
        //------Definition Private Functions Model -------------//
        //   IList<User> GetActiveUsers();
        IEnumerable<ProductGroup> GetHeadGroup();
        IEnumerable<ProductGroup> GetSubGroupForOneHeader(int id);
    }

    public class ProductGroupRepository : Repository<ProductGroup>, IProductGroupRepository
    {

        private readonly DbContext db;
        public ProductGroupRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }

        public IEnumerable<ProductGroup> GetHeadGroup()
        {
            return GetAll().Where(g => g.ParentId == null).ToList();
        }
        public IEnumerable<ProductGroup> GetSubGroupForOneHeader(int id)
        {
            return GetAll().Where(g => g.ParentId == id).ToList();
        }



    }
}
