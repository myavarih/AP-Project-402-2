using System.Reflection.Emit;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void UserSignUpBtnClick(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic bUser = null;
            try
            {
                bUser = Validation.PasswordMatch(UsernameTxtBx.Text, PasswordTxtBx.Text);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            bUser = bUser as User;
            if (bUser == null)
            {
                bUser = bUser as Restaurant;
                if (bUser == null)
                    bUser = bUser as Admin;
            }
            MessageBox.Show(bUser.Username + " - " + bUser.FirstName);
        }
    }
}