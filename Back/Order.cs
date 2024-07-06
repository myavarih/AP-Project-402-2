// Ignore Spelling: Online

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
        public double TotalCost { get { return Cart.Select(x => x.Count * x.Price).Sum(); } }
        public double? Rating {  get; set; }
        public bool IsOnlinePaying {  get; set; }
        public DateTime TimeCreated { get; set; }
        [Key]
        public int Code { get
            {
                DateTimeOffset dtos = new DateTimeOffset(TimeCreated);
                return (int)dtos.ToUnixTimeSeconds();
            }
            set
            {

            }
        }
        public Order(string userUsername, string restaurantUsername, DateTime timeCreated)
        {
            UserUsername = userUsername;
            RestaurantUsername = restaurantUsername;
            TimeCreated = timeCreated;
            Cart = new List<Food>();
            Rating = null;
            IsOnlinePaying = false; // default -> change it in PaymentPage
            Comment = "";
        }
        public string Comment { get; set; }
        public string UserPhoneNumber { get 
            {
                return Data.GetUserByUsername(UserUsername).PhoneNumber;
            } }
    }
}
