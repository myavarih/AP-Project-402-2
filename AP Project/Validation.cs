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
        public static BaseUser PasswordMatch(string username, string password) // May Return Exceptions 
        {
            BaseUser bUser;
            bUser = Data.Users.First(u => u.Username == username);
            if (bUser == null)
            {
                bUser = Data.Restaurants.First(u => u.Username == username);
                if (bUser == null)
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
                    throw new Exception("field " + (i + 1) + " is Empty");
            }
        }
        public static void UserSignUpFieldsCheck(string firstName, string lastName, string phoneNumber, string username, string email)
        {
            string NamesPattern = @"^[A-Za-z]{3,32}$";
            Regex NamesRegex = new Regex(NamesPattern);
            string PhoneNumberPattern = @"^09\d{9}$";
            Regex PhoneNumberRegex = new Regex(PhoneNumberPattern);
            string EmailPattern = @"^[A-Za-z]{3,32}@[A-Za-z]{3,32}\.[A-Za-z]{2,3}$";
            Regex EmailRegex = new Regex(EmailPattern);
            string UsernamePattern = @"^(?=.*[A-Za-z]{3,})[A-Za-z0-9]+$";
            Regex UsernameRegex = new Regex(UsernamePattern);

            if (!NamesRegex.IsMatch(firstName))
                throw new Exception("First Name Format Error!");
            if (!NamesRegex.IsMatch(lastName))
                throw new Exception("Last Name Format Error!");
            if (!PhoneNumberRegex.IsMatch(phoneNumber))
                throw new Exception("Phone Number Format Error!");
            if (!UsernameRegex.IsMatch(username))
                throw new Exception("Username Format Error!");
            if (!EmailRegex.IsMatch(email))
                throw new Exception("Email Format Error");

            if (Data.Users.Exists(u => u.Username == username))
                throw new Exception("Username Already Used!");
            if (Data.Users.Exists(u => u.PhoneNumber == phoneNumber))
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
            string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,32}$";
            Regex PasswordRegex = new Regex(PasswordPattern);
            if (!PasswordRegex.IsMatch(Password))
                throw new Exception("Password Format Error!");
            if (vc != verificationCode)
                throw new Exception("Wrong Verification!");
            if (Repeat != Password)
                throw new Exception("Passwords Don't Match");
        }
    } 
}
