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
        public PaymentPage(long orderCode)
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
            // remember to substract the count of each food from the restaurants Foods list
        }
    }
}
