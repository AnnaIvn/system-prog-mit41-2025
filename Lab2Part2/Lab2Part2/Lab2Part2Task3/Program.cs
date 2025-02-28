using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Part2Task3
{
    class Program
    {
        static void Main(string[] args)                                     // основний метод програми, точка входу
        {
            Console.WriteLine("Main Thread is starting.\n");                // повідомлення про старт головного потоку

            int[] sizes = { 100000, 1000000, 10000000 };                    // масив з різними розмірами масивів для тестування

            foreach (int size in sizes)                                     // перебір кожного розміру масиву для тестування
            {
                Console.WriteLine($"Testing with array size: {size}\n");    // виведення розміру масиву для поточного тесту

                RunExperiment(size);                                        // запуск експерименту для кожного розміру масиву
            }

            Console.WriteLine("Main() is done.");                           // повідомлення про завершення основного методу

            Console.ReadLine();                                             // очікування натискання клавіші, щоб закрити консоль
        }

        static void RunExperiment(int size)                                 // метод для запуску експерименту з масивом заданого розміру
        {
            double[] data = new double[size];                               // ініціалізація масиву з значеннями по розміру

            Stopwatch sw = new Stopwatch();                                 // створення об'єкта для вимірювання часу виконання

            // --- Послідовна ініціалізація масиву (запис значень в масив) ---
            sw.Start();                                                     // запуск вимірювання часу
            for (int i = 0; i < data.Length; i++)
                data[i] = i + 1;                                            // ініціалізація значень від 1 до n
            sw.Stop();                                                      // зупинка вимірювання часу
            Console.WriteLine("Serial initialization: " + sw.Elapsed.TotalSeconds + " sec");    // виведення результатів вимірювання часу для ініціалізації

            if (size > 1000) data[1000] = -10;                              // якщо розмір масиву більше 1000, вставляється від'ємне значення на позицію 1000

            string[] operations = { "x / 10", "x / pi", "e^x / x^pi", "e^pi*x / x^pi" };        // масив з різними математичними операціями для тестування

            foreach (string operation in operations)                        // перебір операцій для трансформації значень в масиві
            {
                Console.WriteLine($"\nOperation: {operation}");             // виведення назви поточної операції

                // --- Послідовне виконання операції длґ кожного елементу масиву ---
                sw.Restart();                                               // перезапуск таймера
                for (int i = 0; i < data.Length; i++)
                    Transform(ref data[i], operation);                      // виконання операції трансформації
                sw.Stop();                                                  // зупинка таймера
                Console.WriteLine("Serial execution: " + sw.Elapsed.TotalSeconds + " sec");    // виведення часу для послідовного виконання операції

                // --- Паралельне виконання операції з використанням Parallel.ForEach ---
                sw.Restart();                                               // перезапуск таймера
                Parallel.ForEach(data, (value, state, index) =>
                {
                    double temp = value;                                    // локальна змінна для уникнення конфліктів при доступі до спільних даних

                    Transform(ref temp, operation);                         // виконання операції трансформації над локальною змінною

                    data[index] = temp;                                     // запис результату назад в масив
                });
                sw.Stop();                                                  // зупинка таймера
                Console.WriteLine("Parallel execution (ForEach): " + sw.Elapsed.TotalSeconds + " sec");    // виведення часу для паралельного виконання операції
            }
        }

        static void Transform(ref double x, string operation)               // метод для трансформації значення на основі вибраної операції
        {
            if (x < 0) return;                                              // якщо значення від'ємне, не виконувати операцію

            switch (operation)                                              // вибір операції та трансформація значення
            {
                case "x / 10":
                    x = x / 10;                                             // операція ділення на 10
                    break;
                case "x / pi":
                    x = x / Math.PI;                                        // операція ділення на число π
                    break;
                case "e^x / x^pi":
                    x = Math.Exp(x) / Math.Pow(x, Math.PI);                 // операція e^x / x^π
                    break;
                case "e^pi*x / x^pi":
                    x = Math.Exp(Math.PI * x) / Math.Pow(x, Math.PI);       // операція e^(π*x) / x^π
                    break;
            }
        }
    }
}
