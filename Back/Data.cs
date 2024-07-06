// Ignore Spelling: Admins

using AP_Project.Back;
using System.Windows.Media.Imaging;

namespace AP_Project
{
    static class Data
    {
        public static Database Database { get; set; } = new Database();

        public static List<BaseUser> BaseUsers { get; set; } = Database.Users.Select(x => (BaseUser)x).Concat(Database.Restaurants.Select(x => (BaseUser)x)).Concat(Database.Admins.Select(x => (BaseUser)x)).ToList();
        //public static List<User> Users { get; set; } = new List<User>();
        //public static List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        //public static List<Admin> Admins { get; set; } = new List<Admin>();
        //public static List<Complaint> Complaints { get; set; } = new List<Complaint>();

        public static List<Order> UnfinalizedOrders { get; set; } = new List<Order>();

        
        public static User CurrentUser { get; set; } = null;
        public static Restaurant CurrentRestaurant { get; set; } = null;
        public static Admin CurrentAdmin { get; set; } = null;

        public static void AddCurrentUser()
        {
            Database.Users.Add(CurrentUser);
            BaseUsers.Add(CurrentUser);
        }

        public static void AddRestaurant(Restaurant restaurant)
        {
            Database.Restaurants.Add(restaurant);
            BaseUsers.Add(restaurant);
        }

        public static void AddAdmin(Admin admin)
        {
            Database.Admins.Add(admin);
            BaseUsers.Add(admin);
        }

        public static BaseUser GetBaseUserByUsername(string username)
        {
            return BaseUsers.FirstOrDefault(x => x.Username == username);
        }
        public static User GetUserByUsername(string username)
        {
            return Database.Users.FirstOrDefault(x => x.Username == username);
        }
        public static Restaurant GetRestaurantByUsername(string username)
        {
            return Database.Restaurants.FirstOrDefault(x => x.Username == username);
        }
        public static Admin GetAdminByUsername(string username)
        {
            return Database.Admins.FirstOrDefault(x => x.Username == username);
        }

        public static Order GetOrderByCode(int code)
        {
            return UnfinalizedOrders.FirstOrDefault(x => x.Code == code);
        }
    }
}
