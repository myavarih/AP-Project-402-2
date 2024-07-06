using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AP_Project
{
    /// <summary>
    /// Interaction logic for SearchResaurants.xaml
    /// </summary>
    public partial class SearchResaurants : Page
    {  
        public SearchResaurants()
        {
            InitializeComponent();
            RestaurantsListView.ItemsSource = Data.Database.Restaurants;
        }

        private void ApplyFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameFilterTextBox.Text;
            if (name == null || name == "") { name = ".*"; }
            Regex nameRegex = new Regex("^" + name, RegexOptions.IgnoreCase);
            string city = CityFilterTextBox.Text;
            if (city == null || city == "") { city = ".*"; }
            Regex cityRegex = new Regex("^" + city, RegexOptions.IgnoreCase);
            double minRate;
            if (MinRateTextBox.Text == "")
            {
                minRate = 0;
            }
            else if (!double.TryParse(MinRateTextBox.Text, out minRate) || minRate < 0)
            {
                MessageBox.Show("The Min Rate Should Be A Non-negative Number (double)!");
                return;
            }
            string servingMode = ServingModeFilterComboBox.Text;
            var filteredRestaurants = Data.Database.Restaurants.Where(x => nameRegex.IsMatch(x.Name) && cityRegex.IsMatch(x.City) && x.TotalRate >= minRate);
            switch (servingMode)
            {
                case "Delivery":
                    filteredRestaurants = filteredRestaurants.Where(x => x.Delivery);
                    break;
                case "Dine-in":
                    filteredRestaurants = filteredRestaurants.Where(x => x.DineIn);
                    break;
                case "Dine-in and Delivery":
                    filteredRestaurants = filteredRestaurants.Where(x => x.Delivery && x.DineIn);
                    break;
                default:
                    // no filter
                    break;
            }
            RestaurantsListView.ItemsSource = filteredRestaurants;
            Data.Database.SaveChanges();

        }
        private void InfoButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new RestaurantViewPage((sender as Button).Tag.ToString()));
            Data.Database.SaveChanges(); Data.Database.SaveChanges();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            Data.Database.SaveChanges();
        }
    }
}
