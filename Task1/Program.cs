namespace Task1 {
    public class Program {
        public static bool IsEven(int num) { return num % 2 == 0; }

        public static string GetMessage(int num) { return IsEven(num) ? "Двері відкриваються!" : "Двері зачинені..."; }

        public static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введіть число: ");
            string Input = Console.ReadLine();

            if (int.TryParse(Input, out int num)) {
                Console.WriteLine(GetMessage(num));
            } else {
                Console.WriteLine("Некоректне число.");
            }
        }
    }
}