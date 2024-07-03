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
    /// Interaction logic for EditMenu.xaml
    /// </summary>
    public partial class EditMenu : Page
    {
        public EditMenu()
        {
            InitializeComponent();
        }

        private void AddFood_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddFood());
        }

        private void EditCategories_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditCategory());
        }
        private void EditFood_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditFood());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
