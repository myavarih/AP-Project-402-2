using AP_Project.Back;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public string Name { get; set; } = ""; // Should be Unique (in the scale of a restaurant)
        public string Ingredients { get; set; } = "";
        [JsonIgnore]
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

        public string ImageBase64
        {
            get => ConvertBitmapImageToBase64(ImageName);
            set => ImageName = ConvertBase64ToBitmapImage(value);
        }

        private string ConvertBitmapImageToBase64(BitmapImage bitmapImage)
        {
            if (bitmapImage == null) return null;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        private BitmapImage ConvertBase64ToBitmapImage(string base64String)
        {
            if (string.IsNullOrEmpty(base64String)) return null;

            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
    }
}
