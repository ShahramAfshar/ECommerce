using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Data.DatabaseContext
{
   public class MyDbContext :DbContext
    {
        public MyDbContext():base("DefaultConnection")
        {

        }


    }
}
