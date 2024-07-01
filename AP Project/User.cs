using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    enum Gender { Male, Female}
    class User : BaseUser
    {
        public User(string username, string password, string email, string firstName, string lastName, string phoneNumber) : base(username, password)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public User(string username, string password, string email, string firstName, string lastName, string phoneNumber, string address, Gender? gender) : base(username, password)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
        }

        public string Email { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Address { get; set; } = null; // not essential
        public Gender? Gender { get; set; } = null; // not essential
    }
}
