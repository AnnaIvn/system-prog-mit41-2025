using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab2Part2._4
{
    class Program
    {
        static double[] data;                                     // масив, який буде оброблятися паралельно

        static void MyTransform(double v, ParallelLoopState pls)  // метод, що використовується в якості тіла паралельного циклу
        {
            if (v < 0)                                            // завершити цикл, якщо знайдено від'ємне значення
            {
                pls.Break();
                return;
            }

            double transformedValue = v / 10;                     // ділимо елемент масиву на 10
            
            if (transformedValue < 10000)                         // змінюємо значення відповідно до заданих умов
                transformedValue = 0;
            else if (transformedValue < 20000)
                transformedValue = 100;
            else if (transformedValue < 30000)
                transformedValue = 200;
            else
                transformedValue = 300;

            Console.WriteLine("Value is: " + transformedValue);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");
            Stopwatch sw = new Stopwatch();                       // об'єкт для вимірювання часу виконання

            data = new double[100000000];                         // виділяємо пам'ять під масив

            sw.Start();                                           // послідовна ініціалізація масиву
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;                                      // заповнюємо масив значеннями
            }
            sw.Stop();
            Console.WriteLine("Serial initialization of cycle = " + sw.Elapsed.TotalSeconds + " seconds.");
            sw.Reset();

            data[100000] = -10;                                   // помістити від'ємне значення в масив

            sw.Start();                                           // паралельна трансформація масиву з перевіркою завершення
            ParallelLoopResult result = Parallel.ForEach(data, MyTransform);
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");
            sw.Reset();

            if (!result.IsCompleted)                              // перевірка, чи завершився цикл завчасно
                Console.WriteLine("ParallelForEach was aborted due to a negative value.");

            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}