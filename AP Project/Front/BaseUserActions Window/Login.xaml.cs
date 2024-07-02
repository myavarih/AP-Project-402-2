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
            Application.Current.Windows[0].Title = "Sign Up";
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            //Data.Database.Users.Add(new("aaa", "aaaaAAAA1", "myavarih@gmail.com", "Moh", "Yav", "09036090960"));
            //Data.Database.SaveChanges();
            //dynamic bUser = null;
            //try
            //{
            //    bUser = Validation.PasswordMatch(UsernameTxtBx.Text, PasswordTxtBx.Text);
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); return; }
            //if ((bUser = bUser as User) != null)
            //{
            //    Data.SetCurrentUser(bUser);
            //    var userWindow = new UserWindow();
            //    userWindow.Show();
            //    Application.Current.Windows[0].Close();
            //}
            //else if ((bUser = bUser as Restaurant) != null)
            //{
            //    // to be continued!
            //}
            //else if ((bUser = bUser as Admin) != null)
            //{
            //    // to be continued!
            //}

            var userWindow = new UserWindow();
            userWindow.Show();
            Application.Current.Windows[0].Close();
        }

        private void ChangePasswordBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangePassword());
        }
    }
}
