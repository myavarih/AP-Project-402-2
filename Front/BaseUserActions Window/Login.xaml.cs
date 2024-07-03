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
                Data.SetCurrentUser((User)buser);
                var userWindow = new UserWindow();
                userWindow.Show();
                Application.Current.Windows[0].Close();
            }
            else if (buser is Restaurant)
            {
                // todo
            }
            else if (buser is Admin)
            {
                // todo
            }
        }

        private void ChangePasswordBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangePassword());
        }
    }
}
