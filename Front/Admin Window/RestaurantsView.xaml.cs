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

namespace AP_Project.Front.Admin_Window
{
    /// <summary>
    /// Interaction logic for RestaurantsView.xaml
    /// </summary>
    public partial class RestaurantsView : Page
    {
        public RestaurantsView()
        {
            InitializeComponent();
            RestaurantsListView.ItemsSource = Data.Database.Restaurants.ToList();
        }

        private void ApplyFiltersButton_Click(object sender, RoutedEventArgs e) // Bug : When we click on Apply Filter All Restaurants are gone!
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
            var filteredRestaurants = Data.Database.Restaurants.ToList().Where(x => nameRegex.IsMatch(x.Name) && cityRegex.IsMatch(x.City) && x.TotalRate >= minRate);
            int indexComplaints = HasComplaintFilterComboBox.SelectedIndex;
            switch (indexComplaints)
            {
                case 0:
                    // No Filter
                    break;
                case 1:
                    // Has Unsolved Complaints
                    filteredRestaurants = filteredRestaurants.Where(r => Data.Database.Complaints.Any(c => c.RestaurantUsername == r.Username && !c.IsSolved));
                    break;
                case 2:
                    // Has Only Solved Complaints
                    filteredRestaurants = filteredRestaurants.Where(r => Data.Database.Complaints.Any(c => c.RestaurantUsername == r.Username) &&
                    !Data.Database.Complaints.Any(c => c.RestaurantUsername == r.Username && !c.IsSolved));
                    break;
                case 3:
                    // Has No Complaints
                    filteredRestaurants = filteredRestaurants.Where(r => !Data.Database.Complaints.Any(c => c.RestaurantUsername == r.Username));
                    break;
                default:
                    break;
            }
            RestaurantsListView.ItemsSource = filteredRestaurants.ToList();
            Data.Database.SaveChanges();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
