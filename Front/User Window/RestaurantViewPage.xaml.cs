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
    /// Interaction logic for RestaurantViewPage.xaml
    /// </summary>
    public partial class RestaurantViewPage : Page
    {
        List<Food> foodList;

        public RestaurantViewPage(string restaurantUsername)
        {
            InitializeComponent();
            DataContext = Data.GetRestaurantByUsername(restaurantUsername);
            foodList = (List<Food>)(DataContext as Restaurant).Foods.Select(x => x);
        }

        private void ApplyFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            // todo (Ali)
            if (DropdownMenu.SelectedItem == "All")
            {
                foodList = (List<Food>)(DataContext as Restaurant).Foods.Select(x => x);
            }
            foodList = (List<Food>)foodList.Where(x => x.Category == (string)DropdownMenu.SelectedItem);
        }
    }
}
