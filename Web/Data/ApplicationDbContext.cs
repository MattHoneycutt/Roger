﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Web.Models;

namespace Web.Data
{
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

        public DbSet<Meeting> Meetings { get; set; }
    }
}