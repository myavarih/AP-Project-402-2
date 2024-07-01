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
    /// Interaction logic for UserPanelPage.xaml
    /// </summary>
    public partial class UserPanelPage : Page
    {
        public UserPanelPage()
        {
            InitializeComponent();
            //Title.Text = "Welcome " + Data.CurrentUser.FirstName;
        }

        private void Complaints_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderHistory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchRestaurants_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserProfilePage());
        }
    }
}
