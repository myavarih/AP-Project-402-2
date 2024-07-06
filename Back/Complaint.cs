using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back
{
    class Complaint
    {
        public string Text { get; set; } = "";
        public string UserUsername { get; set; } = "";
        public string RestaurantUsername { get; set; } = "";
        public bool IsSolved { get; set; } = false;
    }
}
