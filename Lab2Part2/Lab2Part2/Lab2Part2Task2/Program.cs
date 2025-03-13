using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab2Part2Task2
{
    class Program
    {
        // Константи для визначення цільового числа та допустимого відхилення
        private const double TARGET_VALUE = 1000.0;           // цільове значення, до якого намагаємось наблизити результат
        private const double TOLERANCE = 0.1;                 // допустиме відхилення від цільового значення

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.\n");   // повідомлення про початок роботи головного потоку

            int[] sizes = { 100000, 1000000, 10000000 };       // три різні розміри масивів для експерименту

            foreach (int size in sizes)                        // перебір усіх варіантів розмірів масивів для виконання експерименту
            {
                Console.WriteLine($"Testing with array size: {size}\n"); // виведення поточного розміру масиву

                RunExperiment(size);    // викликаємо метод для виконання експерименту з поточним розміром масиву
            }

            Console.WriteLine("Main() is done.");             // завершення роботи головного методу
            Console.ReadLine();                               // чекаємо на натискання клавіші для завершення
        }

        static void RunExperiment(int size)
        {
            double[] data = new double[size];                 // ініціалізація масиву double розміру size

            Stopwatch sw = new Stopwatch();                   // оголошення змінної для вимірювання часу виконання операцій

            sw.Start();                                       // початок вимірювання часу для послідовної ініціалізації

            for (int i = 0; i < data.Length; i++)             // заповнення масиву числами від 1 до size
                data[i] = i + 1;                              // кожен елемент дорівнює індексу + 1

            sw.Stop();                                        // завершення вимірювання часу ініціалізації
            Console.WriteLine("Serial initialization: " + sw.Elapsed.TotalSeconds + " sec");   // виведення часу виконання ініціалізації

            // Вставка від'ємного значення в масив, якщо розмір масиву більше 1000
            // Це робиться для тестування обробки специфічних значень
            if (size > 1000) data[1000] = -10;
            
            string[] operations = { "x / 10", "x / pi", "e^x / x^pi", "e^pi*x / x^pi" };       // масив операцій, які будуть застосовуватись до елементів масиву

            foreach (string operation in operations)          // перебір всіх операцій і виконання тестів для кожної
            {
                Console.WriteLine($"\nOperation: {operation}");  // виведення назви поточної операції

                // --- Послідовне виконання операції ---
                sw.Restart();                                 // перезапускаємо таймер // вимірювання часу для послідовного виконання операцій

                for (int i = 0; i < data.Length; i++)         // послідовне виконання трансформації для кожного елемента масиву
                    Transform(ref data[i], operation);        // викликаємо метод Transform для зміни значення

                sw.Stop();                                    // завершення вимірювання часу
                Console.WriteLine("Serial execution: " + sw.Elapsed.TotalSeconds + " sec");  // виведення часу виконання

                // --- Паралельне виконання операції з перевіркою на вихід ---
                sw.Restart();                                 // вимірювання часу для паралельного виконання операцій

                Parallel.For(0, data.Length, (i, state) =>    // паралельне виконання за допомогою Parallel.For
                {
                    Transform(ref data[i], operation);        // трансформація елементу масиву

                    if (Math.Abs(data[i] - TARGET_VALUE) <= TOLERANCE)   // перевірка, чи досягнуто цільове значення з допустимим відхиленням
                    {
                        Console.WriteLine($"Breaking loop at index {i}, value: {data[i]}");   // якщо цільове значення досягнуте, вивести інформацію і перервати цикл
                        state.Break();                       // достроковий вихід із циклу
                    }
                });

                sw.Stop();                                   // завершення вимірювання часу для паралельного виконання
                Console.WriteLine("Parallel execution: " + sw.Elapsed.TotalSeconds + " sec"); // виведення часу виконання
            }
        }

        static void Transform(ref double x, string operation) // метод для виконання математичних операцій над елементом масиву
        {
            if (x < 0) return;                               // якщо значення елемента менше нуля, просто пропускаємо його

            switch (operation)                               // виконання відповідної операції в залежності від назви операції
            {
                case "x / 10":
                    x = x / 10;                              // ділимо число на 10
                    break;
                case "x / pi":
                    x = x / Math.PI;                         // ділимо число на пі (число "π")
                    break;
                case "e^x / x^pi":
                    x = Math.Exp(x) / Math.Pow(x, Math.PI);  // e^x / x^π
                    break;
                case "e^pi*x / x^pi":
                    x = Math.Exp(Math.PI * x) / Math.Pow(x, Math.PI); // e^(π*x) / x^π
                    break;
            }
        }
    }
}
