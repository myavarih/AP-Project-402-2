using AP_Project.Front.Admin_Window;
using AP_Project.Front.Restaurant_Window;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void UserSignUpBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUp());
            // totest
            Data.CurrentUser = new User("000Ali000", "Abcd1234", "alimozdian@gmail.com", "Ali", "Mozdian", "09903322694");
            Data.AddCurrentUser();
            Data.CurrentUser = null;
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            BaseUser buser = null;
            try
            {
                buser = Validation.PasswordMatch(UsernameTxtBx.Text, PasswordTxtBx.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (buser is User)
            {
                Data.CurrentUser = (User)buser;
                var userWindow = new UserWindow();
                userWindow.Show();
                Application.Current.Windows[0].Close();
            }
            else if (buser is Restaurant)
            {
                Data.CurrentRestaurant = (Restaurant)buser; 
                var restaurantWindow = new RestaurantWindow();
                restaurantWindow.Show();
                Application.Current.Windows[0].Close();
            }
            else if (buser is Admin)
            {
                Data.CurrentAdmin = (Admin)buser;
                var adminWindow = new AdminWindow();
                adminWindow.Show();
                Application.Current.Windows[0].Close();
            }
        }

        private void ChangePasswordBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangePassword());
            // totest
            Data.CurrentRestaurant = new Restaurant("TestRest", "Passw0rd", "Toranj", "Tehran", "TehranVila, Sohrab Street", true, true);
            Data.AddCurrentRestaurants();
            Data.CurrentRestaurant = null;
        }
    }
}
