using AP_Project.Back;
using AP_Project.Front.User_Window;
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
    public partial class RestaurantViewPage : Page // todo: Ali -> Complete This Page
    {
        string RestaurantUsername;
        ViewModelForRestaurantViewPage vm;
        public RestaurantViewPage(string restaurantUsername) // A Cart Should be Created and used
        {
            InitializeComponent();
            RestaurantUsername = restaurantUsername;
            vm = new ViewModelForRestaurantViewPage(restaurantUsername);
            DataContext = vm;
        }

        private void ApplyFilters(object sender, RoutedEventArgs e)
        {
            var selectedCategory = DropdownMenu.SelectedItem.ToString();
            var allFoods = Data.GetRestaurantByUsername(RestaurantUsername).Foods;
            var filteredFoods = selectedCategory == "All"
                ? allFoods
                : allFoods.Where(x => x.Category == selectedCategory).ToList();

            vm.Foods.Clear();
            foreach (var food in filteredFoods)
            {
                vm.Foods.Add(food);
            }
        }


        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void CommentRateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PaymentPage());
        }
        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string foodName = clickedButton.Tag.ToString();

            // Find the parent StackPanel of the clicked button
            StackPanel parentPanel = clickedButton.Parent as StackPanel;

            // Find the TextBox within the same StackPanel
            TextBox orderTextBox = parentPanel.Children
                                               .OfType<TextBox>()
                                               .FirstOrDefault(tb => tb.Tag.ToString() == foodName);

            if (orderTextBox != null)
            {
                string orderCount = orderTextBox.Text;
                // Now you have the order count value in orderCount variable
                MessageBox.Show($"Food: {foodName}, Order Count: {orderCount}");
                // Implement your logic to add the item to the cart
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
