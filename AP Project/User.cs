using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    class User(string username, string password, string email, string firstName, string lastName, int phoneNumber) : BaseUser(username, password)
    {
        public string Email { get; set; } = email;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public int PhoneNumber { get; set; } = phoneNumber;
    }
}
