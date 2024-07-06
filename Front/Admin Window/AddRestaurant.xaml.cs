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

namespace AP_Project.Front.Admin_Window
{
    /// <summary>
    /// Interaction logic for AddRestaurant.xaml
    /// </summary>
    public partial class AddRestaurant : Page
    {
        Restaurant newRestaurant = new Restaurant("", Validation.RestaurantPasswordGenerator(), "", "", "", true, true);
        public AddRestaurant()
        {
            InitializeComponent();
            DataContext = newRestaurant;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validation.RestaurantCreationFieldsCheck(newRestaurant);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Data.AddRestaurant(newRestaurant);
            Data.Database.Restaurants = Data.Database.Restaurants;
            Data.Database.SaveChanges();
            MessageBox.Show("The restaurant successfully created.");
            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
