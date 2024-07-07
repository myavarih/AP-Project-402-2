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
    /// Interaction logic for EditCategory.xaml
    /// </summary>
    public partial class EditCategory : Page
    {
        public EditCategory()
        {
            InitializeComponent();
            DataContext = Data.CurrentRestaurant;
            if (Data.CurrentRestaurant.Categories.Count > 0 ) 
                Data.CurrentRestaurant.Categories.RemoveAt(0); // remove "All" Category
            Data.CurrentRestaurant.Categories = Data.CurrentRestaurant.Categories;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Data.CurrentRestaurant.Categories.Insert(0, "All");
            Data.CurrentRestaurant.Categories = Data.CurrentRestaurant.Categories;
            Data.Database.SaveChanges();
            NavigationService.GoBack();
        }

        private void RemoveCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string category = button.Tag.ToString();
            if (category == "All")
            {
                MessageBox.Show("You cannot delete this category");
                return;
            }
            if (Data.CurrentRestaurant.Categories.Any(x => x == category))
            {
                Data.CurrentRestaurant.Categories.Remove(category);
                Data.CurrentRestaurant.Foods = Data.CurrentRestaurant.Foods.Where(x => x.Category != category).ToList(); // delete all the foods in this category as well
            }
            else
            {
                MessageBox.Show("There is no such a category to remove! (refresh the page)");
            }
            Data.CurrentRestaurant.Categories = Data.CurrentRestaurant.Categories;
            Data.Database.SaveChanges();
            DataContext = null;
            DataContext = Data.CurrentRestaurant;
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            string newCat = NewCategoryTextBox.Text;
            NewCategoryTextBox.Text = "";
            if (newCat == "All")
            {
                MessageBox.Show("The category name cannot be \"All\"! Try another one!");
                return;
            }
            if (Data.CurrentRestaurant.Categories.Any(x => x == newCat))
            {
                MessageBox.Show("There is already a category with this name!");
                return;
            }
            Data.CurrentRestaurant.Categories.Add(newCat);
            //Data.CurrentRestaurant.Categories = Data.CurrentRestaurant.Categories.Concat([newCat]).ToList();
            //var x = Data.CurrentRestaurant.Categories;
            //Data.CurrentRestaurant.Categories = x;
            Data.CurrentRestaurant.Categories = Data.CurrentRestaurant.Categories;
            Data.Database.SaveChanges();
            // MessageBox.Show("Category Added.");
            DataContext = null;
            DataContext = Data.CurrentRestaurant;
        }
    }
}
