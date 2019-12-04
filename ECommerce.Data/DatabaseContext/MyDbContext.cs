﻿using System;
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

        static MyDbContext()
        {
            Database.SetInitializer(new
               MigrateDatabaseToLatestVersion<MyDbContext, Migrations.Configuration>());
        }

        public System.Data.Entity.DbSet<ECommerce.DomainModel.ProductGroup> ProductGroups { get; set; }

        public System.Data.Entity.DbSet<ECommerce.DomainModel.Product> Products { get; set; }

        public System.Data.Entity.DbSet<ECommerce.DomainModel.Feature> Features { get; set; }

        public System.Data.Entity.DbSet<ECommerce.DomainModel.Slider> Sliders { get; set; }
    }
}
