// Ignore Spelling: Online

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    internal class Order
    {
        public string UserUsername { get; set; } = "";
        public string RestaurantUsername { get; set; } = "";
        public string RestaurantName { get
            {
                return Data.GetRestaurantByUsername(RestaurantUsername).Name;
            }
        }
        public List<Food> Cart { get; set; } = new List<Food>();
        public double TotalCost {  get; set; } // will be calculated
        public double? Rating {  get; set; }
        public bool IsOnlinePaying {  get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
