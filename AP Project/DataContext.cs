using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AP_Project
{
    internal class DataContext :DbContext
    {
        public DataContext() : base("name=DataContext")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Admin> Admins { get; set; }    

    }
}
