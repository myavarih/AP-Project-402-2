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
            if (Data.Users == null || Data.Restaurants == null || Data.Admins == null)
            {
                throw new InvalidOperationException("Data class is not fully initialized.");
            }

            return Data.Users.Count() + Data.Restaurants.Count() + Data.Admins.Count() + 1;
        }
    }
}
