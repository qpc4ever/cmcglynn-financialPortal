﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using cmcglynn_financialPortal.Models.CodeFirst;
using System.Collections.Generic;

namespace cmcglynn_financialPortal.Models
{

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }                              // ADD "FIRSTNAME" AND "LASTNAME"
        public string LastName { get; set; }
        public string ProfilePic { get; set; }                            // ADD ALL "NAME" LINES OF CODE FIRST EVERY PROJECT
        public string TimeZone { get; set; }
        public int? HouseHoldId { get; set; }


        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ApplicationUser()
        {
            Transactions = new HashSet<Transactions>();
            Notifications = new HashSet<Notifications>();
        }

      
        public virtual HouseHold HouseHold { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("HouseHoldId", HouseHoldId.ToString()));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<CodeFirst.HouseHold> HouseHold { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Budgets> Budgets { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Frequency> Frequency { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<BudgetType> BudgetType { get; set; }

    }
}