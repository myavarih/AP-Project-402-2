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
        public static Database Database { get; set; } = new Database();
        //public static string CUFirstName { get; set; } = "wow"; // current user ...
        //public static string CULastName { get; set; } = "mow";
        //public static string CUEmail { get; set; } = "myavarihes@gmail.com";
        //public static string CUUsername { get; set; } = "moya";
        //public static string CUPassword { get; set; } = "mmmmMMMM1";
        //public static string CUPhoneNumber { get; set; } = "09036091960";
        //public static string CUAddress { get; set; } = "bla bla";
        //public static Gender? CUGender { get; set; } = Gender.Male;

        public static User CurrentUser { get; set; } = null;
        public static Restaurant CurrentRestaurant { get; set; } = null;
        public static Admin CurrentAdmin { get; set; } = null;

        public static void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }
        public static void UpdateCUFields(string address, string email) // only used when we have a current user
        {
            User u = Database.Users.First(u => u.Username == CurrentUser.Username);
            u.Email = email;
            u.Address = address;
        }
    }
}
