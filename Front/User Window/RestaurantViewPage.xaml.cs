using AP_Project.Back;
using AP_Project.Front.User_Window;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
        Restaurant restaurant;
        ViewModelForRestaurantViewPage vm;
        Order order;
        public RestaurantViewPage(string restaurantUsername) // A Cart Should be Created and used
        {
            InitializeComponent();
            restaurant = Data.GetRestaurantByUsername(restaurantUsername);
            if (restaurant == null)
            {
                throw new Exception("There is no restaurant with this username!");
            }
            vm = new ViewModelForRestaurantViewPage(restaurantUsername);
            DataContext = vm;
            order = new Order(Data.CurrentUser.Username, restaurant.Username, DateTime.Now);
        }

        private void ApplyFilters(object sender, RoutedEventArgs e)
        {
            var selectedCategory = DropdownMenu.SelectedItem.ToString();
            var allFoods = restaurant.Foods;
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
            // todo
        }
        
        private void CommentRateButton_Click(object sender, RoutedEventArgs e)
        {
            // todo (FoodViewPage)
            Button clickedButton = sender as Button;
            string foodName = clickedButton.Tag.ToString();
            NavigationService.Navigate(new FoodView(restaurant.Username, foodName));
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            Data.UnfinalizedOrders.Add(order);
            NavigationService.Navigate(new PaymentPage(order.Code));
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
                int orderCount;
                if (orderTextBox.Text == "") { orderCount = 0; }
                else if (!int.TryParse(orderTextBox.Text, out orderCount) || orderCount < 0)
                {
                    MessageBox.Show("Order Count Must Be A Non-negative Integer!");
                    return;
                }
                Food food = restaurant.GetFoodByName(foodName);
                if (food == null)
                {
                    throw new Exception("There is no food in the restaurant with this name!");
                }
                // check if there is enough food
                if (food.Count >= orderCount)
                {
                    // transport the food to cart
                    // check if your adding it for the first time or changing it
                    Food foodOnCart = order.Cart.FirstOrDefault(x => x.Name == food.Name);
                    if (foodOnCart != null)
                    {
                        // changing (it exists in cart)
                        foodOnCart.Count = orderCount;
                        if (orderCount == 0)
                        {
                            order.Cart.Remove(foodOnCart);
                            MessageBox.Show($"This food has been removed from your cart: {foodOnCart.Name}");
                        }
                        else
                        {
                            MessageBox.Show($"Food: {foodName}, Order Count: {orderCount} (updated)");
                        }
                    }
                    else
                    {
                        // adding it to the cart for the first time
                        Food copiedFood = Food.DeepCopy(food);
                        copiedFood.Count = orderCount;
                        order.Cart.Add(copiedFood);
                        MessageBox.Show($"Food: {foodName}, Order Count: {orderCount} (added to cart)");
                    }
                }
                else
                {
                    MessageBox.Show($"You cannot order more than the existing number of this food! (max count you can order: {food.Count})");
                    return;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
