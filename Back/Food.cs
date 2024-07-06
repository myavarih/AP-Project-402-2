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
        public Food()
        {
        }

        public Food(string name, string ingredients, BitmapImage imageName, double price, string category, double? rating, string restaurantUsername, int count)
        {
            Name = name;
            Ingredients = ingredients;
            ImageName = imageName;
            Price = price;
            Category = category;
            Rating = rating;
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
        public string ImagePath { get; set; }
        [NotMapped]
        public BitmapImage ImageName { get; set; } // calculate after Database Load
        public double Price {  get; set; }
        public string Category { get; set; } = "";
        public double? Rating { get; set; }
        public string RestaurantUsername { get; set; } = "";
        public int Count {  get; set; }
        public List<CommentForFood> CommentsForFood { get; set; } = new List<CommentForFood>();

        public static Food DeepCopy(Food food)
        {
            if (food == null)
            {
                return null;
            }
            Food newFood = new Food(food.Name, food.Ingredients, food.ImageName, food.Price, food.Category, food.Rating, food.RestaurantUsername, food.Count);
            return newFood;
        }
    }
}
