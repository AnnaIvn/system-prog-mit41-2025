using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Lab2Part2._3
{
    class Program
    {
        static double[] data;
        static void MyTransform(double v, ParallelLoopState pls)    // метод, що служить в якості тіла паралельного циклу
        {
            if (v < 0) pls.Break();                                 // завершити цикл, якщо знайдено від'ємне значення
            Console.WriteLine("Value is :" + v);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");
            data = new double[100000000];  
            for (int i = 0; i < data.Length; i++)                  // ініціювати дані в звичайному циклі for
            {
                data[i] = i;
            }
            data[100000] = -10;                                    // помістити від'ємне значення в масив
            ParallelLoopResult loopResult = Parallel.ForEach(data, MyTransform);    // розпаралелити цикл методом Parallel.For

            if (!loopResult.IsCompleted)                           // перевірити, чи завершився цикл
                Console.WriteLine("ParallelFor was aborted with negative value on iteration " + loopResult.LowestBreakIteration);
                Console.WriteLine("Main() is done.");
                Console.ReadLine();
        }
    }
}