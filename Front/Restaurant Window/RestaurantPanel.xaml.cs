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
            DataContext = Data.CurrentRestaurant;
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
            // todo: RESERVE
        }

        private void OrderReserveHIstory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderReserveHistory());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Data.CurrentRestaurant = null;
            var mw = new MainWindow();
            mw.Show();
            Application.Current.Windows[0].Close();
        }
    }
}
