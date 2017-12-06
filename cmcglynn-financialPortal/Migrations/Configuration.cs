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
            if (!context.Categories.Any(c => c.Name == "Education"))
            {
                var category = new Category();
                category.Name = "Education";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Gifts"))
            {
                var category = new Category();
                category.Name = "Gifts";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Charity"))
            {
                var category = new Category();
                category.Name = "Charity";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Food"))
            {
                var category = new Category();
                category.Name = "Food";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Insurance"))
            {
                var category = new Category();
                category.Name = "Insurance";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Taxes"))
            {
                var category = new Category();
                category.Name = "Taxes";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Travel"))
            {
                var category = new Category();
                category.Name = "Travel";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Events"))
            {
                var category = new Category();
                category.Name = "Events";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Paycheck"))
            {
                var category = new Category();
                category.Name = "Paycheck";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Bonus"))
            {
                var category = new Category();
                category.Name = "Bonus";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Investment"))
            {
                var category = new Category();
                category.Name = "Investment";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Interest"))
            {
                var category = new Category();
                category.Name = "Interest";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Winnings"))
            {
                var category = new Category();
                category.Name = "Winnings";
                context.Categories.Add(category);
            }
            if (!context.Categories.Any(c => c.Name == "Other"))
            {
                var category = new Category();
                category.Name = "Other";
                context.Categories.Add(category);
            }
            
        }
    }
}
