using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    abstract class BaseUser(string username, string password)
    {
        public int Id { get; set; } = Data.Users.Count + Data.Restaurants.Count + Data.Admins.Count + 1; // Auto Generated & unique
        public string Username { get; set; } = username;
        public string Password { get; set; } = password;
    }
}
