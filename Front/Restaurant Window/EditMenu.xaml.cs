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
            DataContext = Data.CurrentRestaurant;
        }

        private void AddFood_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddFood()); // done
        }
        private void RemoveFood_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string foodName = button.Tag.ToString();
            Food food = Data.CurrentRestaurant.GetFoodByName(foodName);
            if (food == null)
            {
                MessageBox.Show("There is no such a food! Weird!");
                return;
            }
            Data.CurrentRestaurant.Foods.Remove(food);
            // MessageBox.Show($"{food.Name} removed.");
            DataContext = null;
            DataContext = Data.CurrentRestaurant;
        }

        private void EditCategories_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditCategory()); // done
        }
        private void EditFood_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string foodName = button.Tag.ToString();
            Food food = Data.CurrentRestaurant.GetFoodByName(foodName);
            if (food == null)
            {
                MessageBox.Show("There is no such a food! Weird!");
                return;
            }
            NavigationService.Navigate(new EditFood(food.Name)); // give me the food somehow for the next page (done)
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
