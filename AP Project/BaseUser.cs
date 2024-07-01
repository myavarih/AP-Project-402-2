using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    abstract class BaseUser
    {
        [Key]
        public int Id { get; set; } = GenerateUniqueId(); // Auto Generated & unique
        public string Username { get; set; }
        public string Password { get; set; }

        public BaseUser(string username, string password)
        {
            Username = username;
            Password = password;
        }

        private static int GenerateUniqueId()
        {
            // Ensure the Data class is fully initialized
            if (Data.Database.Users == null || Data.Database.Restaurants == null || Data.Database.Admins == null)
            {
                throw new InvalidOperationException("Data class is not fully initialized.");
            }

            return Data.Database.Users.Count() + Data.Database.Restaurants.Count() + Data.Database.Admins.Count() + 1;
        }
    }
}
