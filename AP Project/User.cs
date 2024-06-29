using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    class User(string username, string password, string email, string firstName, string lastName, string phoneNumber) : BaseUser(username, password)
    {
        public string Email { get; set; } = email;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string PhoneNumber { get; set; } = phoneNumber;
    }
}
