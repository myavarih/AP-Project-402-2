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

namespace AP_Project.Front.Restaurant_Window
{
    /// <summary>
    /// Interaction logic for OrderReserveHistory.xaml
    /// </summary>
    public partial class OrderReserveHistory : Page
    {
        public OrderReserveHistory()
        {
            InitializeComponent();
            DataContext = Data.CurrentRestaurant;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetReportButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
