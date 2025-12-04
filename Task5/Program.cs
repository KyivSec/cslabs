using System;

namespace Task5 {
    public class Program {
        private static bool IsInvalid(int[] numbers) { return numbers == null || numbers.Length == 0; }

        public static int GetSum(int[] numbers) {
            if (IsInvalid(numbers)) return 0;
            int sum = 0;
            for (int index = 0; index < numbers.Length; index++) sum += numbers[index];
            return sum;
        }

        public static double GetAverage(int[] numbers) {
            if (IsInvalid(numbers)) return 0;
            return (double)GetSum(numbers) / numbers.Length;
        }

        public static int GetMin(int[] numbers) {
            if (IsInvalid(numbers)) return 0;
            int min = numbers[0];
            for (int index = 1; index < numbers.Length; index++) if (numbers[index] < min) min = numbers[index];
            return min;
        }

        public static int GetMax(int[] numbers) {
            if (IsInvalid(numbers)) return 0;
            int max = numbers[0];
            for (int index = 1; index < numbers.Length; index++) if (numbers[index] > max) max = numbers[index];
            return max;
        }

        public static void PrintGroupStatistics(int[][] groups) {
            if (groups == null) return;

            for (int groupIndex = 0; groupIndex < groups.Length; groupIndex++) {
                int[] groupMarks = groups[groupIndex];

                double average = GetAverage(groupMarks);
                int min = GetMin(groupMarks);
                int max = GetMax(groupMarks);

                double roundedAverage = Math.Round(average);

                Console.WriteLine($"Група {groupIndex + 1}: Середній = {roundedAverage}, Мінімальний = {min}, Максимальний = {max}");
            }
        }

        public static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[][] groups =
            {
                new[] { 60, 75, 81, 90 },
                new[] { 50, 60, 70, 80, 95 },
                new[] { 90, 95, 100 }
            };

            PrintGroupStatistics(groups);
        }
    }
}
