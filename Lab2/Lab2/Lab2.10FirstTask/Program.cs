using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2._10FirstTask
{
    class Program
    {
        static void MyMeth1()                             // метод1, що виконується як задача
        {
            Console.WriteLine("MyMeth1() is started.");
            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep((int)(200 * Task.CurrentId));  // затримка пропорційна ідентифікатору процесу
                Console.WriteLine("In the method MyMeth1() counter = " + count + " Current ID = " + Task.CurrentId);
            }
            Console.WriteLine("MyMeth1() is done.");
        }

        static void MyMeth2()                  // метод2, що виконується як задача
        {
            Console.WriteLine("MyMeth2() is started.");
            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep((int)(200 * Task.CurrentId));  // затримка пропорційна ідентифікатору процесу
                Console.WriteLine("In the method MyMeth2() counter = " + count + " Current ID = " + Task.CurrentId);
            }
            Console.WriteLine("MyMeth2() is done.");
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(" Current ID = " + Task.CurrentId);

            Parallel.Invoke(MyMeth1, MyMeth2);  // виконуємо паралельно два іменованих методи

            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}
