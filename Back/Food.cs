using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project
{
    internal class Food
    {
        public string Name { get; set; } = "";
        public string Ingredients { get; set; } = "";
        public string ImageName { get; set; } = "";
        public double Price {  get; set; }
        public string Category { get; set; } = "";
        public double Rating { get; set; }
        public string RestaurantUsername { get; set; } = "";
        public int Count {  get; set; }
    }
}
