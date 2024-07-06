using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AP_Project.Front.Restaurant_Window
{
    /// <summary>
    /// Interaction logic for OrderReserveHistory.xaml
    /// </summary>
    public partial class OrderReserveHistory : Page
    {
        ViewModelForOrderReserveHistory vm = new ViewModelForOrderReserveHistory();
        public OrderReserveHistory()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void GetReportButton_Click(object sender, RoutedEventArgs e)
        {
            // todo : csv
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameFilterTextBox.Text;
            if (username == null || username == "") { username = ".*"; }
            Regex usernameRegex = new Regex("^" + username, RegexOptions.IgnoreCase);
            string phone= PhoneNumberFilterTextBox.Text;
            if (phone == null || phone == "") { phone = ".*"; }
            Regex phoneRegex = new Regex("^" + phone, RegexOptions.IgnoreCase);
            string foodName = FoodFilterTextBox.Text;
            if (foodName == null || foodName == "") { foodName = ".*"; }
            Regex foodNameRegex = new Regex("^" + foodName, RegexOptions.IgnoreCase);
            double minPrice;
            if (MinPriceFilterTextBox.Text == "") { minPrice = 0; }
            else if (!double.TryParse(MinPriceFilterTextBox.Text, out minPrice) || minPrice < 0)
            {
                MessageBox.Show("Min Price must be a non-negative number (double)!");
                return;
            }
            double maxPrice;
            if (MaxPriceFilterTextBox.Text == "") { maxPrice = double.MaxValue; }
            else if (!double.TryParse(MaxPriceFilterTextBox.Text, out maxPrice) || maxPrice < 0)
            {
                MessageBox.Show("Max Prcie must be a non-negative number (double)!");
                return;
            }
            vm.FilteredOrders = new ObservableCollection<Order>(Data.CurrentRestaurant.Orders.Where(x => usernameRegex.IsMatch(x.UserUsername) &&
                phoneRegex.IsMatch((Data.GetUserByUsername(x.UserUsername) ?? new User("", "", "", "", "", "")).PhoneNumber) &&
                x.Cart.Any(food => foodNameRegex.IsMatch(food.Name)) &&
                x.TotalCost >= minPrice && x.TotalCost <= maxPrice));
            DataContext = null;
            DataContext = vm;
        }
    }
}
