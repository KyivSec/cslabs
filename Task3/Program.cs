using System;

namespace Task3 {
    public class Program {
        public static string ClassifyAge(int age) {
            if (age < 0 || age > 120) return "Нереальний вік";
            if (age < 12) return "Ви дитина";
            if (age < 18) return "Підліток";
            if (age < 60) return "Дорослий";
            return "Пенсіонер";
        }

        public static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть ваш вік: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int age)) {
                Console.WriteLine(ClassifyAge(age));
            } else {
                Console.WriteLine("Некоректний вік.");
            }
        }
    }
}
