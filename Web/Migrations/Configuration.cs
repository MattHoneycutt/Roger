using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Web.Data;
using Web.Models;

namespace Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Web.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Web.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
           
            //

            var userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };

            string name = "roger@example.com";
            string password = "password";
            var user = userManager.FindByName(name);

            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true };
                userManager.Create(user, password);
            }
            var rogerId = user.Id;

            name = "maria@example.com";
            user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, EmailConfirmed = true };
                userManager.Create(user, password);
            }

            var mariaId = user.Id;

            context.Meetings.AddOrUpdate(m=>m.Title,
                new Meeting { Title="FirstMeeting", Start=DateTime.Parse("4/22/2016 8:00 AM"), InstructorId = rogerId});

            context.Meetings.AddOrUpdate(m => m.Title,
                new Meeting { Title = "SecondMeeting", Start = DateTime.Parse("4/23/2016 9:00 AM"), InstructorId = rogerId });

            context.Meetings.AddOrUpdate(m => m.Title,
                new Meeting { Title = "ThirdMeeting", Start = DateTime.Parse("4/24/2016 10:00 AM"), InstructorId = rogerId });


            context.Meetings.AddOrUpdate(m => m.Title,
                new Meeting { Title = "FourthMeeting", Start = DateTime.Parse("4/23/2016 11:00 AM"), InstructorId = mariaId });

            context.Meetings.AddOrUpdate(m => m.Title,
                new Meeting { Title = "FifthMeeting", Start = DateTime.Parse("4/24/2016 12:00 PM"), InstructorId = mariaId });

            context.Meetings.AddOrUpdate(m => m.Title,
                new Meeting { Title = "SixthMeeting", Start = DateTime.Parse("4/25/2016 1:00 PM"), InstructorId = mariaId });
        }
    }
}
 