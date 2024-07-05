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

namespace AP_Project.Front.Restaurant_Window
{
    /// <summary>
    /// Interaction logic for ChangeFoodInventory.xaml
    /// </summary>
    public partial class ChangeFoodInventory : Page
    {
        public ChangeFoodInventory()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) // validate inventory (Count) Inputted by user Before going Back (sakht nagir in rahat tare!) // todo : Ali
        {
            NavigationService.GoBack();
        }
    }
}
