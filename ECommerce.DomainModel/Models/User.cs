using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainModel
{
   public class User: IdentityUser
    {

        public virtual ICollection<Order> Orders { get; set; }
    }
}
