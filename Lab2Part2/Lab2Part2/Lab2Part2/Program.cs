using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab2Part2_1
{
    class Program
    {
        static double[] data;                      // масив, який буде оброблятися паралельно

        static void MyTransform(int i)             // метод, що використовується в якості тіла паралельного циклу
        {
            data[i] /= 10;                         // ділимо елемент масиву на 10

            if (data[i] < 10000)                   // змінюємо значення відповідно до заданих умов
                data[i] = 0;
            else if (data[i] < 20000)
                data[i] = 100;
            else if (data[i] < 30000)
                data[i] = 200;
            else
                data[i] = 300;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");
            Stopwatch sw = new Stopwatch();       // об'єкт для вимірювання часу виконання
              
            data = new double[100000000];         // виділяємо пам'ять під масив

            sw.Start();                           // послідовна ініціалізація масиву
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;                      // заповнюємо масив значеннями
            }
            sw.Stop();
            Console.WriteLine("Serial initialization of cycle = " + sw.Elapsed.TotalSeconds + " seconds.");
            sw.Reset();

            sw.Start();                           // паралельна трансформація масиву
            ParallelLoopResult result = Parallel.For(0, data.Length, MyTransform);
            sw.Stop();
            Console.WriteLine("Parallel transformation = " + sw.Elapsed.TotalSeconds + " seconds.");
            sw.Reset();

            sw.Start();                           // послідовна трансформація масиву
            for (int i = 0; i < data.Length; i++)
            {
                MyTransform(i);
            }
            sw.Stop();
            Console.WriteLine("Serial Transformation = " + sw.Elapsed.TotalSeconds + " seconds.");

            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}
