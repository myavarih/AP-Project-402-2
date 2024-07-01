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
using System.Windows.Shapes;

namespace AP_Project
{
    /// <summary>
    /// Interaction logic for PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        public PasswordWindow()
        {
            InitializeComponent();
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validation.PasswordWindowCheck(VerificationCodeTxtBx.Text, PasswordTxtBx.Text, ConfirmPasswordTxtBx.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Data.CurrentUser.Password = PasswordTxtBx.Text;
            Data.Database.Users.Add(new(Data.CurrentUser.Username, Data.CurrentUser.Password, Data.CurrentUser.Email, Data.CurrentUser.FirstName, Data.CurrentUser.LastName, Data.CurrentUser.PhoneNumber, Data.CurrentUser.Address, Data.CurrentUser.Gender));
        }
    }
}
