using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            order.IsOnlinePaying = OnlinePaymentRadioButton.IsChecked == true;
            if (order.IsOnlinePaying)
            {
                string orderCart = string.Join('\n', order.Cart.Select(x => "\t" + x.Name + $" (x{x.Count})"));
                string message = "Your online order is finalized.\n" +
                    $"Code: {order.Code}\n" +
                    $"your Username: {order.UserUsername}\n" +
                    $"Restaurant Name: {order.RestaurantName}\n" +
                    $"Cart:\n{orderCart}\n" +
                    $"Total Cost: {order.TotalCost}\n" +
                    $"Time: {order.TimeCreated}\n" +
                    "Payment Methode: Online :)";
                try // send Email
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("ap.project.restaurantapp@gmail.com");
                    mail.To.Add(Data.CurrentUser.Email);
                    mail.Subject = "Online Payment Receipt";
                    mail.Body = message;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = false;
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("ap.project.restaurantapp@gmail.com", "cvkj hhou ygnm ylcp");
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                }
                catch
                {
                    MessageBox.Show("Failed To Send Email!");
                    return;
                }
            }
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
