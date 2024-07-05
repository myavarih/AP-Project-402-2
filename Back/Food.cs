using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    class Food
    {
        public Food(string name, string ingredients, string imageName, double price, string category, double rating, string restaurantUsername, int count)
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

        public string Name { get; set; } = ""; // Should be Unique (in the scale of a restaurant)
        public string Ingredients { get; set; } = "";
        public string ImageName { get; set; } = "";
        public double Price {  get; set; }
        public string Category { get; set; } = "";
        public double Rating { get; set; }
        public string RestaurantUsername { get; set; } = "";
        public int Count {  get; set; }

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
