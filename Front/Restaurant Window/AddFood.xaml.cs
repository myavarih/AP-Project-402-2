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
    /// Interaction logic for AddFood.xaml
    /// </summary>
    public partial class AddFood : Page
    {
        Food newFood = null;
        public AddFood()
        {
            InitializeComponent();
            newFood = new Food("", "", "", 0, "", null, Data.CurrentRestaurant.Username, 0);
            // count = 0, the restaurant should change it via Change Food Inventory
            DataContext = newFood;
        }

        private void AddFoodButton_Click(object sender, RoutedEventArgs e)
        {
            // todo: Image?!
            if (newFood.Price < 0)
            {
                MessageBox.Show("The price cannot be a negative number!");
                return;
            }
            if (Data.CurrentRestaurant.GetFoodByName(newFood.Name) != null)
            {
                MessageBox.Show("There is already a food with this name in this restaurant! Try another name!");
                return;
            }
            if (!Data.CurrentRestaurant.Categories.Any(x => x == newFood.Category))
            {
                MessageBox.Show($"There is no category in this restaurant named \"{newFood.Category}\"!");
                return;
            }
            Data.CurrentRestaurant.Foods.Add(newFood);
            MessageBox.Show("The food has been added.");
            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
