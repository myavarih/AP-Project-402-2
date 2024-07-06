using AP_Project.Back;
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
        Restaurant restaurant;
        public FoodView(string restaurantUsername, string foodName)
        {
            InitializeComponent();
            restaurant = Data.GetRestaurantByUsername(restaurantUsername);
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
            DataContext = food;
        }

        private void CommentSubmit_Click(object sender, RoutedEventArgs e)
        {
            // todo
        }
        private void EditCommentButton_Click(object sender, RoutedEventArgs e)
        {
            // open a new Window

            //Sample usage of InputDialoge : 
            //private void EditCommentButton_Click(object sender, RoutedEventArgs e)
            //{
            //    Button button = sender as Button;
            //    CommentForFood comment = button.Tag as CommentForFood;

            //    // Open the InputDialog to edit the comment text
            //    InputDialog inputDialog = new InputDialog(comment.Text);
            //    if (inputDialog.ShowDialog() == true)
            //    {
            //        comment.Text = inputDialog.InputText;
            //        comment.IsEdited = true;
            //        ComplaintsListView.Items.Refresh();
            //    }
            //}
        }


        private void SubmitRatingBtn_Click(object sender, RoutedEventArgs e)
        {
            double rating;
            if (!double.TryParse(RatingTextBox.Text, out rating) || rating < 0 || rating > 5)
            {
                MessageBox.Show("Rating must be a number (double) between 0 and 5!");
                return;
            }
            ScoreForFood sff = food.Scores.FirstOrDefault(x => x.UserUsername == Data.CurrentUser.Username);
            if (sff == null)
            {
                // fist time rating this food:
                food.Scores.Add(new ScoreForFood(Data.CurrentUser.Username, restaurant.Username, food.Name, rating));
                MessageBox.Show("Your rating to this food added.");
            }
            else
            {
                // updating the rating
                sff.Score = rating;
                MessageBox.Show("Your rating to this food updated.");
            }
        }
    }
}
