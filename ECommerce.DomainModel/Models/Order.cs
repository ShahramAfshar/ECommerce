﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainModel
{
   public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsFinaly { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        //public virtual Users Users { get; set; }
    }
}
