// Ignore Spelling: Admins

using AP_Project.Back;
using System.Windows.Media.Imaging;

namespace AP_Project
{
    static class Data
    {
        // public static Database Database { get; set; } = new Database();

        public static List<BaseUser> BaseUsers { get; set; } = new List<BaseUser>();
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public static List<Admin> Admins { get; set; } = new List<Admin>();
        public static List<Complaint> Complaints { get; set; } = new List<Complaint>();

        public static List<Order> UnfinalizedOrders { get; set; } = new List<Order>();

        public static List<Restaurant>  restaurants { get; set; } = new List<Restaurant>
{
    new Restaurant("restaurant_1", "password123", "Tasty Bites", "New York", "123 Main St", true, true, 4.2,
        new List<Food>
        {
            new Food("Cheeseburger at Tasty Bites", "Beef, Cheese, Lettuce", new BitmapImage(), 12.50, "Fast Food", 4.5, "restaurant_1", 50),
            new Food("Pizza at Tasty Bites", "Tomato Sauce, Cheese, Pepperoni", new BitmapImage(), 15.75, "Italian", 4.0, "restaurant_1", 45)
        },
        new List<Order>(),
        new List<string> { "All", "Fast Food", "Italian" }
    ),

    new Restaurant("restaurant_2", "password123", "Gourmet Grill", "Los Angeles", "456 Elm St", true, false, 3.8,
        new List<Food>
        {
            new Food("Steak at Gourmet Grill", "Beef, Potatoes, Vegetables", new BitmapImage(), 18.99, "Steakhouse", 4.2, "restaurant_2", 30),
            new Food("Salad at Gourmet Grill", "Lettuce, Cucumber, Tomato", new BitmapImage(), 9.99, "Healthy", 3.8, "restaurant_2", 35)
        },
        new List<Order>(),
        new List<string> { "All", "Steakhouse", "Healthy" }
    ),

    new Restaurant("restaurant_3", "password123", "Spice Fusion", "Chicago", "789 Oak Ave", false, true, 4.5,
        new List<Food>
        {
            new Food("Sushi at Spice Fusion", "Rice, Seaweed, Fish", new BitmapImage(), 22.50, "Japanese", 4.7, "restaurant_3", 25),
            new Food("Tacos at Spice Fusion", "Tortilla, Beef, Cheese", new BitmapImage(), 11.99, "Mexican", 4.3, "restaurant_3", 40)
        },
        new List<Order>(),
        new List<string> { "All", "Japanese", "Mexican" }
    ),

    new Restaurant("restaurant_4", "password123", "Bella Italia", "Miami", "101 Pine Blvd", true, true, 4.0,
        new List<Food>
        {
            new Food("Pasta at Bella Italia", "Tomato Sauce, Pasta, Cheese", new BitmapImage(), 16.99, "Italian", 4.0, "restaurant_4", 20),
            new Food("Soup at Bella Italia", "Chicken Broth, Vegetables", new BitmapImage(), 8.50, "Soup", 3.5, "restaurant_4", 15)
        },
        new List<Order>(),
        new List<string> { "All", "Italian", "Soup" }
    ),

    new Restaurant("restaurant_5", "password123", "Sushi Sensation", "San Francisco", "202 Cedar Ln", false, true, 4.3,
        new List<Food>
        {
            new Food("Sashimi at Sushi Sensation", "Fresh Fish", new BitmapImage(), 25.00, "Japanese", 4.5, "restaurant_5", 28),
            new Food("Tempura at Sushi Sensation", "Shrimp, Vegetables", new BitmapImage(), 19.99, "Japanese", 4.1, "restaurant_5", 32)
        },
        new List<Order>(),
        new List<string> { "All", "Japanese" }
    ),

    new Restaurant("restaurant_6", "password123", "BBQ Delight", "Houston", "303 Maple Rd", true, false, 4.1,
        new List<Food>
        {
            new Food("BBQ Ribs at BBQ Delight", "Pork Ribs, BBQ Sauce", new BitmapImage(), 17.99, "BBQ", 4.2, "restaurant_6", 22),
            new Food("Grilled Chicken at BBQ Delight", "Chicken, Seasoning", new BitmapImage(), 14.50, "BBQ", 4.0, "restaurant_6", 25)
        },
        new List<Order>(),
        new List<string> { "All", "BBQ" }
    ),

    new Restaurant("restaurant_7", "password123", "Veggie Haven", "Seattle", "404 Walnut Ave", true, true, 4.4,
        new List<Food>
        {
            new Food("Vegetarian Pizza at Veggie Haven", "Tomato Sauce, Cheese, Mixed Vegetables", new BitmapImage(), 14.99, "Vegetarian", 4.3, "restaurant_7", 18),
            new Food("Salad Bowl at Veggie Haven", "Lettuce, Cucumber, Bell Peppers", new BitmapImage(), 10.99, "Healthy", 4.5, "restaurant_7", 20)
        },
        new List<Order>(),
        new List<string> { "All", "Vegetarian", "Healthy" }
    ),

    new Restaurant("restaurant_8", "password123", "Seafood Paradise", "Boston", "505 Birch St", false, true, 4.6,
        new List<Food>
        {
            new Food("Lobster Roll at Seafood Paradise", "Lobster Meat, Buttered Roll", new BitmapImage(), 28.50, "Seafood", 4.7, "restaurant_8", 15),
            new Food("Fish and Chips at Seafood Paradise", "Fried Fish, Potato Wedges",new BitmapImage(), 19.75, "Seafood", 4.5, "restaurant_8", 12)
        },
        new List<Order>(),
        new List<string> { "All", "Seafood" }
    )
};




        public static User CurrentUser { get; set; } = null;
        public static Restaurant CurrentRestaurant { get; set; } = null;
        public static Admin CurrentAdmin { get; set; } = null;

        public static void AddCurrentUser()
        {
            Users.Add(CurrentUser);
            BaseUsers.Add(CurrentUser);
        }

        public static void AddCurrentRestaurants()
        {
            Restaurants.Add(CurrentRestaurant);
            BaseUsers.Add(CurrentRestaurant);
        }

        public static void AddCurrentAdmin()
        {
            Admins.Add(CurrentAdmin);
            BaseUsers.Add(CurrentAdmin);
        }

        public static BaseUser GetBaseUserByUsername(string username)
        {
            return BaseUsers.FirstOrDefault(x => x.Username == username);
        }
        public static User GetUserByUsername(string username)
        {
            return Users.FirstOrDefault(x => x.Username == username);
        }
        public static Restaurant GetRestaurantByUsername(string username)
        {
            return Restaurants.FirstOrDefault(x => x.Username == username);
        }
        public static Admin GetAdminByUsername(string username)
        {
            return Admins.FirstOrDefault(x => x.Username == username);
        }

        public static Order GetOrderByCode(int code)
        {
            return UnfinalizedOrders.FirstOrDefault(x => x.Code == code);
        }
    }
}
