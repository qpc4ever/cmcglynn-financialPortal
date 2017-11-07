namespace cmcglynn_financialPortal.Migrations
{
    using cmcglynn_financialPortal.Models;
    using cmcglynn_financialPortal.Models.CodeFirst;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<cmcglynn_financialPortal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(cmcglynn_financialPortal.Models.ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(
               new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "qpc4ever@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "qpc4ever@gmail.com",
                    Email = "qpc4ever@gmail.com",
                    FirstName = "Chris",
                    LastName = "McGlynn",
                }, "Qpc4ever!");
            }
            var userId = userManager.FindByEmail("qpc4ever@gmail.com").Id;
            //userManager.AddToRole(userId);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            if (!context.Categories.Any(c => c.Name == "Entertainment"))
            {
                var category = new Category();
                category.Name = "Entertainment";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Clothing"))
            {
                var category = new Category();
                category.Name = "Clothing";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Mortgage"))
            {
                var category = new Category();
                category.Name = "Mortgage";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Rent"))
            {
                var category = new Category();
                category.Name = "Rent";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Utilities"))
            {
                var category = new Category();
                category.Name = "Utilities";
                context.Categories.Add(category);
            }
        }
    }
}
