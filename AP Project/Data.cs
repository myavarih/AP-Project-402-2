// Ignore Spelling: Admins

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    class Data
    {
        public static List<User> Users = new List<User>();
        public static List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public static List<Admin> Admins { get; set; } = new List<Admin>();
        public static string CUFirstName { get; set; } = "";
        public static string CULastName { get; set; } = "";
        public static string CUEmail { get; set; } = "";
        public static string CUUsername { get; set; } = "";
        public static string CUPassword { get; set; } = "";
        public static string CUPhoneNumber { get; set; } = "";
        static Data()
        {
            Users = new List<User> { new User("aaa", "aaaaAAAA12", "myavarih@gmail.com", "Moh", "Yav", "09036090960") };
            Restaurants = [];
            Admins = [];
        }
        
    }
}
