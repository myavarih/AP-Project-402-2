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

namespace AP_Project.Front.User_Window
{
    /// <summary>
    /// Interaction logic for PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        Order order;
        public PaymentPage(int orderCode)
        {
            InitializeComponent();
            order = Data.GetOrderByCode(orderCode);
            if (order == null)
            {
                throw new Exception("There is no order with this code!");
            }
            DataContext = order;
        }

        private void ConfirmPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            // remember to substract the count of each food from the restaurants Foods list (done)
            // todo: HERE
            User user = Data.GetUserByUsername(order.UserUsername);
            if (user == null)
            {
                throw new Exception("There is no user with this username!");
            }
            Restaurant restaurant = Data.GetRestaurantByUsername(order.RestaurantUsername);
            if (restaurant == null)
            {
                throw new Exception("There is no restaurant with this username!");
            }
            user.Orders.Add(order);
            restaurant.Orders.Add(order);
            foreach (var food in order.Cart)
            {
                Food restFood = restaurant.GetFoodByName(food.Name);
                if (restFood != null)
                {
                    if (food.Count > restFood.Count)
                    {
                        // the code must not reach here!
                        MessageBox.Show("You cannot order more than what is in the menu! (number!)");
                        food.Count = restFood.Count;
                    }
                    restFood.Count -= food.Count;
                }
            }
            order.IsOnlinePaying = OnlinePaymentRadioButton.IsChecked == true;
            if (order.IsOnlinePaying)
            {
                // todo: email
            }
            MessageBox.Show("Order Completed.");
            NavigationService.GoBack();
            NavigationService.GoBack();
            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
