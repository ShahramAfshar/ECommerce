using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainModel
{
  public class Product_ProductGroup
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ProductGroupId { get; set; }

        public virtual Product Product { get; set; }
    }
}
