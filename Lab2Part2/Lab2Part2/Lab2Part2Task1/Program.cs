using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Part2Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.\n");
            int[] sizes = { 100000, 1000000, 10000000 };           // масив розмірів, для яких буде проведено тестування

            foreach (int size in sizes)                            // ітерація по всіх розмірах масиву для аналізу продуктивності
            {
                Console.WriteLine($"Testing with array size: {size}\n");
                RunExperiment(size);
            }

            Console.WriteLine("Main() is done.");
            Console.ReadLine();                                    // очікування вводу користувача перед завершенням програми
        }

        static void RunExperiment(int size)
        {
            double[] data = new double[size];                      // ініціалізація масиву вказаного розміру
            Stopwatch sw = new Stopwatch();                        // об'єкт для вимірювання часу виконання

            sw.Start();                                            // послідовна ініціалізація масиву значеннями (1, 2, 3, ...)
            for (int i = 0; i < data.Length; i++)
                data[i] = i + 1;
            sw.Stop();
            Console.WriteLine("Serial initialization: " + sw.Elapsed.TotalSeconds + " sec");

            if (size > 1000) data[1000] = -10;                     // вставка від'ємного значення в масив (для тестування поведінки коду)

            string[] operations = { "x / 10", "x / pi", "e^x / x^pi", "e^pi*x / x^pi" };   // операції, які будуть виконуватися над кожним елементом масиву

            foreach (string operation in operations)
            {
                Console.WriteLine($"\nOperation: {operation}");

                sw.Restart();                                      // послідовне виконання операції
                for (int i = 0; i < data.Length; i++)
                    Transform(ref data[i], operation);             // виконання математичної операції
                sw.Stop();
                Console.WriteLine("Serial execution: " + sw.Elapsed.TotalSeconds + " sec");

                sw.Restart();                                      // паралельне виконання за допомогою Parallel.ForEach з використанням лямбда-виразу
                Parallel.ForEach(
                    data.Select((value, index) => (value, index)), // створення колекції пар (значення, індекс)
                    item =>
                    {
                        double temp = item.value;                  // використання локальної змінної для уникнення конфліктів доступу
                        Transform(ref temp, operation);            // обробка елемента за допомогою вказаної операції
                        data[item.index] = temp;                   // запис результату назад у масив за відповідним індексом
                    }
                );
                sw.Stop();
                Console.WriteLine("Parallel execution (ForEach with lambda): " + sw.Elapsed.TotalSeconds + " sec");
            }
        }

        static void Transform(ref double x, string operation)      // метод для виконання операцій трансформації над значеннями масиву
        {
            if (x < 0) return;                                     // ігнорування від'ємних значень, щоб уникнути помилок обчислень
            switch (operation)
            {
                case "x / 10":
                    x = x / 10;                                    // ділення значення на 10
                    break;
                case "x / pi":
                    x = x / Math.PI;                               // ділення значення на число Пі
                    break;
                case "e^x / x^pi":
                    x = Math.Exp(x) / Math.Pow(x, Math.PI);        // ділення експоненціальної функції на x^π
                    break;
                case "e^pi*x / x^pi":
                    x = Math.Exp(Math.PI * x) / Math.Pow(x, Math.PI); // ділення e^(π*x) на x^π
                    break;
            }
        }
    }
}
