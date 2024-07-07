using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AP_Project
{
    enum Gender { MALE, FEMALE}

    enum SpecialService { BRONZE, SILVER, GOLD} // null for none of them
    
    class User : BaseUser
    {
        public User() : base()
        {
        }

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
            SpecialService = null;
        }

        public string Email { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Address { get; set; } = null; // not essential
        public Gender? Gender { get; set; } = null; // not essential
        public SpecialService? SpecialService { get; set; } = null; // upgrade later (in profile)
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
