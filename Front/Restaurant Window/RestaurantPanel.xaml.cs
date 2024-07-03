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
    /// Interaction logic for RestaurantPanel.xaml
    /// </summary>
    public partial class RestaurantPanel : Page
    {
        public RestaurantPanel()
        {
            InitializeComponent();
        }

        private void ChangeMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditMenu());
        }

        private void ChangeFoodInventory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangeFoodInventory());  
        }

        private void ReserveService_Click(object sender, RoutedEventArgs e) // The button should depend on reserve state
        {

        }

        private void OrderReserveHIstory_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
