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
    /// Interaction logic for UserProfileWindow.xaml
    /// </summary>
    public partial class UserProfilePage : Page
    {
        //User user = new User(Data.CurrentUser.Username, Data.CurrentUser.Password, Data.CurrentUser.Email, Data.CurrentUser.FirstName, Data.CurrentUser.LastName, Data.CurrentUser.PhoneNumber, Data.CurrentUser.Address, Data.CurrentUser.Gender);

        public UserProfilePage()
        {
            InitializeComponent();
            //this.DataContext = user;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Data.UpdateCUFields(user.Address, user.Email);
        }
    }
}
