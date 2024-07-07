using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace AP_Project
{
    class Restaurant : BaseUser
    {
        public Restaurant(string username, string password, string name, string city, string address, bool dineIn, bool delivery, double? totalRate = null, List<Food> foods = null, List<Order> orders = null, List<string> categories = null) : base(username, password)
        {
            // username is unique (because of BaseUser and other identifications in the program (code)
            Name = name; // unique -> just because of User Complaints
            City = city;
            Address = address;
            DineIn = dineIn;
            Delivery = delivery;
            // todo: Remove totalRate
            if (foods == null) foods = new List<Food>();
            if (orders == null) orders = new List<Order>();
            if (categories == null) categories = new List<string>() { "All" };
            Foods = foods;
            Orders = orders;
            Categories = categories;
        }

        public Restaurant() : base()
        {
        }

        public string Name { get; set; } = "";
        public string City { get; set; } = "";
        public string Address { get; set; } = "";
        public bool DineIn { get; set; }
        public bool Delivery { get; set; }
        public string ServingMode
        {
            get
            {
                if (DineIn && Delivery)
                    return "Dine-in and Delivery";
                else if (DineIn)
                    return "Dine-in";
                else
                    return "Delivery";
            }
        }
        public double? TotalRate
        { 
            get
            {
                return Orders.Select(x => x.Rating).Concat(Foods.Select(x => x.Scores.Sum(x => x.Score))).Where(x => x != null).Average();
            }
        }
        public List<Food> Foods { get; set; } = new List<Food>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<string> Categories { get; set; } = new List<string>();

        public Food GetFoodByName(string name)
        {
            return Foods.FirstOrDefault(x => x.Name == name);
        }
    }
}
