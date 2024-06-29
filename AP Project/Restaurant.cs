using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    class Restaurant : BaseUser
    {
        public Restaurant(string username, string password) : base(username, password)
        {
        }

        public string Name { get; set; } = "";
    }
}
