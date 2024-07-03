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
        public UserProfilePage()
        {
            InitializeComponent();
            if (Data.CurrentUser.SpecialServices != null)
                ServiceComboBox.SelectedIndex = (int)Data.CurrentUser.SpecialServices;
            this.DataContext = Data.CurrentUser;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation.EmailRegex.IsMatch(Data.CurrentUser.Email))
            {
                MessageBox.Show("Wrong Email Format!");
                return;
            }
            if (ServiceComboBox.SelectedIndex == 3)
            {
                Data.CurrentUser.SpecialServices = null;
            }
            else
            {
                Data.CurrentUser.SpecialServices = (SpecialServices?)ServiceComboBox.SelectedIndex;
            }
            NavigationService.GoBack();

        }
    }
}
