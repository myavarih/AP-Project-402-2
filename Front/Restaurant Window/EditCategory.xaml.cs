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
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RemoveCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string category = button.Tag.ToString();
            if (Data.CurrentRestaurant.Categories.Any(x => x == category))
            {
                Data.CurrentRestaurant.Categories.Remove(category);
                Data.CurrentRestaurant.Foods = Data.CurrentRestaurant.Foods.Where(x => x.Category != category).ToList(); // delete all the foods in this category as well
                // todo: Refresh the list view
            }
            else
            {
                MessageBox.Show("There is no such a category to remove! (refresh the page)");
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            string newCat = NewCategoryTextBox.Text;
            if (Data.CurrentRestaurant.Categories.Any(x => x == newCat))
            {
                MessageBox.Show("There is already a category with this name!");
                return;
            }
            Data.CurrentRestaurant.Categories.Add(newCat);
            MessageBox.Show("Category Added.");
            // todo: Refresh the list view
        }
    }
}
