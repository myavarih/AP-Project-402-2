// Ignore Spelling: Admins

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    static class Data
    {
         // public static Database Database { get; set; } = new Database();
        
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public static List<Admin> Admins { get; set; } = new List<Admin>();


        public static User CurrentUser { get; set; } = null;
        public static Restaurant CurrentRestaurant { get; set; } = null;
        public static Admin CurrentAdmin { get; set; } = null;

        public static void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }
        public static void UpdateCUFields(string address, string email) // only used when we have a current user
        {
            User u = Users.First(u => u.Username == CurrentUser.Username);
            u.Email = email;
            u.Address = address;
        }
    }
}
