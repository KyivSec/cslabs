namespace SmartRestaurantSystem {
    public class Restaurant {
        private readonly List<MenuItem> menu = new List<MenuItem>();
        private readonly List<Order> orders = new List<Order>();

        public void AddMenuItem(MenuItem item) { menu.Add(item); }

        public void PrintMenu() {
            Console.WriteLine("--- МЕНЮ РЕСТОРАНУ ---");
            for (int index = 0; index < menu.Count; index++) {
                MenuItem item = menu[index];
                Console.WriteLine($"{index + 1}. {item.GetInfo()}");
            }
            Console.WriteLine("-----------------------\n");
        }

        public Order CreateOrder(int id, int tableNumber) {
            Order order = new Order(id, tableNumber);
            orders.Add(order);
            Console.WriteLine($"Створено нове замовлення для столика №{tableNumber}");
            return order;
        }

        public Order GetOrderById(int id) {
            for (int index = 0; index < orders.Count; index++) if (orders[index].Id == id) return orders[index];
            return null;
        }

        public void PrintAllOrders() {
            Console.WriteLine("--- УСІ ЗАМОВЛЕННЯ ---");
            for (int index = 0; index < orders.Count; index++) {
                Order order = orders[index];
                Console.WriteLine($"ID: {order.Id} | Стіл: {order.TableNumber} | Статус: {order.Status} | Сума: {order.GetTotal()} грн");
            }
        }

        public List<MenuItem> SearchMenu(string name) {
            List<MenuItem> result = new List<MenuItem>();
            for (int index = 0; index < menu.Count; index++) if (menu[index].Name.ToLower().Contains(name.ToLower())) result.Add(menu[index]);
            return result;
        }
    }
}