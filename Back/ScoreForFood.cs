using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back
{
    internal class ScoreForFood
    {
        public ScoreForFood(string userUsername, string restaurantUsername, string foodName, double? score)
        {
            UserUsername = userUsername;
            RestaurantUsername = restaurantUsername;
            FoodName = foodName;
            Score = score;
        }

        public string UserUsername { get; set; }
        public string RestaurantUsername { get; set; }
        public string FoodName { get; set; }
        public double? Score { get; set; }
    }
}
