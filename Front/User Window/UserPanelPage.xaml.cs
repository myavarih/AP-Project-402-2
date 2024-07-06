using AP_Project.Front.User_Window;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            Title.Text = "Welcome " + Data.CurrentUser.FirstName;
        }

        private void Complaints_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserComplaints());
        }

        private void OrderHistory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderHistoryPage());
        }

        private void SearchRestaurants_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchResaurants());
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserProfilePage());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Data.CurrentUser = null;
            var mw = new MainWindow();
            mw.Show();
            Application.Current.Windows[0].Close();
            Data.Database.SaveChanges();
        }
    }
}
