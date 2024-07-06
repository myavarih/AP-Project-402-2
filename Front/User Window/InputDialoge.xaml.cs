using System.Windows;

namespace AP_Project.Front.User_Window
{
    /// <summary>
    /// Interaction logic for InputDialoge.xaml
    /// </summary>

    public partial class InputDialoge : Window
    {
        public string InputText { get; private set; }

        public InputDialoge(string defaultText = "")
        {
            InitializeComponent();
            InputTextBox.Text = defaultText;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            InputText = InputTextBox.Text;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}


