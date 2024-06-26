using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
