using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AP_Project
{
    static class Validation
    {
        public static BaseUser PasswordMatch(string username,  string password) // May Return Exceptions 
        {
            BaseUser bUser;
            bUser = Data.Users.First(u => u.Username == username);
            if (bUser == null)
            {
                bUser = Data.Restaurants.First(u => u.Username == username);
                if(bUser == null)
                {
                    bUser = Data.Admins.First(u => u.Username == username);
                    if (bUser == null)
                        throw new Exception("No User Found With This Username");
                }
            }
            if (bUser.Password != password)
                throw new Exception("Wrong Password!");
            return bUser;
        }
        public static void CheckForEmptyFields(params string[] fields)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                string field = fields[i];
                if (string.IsNullOrEmpty(field))
                    throw new Exception("field " + (i + 1)   + " is Empty");
            }
        }
        public static int PhoneAndUserCheck(string PhoneNumber, string Username)
        {
            int phoneNumber;
            if (!int.TryParse(PhoneNumber, out phoneNumber))
                throw new Exception("Invalid Phone Number!");
            if (Data.Users.Exists(u => u.Username == Username))
                throw new Exception("Username ALready Used!");
            if (Data.Users.Exists(u => u.PhoneNumber == phoneNumber))
                throw new Exception("Phone Number Already Used!");
            return phoneNumber;
        }
        public static void UserSignUpFieldsCheck(string firstName, string lastName, string phoneNumber, string username, string email)
        {
            string NamesPattern = @"^[A-Za-z]{3,32}$";
            Regex NamesRegex = new Regex(NamesPattern);
            string PhoneNumberPattern = @"^09\d{9}$";
            Regex PhoneNumberRegex = new Regex(PhoneNumberPattern);
            string EmailPattern = @"^[A-Za-z]{3,32}@[A-Za-z]{3,32}\.[A-Za-z]{2,3}$";
            Regex EmailRegex = new Regex(EmailPattern);
        }
    }
}
