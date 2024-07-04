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
        
        public static List<BaseUser> BaseUsers { get; set; } = new List<BaseUser>();
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public static List<Admin> Admins { get; set; } = new List<Admin>();


        public static User CurrentUser { get; set; } = null;
        public static Restaurant CurrentRestaurant { get; set; } = null;
        public static Admin CurrentAdmin { get; set; } = null;


        public static void UpdateCUFields(string address, string email) // only used when we have a current user
        {
            if (CurrentUser == null)
            {
                throw new Exception("No current user!");
            }
            // validation
            CurrentUser.Address = address;
            CurrentUser.Email = email;
        }

        public static void AddCurrentUser()
        {
            Users.Add(CurrentUser);
            BaseUsers.Add(CurrentUser);
        }

        public static void AddCurrentRestaurants()
        {
            Restaurants.Add(CurrentRestaurant);
            BaseUsers.Add(CurrentUser);
        }

        public static void AddCurrentAdmin()
        {
            Admins.Add(CurrentAdmin);
            BaseUsers.Add(CurrentAdmin);
        }

        public static BaseUser GetBaseUserByUsername(string username)
        {
            return BaseUsers.FirstOrDefault(x => x.Username == username);
        }
        public static User GetUserByUsername(string username)
        {
            return Users.FirstOrDefault(x => x.Username == username);
        }
        public static Restaurant GetRestaurantByUsername(string username)
        {
            return Restaurants.FirstOrDefault(x => x.Username == username);
        }
        public static Admin GetAdminByUsername(string username)
        {
            return Admins.FirstOrDefault(x => x.Username == username);
        }
    }
}
