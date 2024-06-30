using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    internal class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var users = new List<User> { new User("aaa", "aaaaAAAA12", "myavarih@gmail.com", "Moh", "Yav", "09036090960") };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }
    }
}
