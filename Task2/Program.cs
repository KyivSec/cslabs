using System;
using System.Collections.Generic;

namespace Task2 {
    public class Program {
        private static readonly Random RandomGenerator = new Random();

        private static bool IsInvalid(int[] numbers) { return numbers == null || numbers.Length == 0; }

        public static int[] GenerateRandomArray(int size, int min, int max) {
            if (size < 0) size = 0;
            int[] result = new int[size];
            for (int index = 0; index < size; index++) result[index] = RandomGenerator.Next(min, max + 1);
            return result;
        }

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

        public static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[] numbers = GenerateRandomArray(10, 1, 100);

            Console.WriteLine("Масив чисел:");
            for (int i = 0; i < numbers.Length; i++) Console.Write(numbers[i] + " ");

            Console.WriteLine($"\nСума: {GetSum(numbers)}");
            Console.WriteLine($"Середнє: {GetAverage(numbers)}");
            Console.WriteLine($"Мінімум: {GetMin(numbers)}");
            Console.WriteLine($"Максимум: {GetMax(numbers)}");
        }
    }
}