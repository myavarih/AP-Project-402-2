// Ignore Spelling: Admins

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Project.Back;
using Microsoft.EntityFrameworkCore;

namespace AP_Project
{
    internal class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            optionsBuilder.UseSqlite(@"Data Source=" + currentPath + @"\DB.db");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Admin> Admins { get; set; }   
        public DbSet<Complaint> Complaints { get; set; }

    }
}
