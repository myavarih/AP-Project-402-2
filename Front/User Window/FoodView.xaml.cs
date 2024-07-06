using Microsoft.Extensions.Logging.Abstractions;
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

namespace AP_Project.Front.User_Window
{
    /// <summary>
    /// Interaction logic for FoodView.xaml
    /// </summary>
    public partial class FoodView : Page
    {
        Food food;
        public FoodView(string restaurantUsername, string foodName)
        {
            InitializeComponent();
            Restaurant restaurant = Data.GetRestaurantByUsername(restaurantUsername);
            if (restaurant == null)
            {
                MessageBox.Show("There is no such a Restaurant!");
                return;
            }
            food = restaurant.GetFoodByName(foodName);
            if (food == null)
            {
                MessageBox.Show("There is no such a Food!");
                return;
            }
        }

        private void CommentSubmit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubmitRatingBtn_Click(object sender, RoutedEventArgs e)
        {
            // todo
        }
    }
}
