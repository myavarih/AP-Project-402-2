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
    /// Interaction logic for OrderHistoryPage.xaml
    /// </summary>
    public partial class OrderHistoryPage : Page
    {
        public OrderHistoryPage()
        {
            InitializeComponent();
            DataContext = Data.CurrentUser;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)  // Validate Rating
        {
            // todo: validate (check) the value of Rating TextBoxes (if not between 0 and 5, MessageBox and return)
            // challenge: how to reach and read all the Rating TextBoxes?
            NavigationService.GoBack();
        }
    }
}
