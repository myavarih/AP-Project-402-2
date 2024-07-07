using AP_Project.Back;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.Media.Animation;

namespace AP_Project
{
    internal class CommentForFood
    {
        public CommentForFood(string text, string userUsername, string restaurantUsername, string foodName)
        {
            Text = text;
            UserUsername = userUsername;
            RestaurantUsername = restaurantUsername;
            FoodName = foodName;
            CreatedTime = DateTime.Now;
            IsEdited = false;
        }
        public int Code
        {
            get
            {
                DateTimeOffset dtos = new DateTimeOffset(CreatedTime);
                return (int)dtos.ToUnixTimeSeconds();
            }
        }
        public string Text { get; set; } = "";
        public string? Reply { get; set; } = null;
        public bool IsEdited { get; set; } = false;
        public string UserUsername { get; set; } = "";
        public string RestaurantUsername { get; set; } = "";
        public string FoodName { get; set; } = "";
        public DateTime CreatedTime { get; set; }
        public double? Rate { get 
            {
                ScoreForFood score = Data.GetRestaurantByUsername(RestaurantUsername).GetFoodByName(FoodName)
                    .Scores.FirstOrDefault(x => x.UserUsername == this.UserUsername);
                if (score != null) return score.Score;
                return null; // no rating yet
            } }
    }
}
