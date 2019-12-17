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
     
    public interface ITagRepository : IRepository<Tag>
    {
        //------Definition Private Functions Model -------------//
          IEnumerable<Product> Search(string q);

    }

    public class TagRepository : Repository<Tag>, ITagRepository
    {

        private readonly DbContext db;
        public TagRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }

        public IEnumerable<Product> Search(string q)
        {
            var Tags = GetAll().Where(t => t.Title == q).Select(t=>t.Product).ToList();
            return Tags;
        }





    }
}
