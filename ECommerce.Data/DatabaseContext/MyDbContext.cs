using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.DomainModel;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ECommerce.Data.DatabaseContext
{
   public class MyDbContext : IdentityDbContext<User>
    {
        public MyDbContext():base("DefaultConnection")
        {

        }

        static MyDbContext()
        {
            Database.SetInitializer(new
               MigrateDatabaseToLatestVersion<MyDbContext, Migrations.Configuration>());
        }



        public DbSet<ProductGroup> ProductGroups { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Order>  Orders { get; set; }
        public DbSet<OrderDetail>  OrderDetails { get; set; }
        public DbSet<Product_Feature>  Product_Features { get; set; }
        public DbSet<Product_ProductGroup>  Product_ProductGroups { get; set; }
        public DbSet<ProductGalery>   ProductGaleries { get; set; }
        public DbSet<Tag>  Tags { get; set; }

    }
}
