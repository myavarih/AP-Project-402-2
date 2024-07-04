using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace AP_Project
{
    static class Validation
    {
        public static int verificationCode;
        public static Regex NamesRegex = new Regex(@"^[A-Za-z]{3,32}$");
        public static Regex PhoneNumberRegex = new Regex(@"^09\d{9}$");
        public static Regex EmailRegex = new Regex(@"^[A-Za-z]{3,32}@[A-Za-z]{3,32}\.[A-Za-z]{2,3}$");
        public static Regex UsernameRegex = new Regex(@"^(?=.*[A-Za-z]{3,})[A-Za-z0-9]+$");
        public static Regex PasswordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,32}$");

        public static BaseUser PasswordMatch(string username, string password) // May Return Exceptions 
        {
            BaseUser bUser = Data.GetBaseUserByUsername(username);
            if (bUser == null)
            {
                throw new Exception("No User Found With This Username");
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
                    throw new Exception("field " + (i + 1) + " is Empty");
            }
        }
        public static void UserSignUpFieldsCheck(User user)
        {
            if (!NamesRegex.IsMatch(user.FirstName))
                throw new Exception("First Name Format Error!");
            if (!NamesRegex.IsMatch(user.LastName))
                throw new Exception("Last Name Format Error!");
            if (!PhoneNumberRegex.IsMatch(user.PhoneNumber))
                throw new Exception("Phone Number Format Error!");
            if (!UsernameRegex.IsMatch(user.Username))
                throw new Exception("Username Format Error!");
            if (!EmailRegex.IsMatch(user.Email))
                throw new Exception("Email Format Error");

            if (Data.Users.Any(u => u.Username == user.Username))
                throw new Exception("Username Already Used!");
            if (Data.Users.Any(u => u.PhoneNumber == user.PhoneNumber))
                throw new Exception("Phone Number Already Used!");
        }
        public static string RestaurantPasswordGenerator()
        {
            string password = "";
            for (int i = 0; i < 8; i++)
            {
                password += new Random().Next() % 10;
            }
            return password;
        }
        public static void PasswordWindowCheck(string VerificationCode, string Password, string Repeat)
        {
            int vc;
            if (!int.TryParse(VerificationCode, out vc))
                throw new Exception("Verification Code Format Error!");
            if (vc != verificationCode)
                throw new Exception("Wrong Verification!");
            if (!PasswordRegex.IsMatch(Password))
                throw new Exception("Password Format Error!");
            if (Repeat != Password)
                throw new Exception("Passwords Don't Match");
        }

        public static void PasswordChange(string username, string password, string newPassword, string confirmPassword)
        {
            BaseUser bUser = Data.GetBaseUserByUsername(username);
            if (bUser == null)
            {
                throw new Exception("No User Found With This Username!");
            }
            if (bUser.Password != password)
            {
                throw new Exception("Wrong Password!");
            }
            if (!PasswordRegex.IsMatch(password))
            {
                throw new Exception("Password Format Error!");
            }
            if (newPassword != confirmPassword)
            {
                throw new Exception("Passwords Don't Match!");
            }
        }
    } 
}
