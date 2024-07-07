using AP_Project.Back;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AP_Project
{
    class Food
    {
        public Food(string name, string ingredients, BitmapImage imageName, double price, string category, string restaurantUsername, int count)
        {
            Name = name;
            Ingredients = ingredients;
            ImageName = imageName;
            Price = price;
            Category = category;
            RestaurantUsername = restaurantUsername;
            Count = count;
        }
        [Key]
        public string key { get
            {
                return Name + RestaurantUsername;
            }
            set
            {

            }
        }
        public string Name { get; set; } = ""; // Should be Unique (in the scale of a restaurant)
        public string Ingredients { get; set; } = "";
        public BitmapImage ImageName { get; set; } // calculate after Database Load
        public double Price {  get; set; }
        public string Category { get; set; } = "";
        public double? Rating { get
            {
                if (Scores.Any()) return Scores.Average(x => x.Score);
                return null;
            }
        }
        public List<ScoreForFood> Scores { get; set; } = new List<ScoreForFood>();
        public string RestaurantUsername { get; set; } = "";
        public int Count { get; set; }
        public List<CommentForFood> Comments { get; set; } = new List<CommentForFood>();

        public CommentForFood GetCommentByCode(int code)
        {
            return Comments.FirstOrDefault(x => x.Code == code);
        }

        public static Food DeepCopy(Food food)
        {
            // for adding to the cart of an Order
            if (food == null)
            {
                return null;
            }
            Food newFood = new Food(food.Name, food.Ingredients, food.ImageName, food.Price, food.Category, food.RestaurantUsername, food.Count);
            return newFood;
        }
    }
}
