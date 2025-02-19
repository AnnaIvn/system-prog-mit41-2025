using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2._9FourthTask
{
    class Program
    {
        static void MyMeth1()     // метод1, що виконується як задача
        {
            Console.WriteLine("MyMeth1() is started.");
            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In the method MyMeth1() counter = " + count);
            }
            Console.WriteLine("MyMeth1() is done.");
        }

        static void MyMeth2()     // метод2, що виконується як задача
        {
            Console.WriteLine("MyMeth2() is started.");
            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In the method MyMeth2() counter = " + count);
            }
            Console.WriteLine("MyMeth2() is done.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            Parallel.Invoke(MyMeth1, MyMeth2);           // виконуємо паралельно два іменованих методи

            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}
