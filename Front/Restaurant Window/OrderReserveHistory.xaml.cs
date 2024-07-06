using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging.Abstractions;
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
        List<Order> filteredOrders;
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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.csv";
            bool? isAnyPathSelected = sfd.ShowDialog();
            if (isAnyPathSelected != true)
            {
                MessageBox.Show("Report Cancelled");
                return;
            }
            string path = sfd.FileName;
            StreamWriter sw = new StreamWriter(path);
            double totalSell = filteredOrders.Select(x => x.TotalCost).Sum();
            double onlinePaymentPercent = filteredOrders.Count(x => x.IsOnlinePaying) / filteredOrders.Count() * 100;
            int totalCountOfOrders = filteredOrders.Count();
            sw.WriteLine("Total Sell,Online Payment Percentage,Total Orders");
            sw.WriteLine($"{totalSell},{onlinePaymentPercent},{totalCountOfOrders}");
            sw.WriteLine();
            sw.WriteLine("Order Code,User's Username,User Phone Number,Cart,Total Cost");
            string orderCart;
            foreach (var order in filteredOrders)
            { 
                orderCart = string.Join(" - ", order.Cart.Select(x => x.Name + $" (x{x.Count})"));
                sw.WriteLine($"{order.Code},{order.UserUsername},{order.UserPhoneNumber},{orderCart},{order.TotalCost}");
            }
            sw.Close();
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
            filteredOrders = Data.CurrentRestaurant.Orders.Where(x => usernameRegex.IsMatch(x.UserUsername) &&
                phoneRegex.IsMatch((Data.GetUserByUsername(x.UserUsername) ?? new User("", "", "", "", "", "")).PhoneNumber) &&
                x.Cart.Any(food => foodNameRegex.IsMatch(food.Name)) &&
                x.TotalCost >= minPrice && x.TotalCost <= maxPrice).ToList();
            vm.FilteredOrders = new ObservableCollection<Order>(filteredOrders);
            DataContext = null;
            DataContext = vm;
        }
    }
}
