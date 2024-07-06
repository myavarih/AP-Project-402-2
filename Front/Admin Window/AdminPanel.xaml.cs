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

namespace AP_Project.Front.Admin_Window
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();
            DataContext = Data.CurrentAdmin;
        }

        private void AddRestaurantButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRestaurant());
        }

        private void ViewRestaurantsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RestaurantsView());
        }

        private void ComplaintsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Data.CurrentAdmin = null;
            Application.Current.Windows[0].Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
