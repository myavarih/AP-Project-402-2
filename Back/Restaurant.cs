using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    class Restaurant : BaseUser
    {
        public Restaurant(string username, string password, string name, string city, string address, bool dineIn, bool delivery, double totalRate, List<Food> foods, List<Order> orders) : base(username, password)
        {
            Name = name;
            City = city;
            Address = address;
            DineIn = dineIn;
            Delivery = delivery;
            TotalRate = totalRate;
            Foods = foods;
            Orders = orders;
        }

        public string Name { get; set; } = "";
        public string City { get; set; } = "";
        public string Address { get; set; } = "";
        public bool DineIn { get; set; }
        public bool Delivery {  get; set; }
        public string ServingMode { get
            {
                if (DineIn && Delivery)
                    return "Dine-in and Delivery";
                else if (DineIn)
                    return "Dine-in";
                else
                    return "Delivery";
            } }
        public double TotalRate { get; set; }
        public List<Food> Foods { get; set; } = new List<Food>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<string> Categories { get; set; } = new List<string>();
    }
}
