namespace SmartRestaurantSystem {
    public class Order {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public OrderStatus Status { get; set; }

        private readonly List<MenuItem> items = new List<MenuItem>();

        public Order(int id, int tableNumber) {
            Id = id;
            TableNumber = tableNumber;
            Status = OrderStatus.New;
        }

        public void AddItem(MenuItem item) {
            items.Add(item);
            Console.WriteLine($"Додано позицію: {item.Name}");
        }

        public void RemoveItem(string name) {
            for (int index = 0; index < items.Count; index++) {
                if (items[index].Name == name) {
                    Console.WriteLine($"Видалено позицію: {name}");
                    items.RemoveAt(index);
                    return;
                }
            }

            Console.WriteLine($"Позицію '{name}' не знайдено у замовленні.");
        }

        public double GetTotal() {
            double sum = 0;
            for (int index = 0; index < items.Count; index++) sum += items[index].Price;
            return sum;
        }

        public void ChangeStatus(OrderStatus newStatus) {
            Status = newStatus;
            Console.WriteLine($"> Змінено статус: {Status}");
        }

        public List<MenuItem> GetItems() { return items; }
    }
}