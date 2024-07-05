using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back
{
    class ViewModelForRestaurantViewPage
    {
        public ViewModelForRestaurantViewPage(string restaurantUsername)
        {
            Categories = new ObservableCollection<string>(Data.GetRestaurantByUsername(restaurantUsername).Categories);
            Foods = new ObservableCollection<Food>(Data.GetRestaurantByUsername(restaurantUsername).Foods);
            RestaurantName = Data.GetRestaurantByUsername(restaurantUsername).Name;
        }

        public ObservableCollection<Food> Foods {  get; set; }
        public ObservableCollection<string> Categories { get; set; }
        public string RestaurantName { get; set; }
    }
}
