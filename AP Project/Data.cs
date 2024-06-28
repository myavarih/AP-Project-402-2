// Ignore Spelling: Admins

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    static class Data
    {
        public static List<User> Users { get; set; } = [];
        public static List<Restaurant> Restaurants { get; set; }
        public static List<Admin> Admins { get; set; }
        static Data()
        {
            Users = new List<User> { new User("aaa", "aaa", "aaa", "a", "b", 123) };
            Restaurants = [];
            Admins = [];
        }
    }
}
