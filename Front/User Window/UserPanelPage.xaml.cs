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
            //Title.Text = "Welcome " + Data.CurrentUser.FirstName;
        }

        private void Complaints_Click(object sender, RoutedEventArgs e)
        {
            // todo
        }

        private void OrderHistory_Click(object sender, RoutedEventArgs e)
        {
            // todo
        }

        private void SearchRestaurants_Click(object sender, RoutedEventArgs e)
        {
            Data.Restaurants.Add(new Restaurant(
                username: "user1",
                password: "pass1",
                name: "The Gourmet Spot",
                city: "Tehran",
                address: "123 Delicious Avenue",
                dineIn: true,
                delivery: true,
                totalRate: 4.7,
                foods: new List<Food>
                {
                    new Food { Name = "Pasta", Price = 8.5 },
                    new Food { Name = "Salad", Price = 4.5 }
                },
                orders: new List<Order>()
                ));
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
        }
    }
}
