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
    /// Interaction logic for EditFood.xaml
    /// </summary>
    public partial class EditFood : Page // give me a Food Object for DataContext // todo : Ali
    {
        public EditFood()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) // validate Before Allowing to go Back (No Save Button - Binding)
        {
            NavigationService.GoBack();
        }
    }
}
