using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Front.Restaurant_Window
{
    class ViewModelForOrderReserveHistory
    {
        public ViewModelForOrderReserveHistory()
        {
            FilteredOrders = new ObservableCollection<Order>(Data.CurrentRestaurant.Orders);
        }

        public ObservableCollection<Order> FilteredOrders { get; set; }
    }
}
