namespace SmartRestaurantSystem {
    public class Drink : MenuItem {
        public int Volume { get; set; }
        public bool IsAlcoholic { get; set; }

        public Drink(string name, double price, int volume, bool isAlcoholic) : base(name, price) {
            Volume = volume;
            IsAlcoholic = isAlcoholic;
        }

        public override string GetInfo() {
            string alcohol = IsAlcoholic ? "алк." : "без алкоголю";
            return $"{Name} ({Volume} мл, {alcohol}) - {Price} грн";
        }
    }
}