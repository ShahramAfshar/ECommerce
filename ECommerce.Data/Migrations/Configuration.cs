namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ECommerce.Data.DatabaseContext.MyDbContext";
        }

        protected override void Seed(DatabaseContext.MyDbContext context)
        {

        }
    }
}
