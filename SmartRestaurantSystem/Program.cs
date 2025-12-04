namespace SmartRestaurantSystem {
    public class Program {
        public static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Restaurant restaurant = new Restaurant();

            restaurant.AddMenuItem(new Food("Борщ", 120, "Перше"));
            restaurant.AddMenuItem(new Drink("Кава", 60, 200, false));
            restaurant.AddMenuItem(new Drink("Сік апельсиновий", 70, 250, false));

            restaurant.PrintMenu();

            Order order = restaurant.CreateOrder(101, 5);
            order.AddItem(new Food("Борщ", 120, "Перше"));
            order.AddItem(new Drink("Кава", 60, 200, false));

            Console.WriteLine($"Поточна сума: {order.GetTotal()} грн\n");

            Console.WriteLine($"Статус замовлення: {order.Status}");
            order.ChangeStatus(OrderStatus.InProgress);
            order.ChangeStatus(OrderStatus.Ready);
            order.ChangeStatus(OrderStatus.Paid);

            Console.WriteLine();

            MenuItem upcastItem = new Drink("Фанта", 55, 330, false);

            Drink downcastDrink = (Drink)upcastItem;
            Console.WriteLine($"Upcast/downcast демонстрація: {downcastDrink.GetInfo()}\n");

            restaurant.PrintAllOrders();
        }
    }
}