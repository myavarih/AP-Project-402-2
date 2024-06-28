using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    abstract class BaseUser(string username, string password)
    {
        public int Id { get; set; } = GenerateUniqueId(); // Auto Generated & unique
        public string Username { get; set; } = username;
        public string Password { get; set; } = password;

        private static int GenerateUniqueId()
        {
            // Ensure the Data class is fully initialized
            if (Data.Users == null || Data.Restaurants == null || Data.Admins == null)
            {
                throw new InvalidOperationException("Data class is not fully initialized.");
            }

            return Data.Users.Count + Data.Restaurants.Count + Data.Admins.Count + 1;
        }
    }
}
