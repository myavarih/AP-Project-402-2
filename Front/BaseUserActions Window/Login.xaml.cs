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
            Data.BaseUsers = Data.Database.Users.ToList().Select(x => (BaseUser)x).Concat(Data.Database.Restaurants.ToList().Select(x => (BaseUser)x)).Concat(Data.Database.Admins.ToList().Select(x => (BaseUser)x)).ToList();
            if (!Data.BaseUsers.Any(x => x.Username == "Admin"))
            {
                // first time adding admin
                Data.AddAdmin(new Admin("Admin", "Aa123456"));
                Data.Database.Admins = Data.Database.Admins;
                Data.Database.SaveChanges();
            } 
        }

        private void UserSignUpBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUp());
            Data.Database.SaveChanges();
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
                Data.Database.SaveChanges();
            }
            else if (buser is Restaurant)
            {
                Data.CurrentRestaurant = (Restaurant)buser; 
                var restaurantWindow = new RestaurantWindow();
                restaurantWindow.Show();
                Application.Current.Windows[0].Close();
                Data.Database.SaveChanges();
            }
            else if (buser is Admin)
            {
                Data.CurrentAdmin = (Admin)buser;
                var adminWindow = new AdminWindow();
                adminWindow.Show();
                Application.Current.Windows[0].Close();
                Data.Database.SaveChanges();
            }
        }

        private void ChangePasswordBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangePassword());
            Data.Database.SaveChanges();
        }
    }
}
