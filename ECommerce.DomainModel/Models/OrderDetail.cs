using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainModel
{
  public  class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Products { get; set; }
    }
}
