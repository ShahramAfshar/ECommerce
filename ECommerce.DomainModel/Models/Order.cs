using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ECommerce.DomainModel
{
   public partial class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinaly { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual User User { get; set; }

    }
}
