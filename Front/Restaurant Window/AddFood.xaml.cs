using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        string ImagePath;
        Food newFood = null;
        public AddFood()
        {
            InitializeComponent();
            newFood = new Food("", "", new BitmapImage(), 0, "", Data.CurrentRestaurant.Username, 0);
            // count = 0, the restaurant should change it via Change Food Inventory
            DataContext = newFood;
        }

        private void AddFoodButton_Click(object sender, RoutedEventArgs e)
        {
            if (newFood.Name.Contains(','))
            {
                MessageBox.Show("A food name cannot contain ',' for saving issues!");
                return;
            }
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
            //MessageBox.Show("The food has been added.");
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            File.Copy(ImagePath, currentPath + newFood.Name + newFood.RestaurantUsername, true);
            newFood.ImageName = (BitmapImage)ImageName.Source;
            NavigationService.GoBack();
            Data.CurrentRestaurant.Foods = Data.CurrentRestaurant.Foods;
            Data.Database.SaveChanges();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            Data.Database.SaveChanges();
        }

        private void BrowseImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                ImagePath = openFileDialog.FileName;
                ImageName.Source = new BitmapImage(new Uri(ImagePath));
            }
        }
    }
}
