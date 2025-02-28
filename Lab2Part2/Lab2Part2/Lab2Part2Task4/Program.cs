using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Part2Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.\n");              // виведення повідомлення про старт головного потоку

            int[] sizes = { 100000, 1000000, 10000000 };                  // різні розміри масивів для тестування

            foreach (int size in sizes)                                   // цикл по всіх розмірах масиву для перевірки продуктивності
            {
                Console.WriteLine($"Testing with array size: {size}\n");  // виведення поточного розміру масиву

                RunExperiment(size);                                      // запуск експерименту для поточного розміру масиву
            }

            Console.WriteLine("Main() is done.");                         // повідомлення про завершення основного методу

            Console.ReadLine();                                           // очікування вводу користувача перед завершенням програми
        }

        static void RunExperiment(int size)
        {
            double[] data = new double[size];                             // створення масиву заданого розміру
            Stopwatch sw = new Stopwatch();                               // об'єкт для вимірювання часу виконання

            sw.Start();                                                   // послідовна ініціалізація масиву значеннями
            for (int i = 0; i < data.Length; i++)
                data[i] = i + 1;
            sw.Stop();
            Console.WriteLine("Serial initialization: " + sw.Elapsed.TotalSeconds + " sec");  // виведення часу для послідовної ініціалізації масиву

            if (size > 1000) data[1000] = -10;                           // вставка від'ємного значення на певну позицію (як тестовий випадок)

            string[] operations = { "x / 10", "x / pi", "e^x / x^pi", "e^pi*x / x^pi" };      // математичні операції, які будуть застосовуватись до елементів масиву

            foreach (string operation in operations)                    // перебір операцій для трансформації значень в масиві
            {
                Console.WriteLine($"\nOperation: {operation}");         // виведення назви поточної операції

                sw.Restart();                                           // послідовне виконання операції
                for (int i = 0; i < data.Length; i++)
                    Transform(ref data[i], operation);
                sw.Stop();
                Console.WriteLine("Serial execution: " + sw.Elapsed.TotalSeconds + " sec");  // виведення часу для послідовного виконання операції

                sw.Restart();                                          // паралельне виконання з використанням Parallel.ForEach з лямбда-виразом
                Parallel.ForEach(
                    data.Select((value, index) => (value, index)),     // створення переліку пар (значення, індекс)
                    item =>
                    {
                        double temp = item.value;                      // локальна змінна для уникнення конфлікту доступу при оновленні масиву
                        Transform(ref temp, operation);                // застосування математичної операції до тимчасового значення
                        data[item.index] = temp;                       // запис зміненого значення назад у масив за його індексом
                    }
                );
                sw.Stop();
                Console.WriteLine("Parallel execution (ForEach with lambda): " + sw.Elapsed.TotalSeconds + " sec");   // виведення часу для паралельного виконання операції з лямбда-виразом
            }
        }

        static void Transform(ref double x, string operation)          // метод для трансформації значення за вибраною операцією
        {
            if (x < 0) return;                                         // пропуск від'ємних значень, щоб уникнути математичних помилок

            switch (operation)                                         // вибір операції та трансформація значення
            {
                case "x / 10":
                    x = x / 10;                                        // ділення значення на 10
                    break;
                case "x / pi":
                    x = x / Math.PI;                                   // ділення значення на число Пі
                    break;
                case "e^x / x^pi":
                    x = Math.Exp(x) / Math.Pow(x, Math.PI);            // експонента поділена на x в степені Пі
                    break;
                case "e^pi*x / x^pi":
                    x = Math.Exp(Math.PI * x) / Math.Pow(x, Math.PI);  // експонента (Пі * x) поділена на x в степені Пі
                    break;
            }
        }
    }
}
