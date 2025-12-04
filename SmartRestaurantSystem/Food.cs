namespace SmartRestaurantSystem {
    public class Food : MenuItem {
        public string Category { get; set; }

        public Food(string name, double price, string category) : base(name, price) {
            Category = category;
        }

        public override string GetInfo() {
            return $"{Name} ({Category}) - {Price} грн";
        }
    }
}