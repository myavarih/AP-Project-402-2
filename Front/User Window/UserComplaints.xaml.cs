using AP_Project.Back;
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
    /// Interaction logic for UserComplaints.xaml
    /// </summary>
    public partial class UserComplaints : Page
    {
        public UserComplaints()
        {
            InitializeComponent();
            ComplaintsListView.ItemsSource = Data.Database.Complaints;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddComplaintButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Data.Database.Restaurants.Any(r => RestaurantNameTextBox.Text == r.Name))
            {
                MessageBox.Show("No such Restaurant!");
                return;
            }
            Complaint newComplaint = new Complaint(TitleTextBox.Text, BodyTextBox.Text, Data.CurrentUser.Username, Data.Database.Restaurants.First(r => RestaurantNameTextBox.Text == r.Name).Username, DateTime.Now, "");
            Data.Database.Complaints.Add(newComplaint);
            ComplaintsListView.ItemsSource = null;
            ComplaintsListView.ItemsSource = Data.Database.Complaints;
        }
    }
}
