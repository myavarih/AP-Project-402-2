using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back
{
    class ViewModelForRestaurantViewPage
    {
        public ViewModelForRestaurantViewPage(string restaurantUsername)
        {
            Categories = Data.GetRestaurantByUsername(restaurantUsername).Categories.Select(x => x).ToList();
            Foods = Data.GetRestaurantByUsername(restaurantUsername).Foods.Select(x => x).ToList();
        }

        public List<Food> Foods {  get; set; }
        public List<string> Categories { get; set; }
    }
}
