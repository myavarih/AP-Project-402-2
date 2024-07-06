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
    /// Interaction logic for EditFood.xaml
    /// </summary>
    public partial class EditFood : Page // give me a Food Object for DataContext // todo : Ali (done)
    {
        Food food;
        string ImagePath;
        public EditFood(string foodName)
        {
            InitializeComponent();
            food = Data.CurrentRestaurant.GetFoodByName(foodName);
            DataContext = food;
            ImageBox.Source = food.ImageName;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) // validate Before Allowing to go Back (No Save Button - Binding) (done)
        {
            // todo: Image?!
            if (food.Price < 0)
            {
                MessageBox.Show("The price cannot be a negative number!");
                return;
            }
            Food anotherFood = null;
            foreach (var f in Data.CurrentRestaurant.Foods)
            {
                if (f != food && f.Name == food.Name)
                {
                    anotherFood = f;
                }
            }
            if ( anotherFood != null)
            {
                MessageBox.Show("There is already a food with this name in this restaurant! Try another name!");
                return;
            }
            if (!Data.CurrentRestaurant.Categories.Any(x => x == food.Category))
            {
                MessageBox.Show($"There is no category in this restaurant named \"{food.Category}\"!");
                return;
            }
            File.Copy(ImagePath, @"C:\Users\myava\OneDrive\Documents\GitHub\AP-Project-402-2\Images\" + food.Name + food.RestaurantUsername, true);
            food.ImageName = (BitmapImage)ImageBox.Source;
            NavigationService.GoBack();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                ImagePath = openFileDialog.FileName;
                ImageBox.Source = new BitmapImage(new Uri(ImagePath));
            }
        }
    }
}
