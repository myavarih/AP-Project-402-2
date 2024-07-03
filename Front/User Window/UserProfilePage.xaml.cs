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
            this.DataContext = Data.CurrentUser;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // validate email
            // binding?! how does it even work?
        }

        private void ApplyServiceUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // changing SpecialService of the Current user, with payment?
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
