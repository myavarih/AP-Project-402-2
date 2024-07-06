using AP_Project.Back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.Media.Animation;

namespace AP_Project
{
    internal class CommentForFood
    {
        public string Text { get; set; } = "";
        public RestaurantComment? Reply { get; set; } = null;
        public bool IsEdited { get; set; } = false;
        public string UserUsername { get; set; } = "";
        public string RestaurantUsername { get; set; } = "";
        public string FoodName { get; set; } = "";
        public DateTime CreatedTime { get; set; }
        public int Code { get
            {
                DateTimeOffset dtos = new DateTimeOffset(CreatedTime);
                return (int)dtos.ToUnixTimeSeconds();
            } }
        public double? Rate { get 
            {
                ScoreForFood score = Data.GetRestaurantByUsername(RestaurantUsername).GetFoodByName(FoodName)
                    .Scores.FirstOrDefault(x => x.UserUsername == this.UserUsername);
                if (score != null) return score.Score;
                return null; // no rating yet
            } }
    }
}
