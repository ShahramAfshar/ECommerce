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
     
    public interface ISliderRepository : IRepository<Slider>
    {
        //------Definition Private Functions Model -------------//
         IEnumerable<Slider> GetValid();

    }

    public class SliderRepository : Repository<Slider>, ISliderRepository
    {

        private readonly DbContext db;
        public SliderRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }

        public IEnumerable<Slider> GetValid()
        {

            return GetAll().Where(s => s.IsActive == true)
                .Where(s => s.StartDate <= Convert.ToDateTime(DateTime.Now.Toshamsi()))
                .Where(s => s.EndDate >= Convert.ToDateTime(DateTime.Now.Toshamsi()));
        }

        //public IList<User> GetActiveUsers()
        //{
        //    var users = GetAll().Where(u => u.IsActive)
        //        .ToList();
        //    return users;
        //}



    }
}
