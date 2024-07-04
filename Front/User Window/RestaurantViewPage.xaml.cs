using AP_Project.Front.User_Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for RestaurantViewPage.xaml
    /// </summary>
    public partial class RestaurantViewPage : Page
    {
        List<Food> foodList;
        string RestaurantUsername;

        public RestaurantViewPage(string restaurantUsername)
        {
            InitializeComponent();
            RestaurantUsername = restaurantUsername;
            DataContext = Data.GetRestaurantByUsername(restaurantUsername);
            foodList = Data.GetRestaurantByUsername(restaurantUsername).Foods.Select(x => x).ToList();
        }

        private void ApplyFilters(object sender, RoutedEventArgs e)
        {
            if (DropdownMenu.SelectedItem == "All")
            {
                foodList = Data.GetRestaurantByUsername(RestaurantUsername).Foods.Select(x => x).ToList();
            }
            foodList = foodList.Where(x => x.Category == (string)DropdownMenu.SelectedItem).ToList();
        }

        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void CommentRateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PaymentPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
