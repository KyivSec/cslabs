using System;

namespace Task4 {
    public class Program {
        private const double EPSILON = 1e-6;

        public static bool IsValidTriangle(double sideA, double sideB, double sideC) {
            return sideA > 0 && sideB > 0 && sideC > 0 && sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA;
        }

        public static double GetPerimeter(double sideA, double sideB, double sideC) { return sideA + sideB + sideC; }

        public static double GetArea(double sideA, double sideB, double sideC) {
            double semiPerimeter = GetPerimeter(sideA, sideB, sideC) / 2.0;
            double value = semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC);
            if (value < 0) value = 0;
            return Math.Sqrt(value);
        }

        private static bool AreEqual(double x, double y) { return Math.Abs(x - y) < EPSILON; }

        public static string GetTriangleType(double sideA, double sideB, double sideC) {
            if (!IsValidTriangle(sideA, sideB, sideC)) return "Не трикутник";

            bool isEquilateral = AreEqual(sideA, sideB) && AreEqual(sideB, sideC);
            bool isIsosceles = AreEqual(sideA, sideB) || AreEqual(sideA, sideC) || AreEqual(sideB, sideC);
            double[] squares = { sideA * sideA, sideB * sideB, sideC * sideC };

            Array.Sort(squares);

            bool isRight = AreEqual(squares[0] + squares[1], squares[2]);

            if (isEquilateral) return "рівносторонній";
            if (isRight) return "прямокутний";
            if (isIsosceles) return "рівнобедрений";
            return "довільний";
        }

        public static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть сторону a: ");
            if (!double.TryParse(Console.ReadLine(), out double sideA)) {
                Console.WriteLine("Некоректні дані.");
                return;
            }

            Console.Write("Введіть сторону b: ");
            if (!double.TryParse(Console.ReadLine(), out double sideB)) {
                Console.WriteLine("Некоректні дані.");
                return;
            }

            Console.Write("Введіть сторону c: ");
            if (!double.TryParse(Console.ReadLine(), out double sideC)) {
                Console.WriteLine("Некоректні дані.");
                return;
            }

            if (!IsValidTriangle(sideA, sideB, sideC)) {
                Console.WriteLine("Трикутник не існує.");
                return;
            }

            Console.WriteLine($"Периметр: {GetPerimeter(sideA, sideB, sideC)}");
            Console.WriteLine($"Площа: {GetArea(sideA, sideB, sideC)}");
            Console.WriteLine($"Тип трикутника: {GetTriangleType(sideA, sideB, sideC)}");
        }
    }
}
