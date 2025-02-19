using System.Threading;
using Lab1._4;

// multipple threads
// using Join = waits until the thread that it was started for will end
// Join is used to know, when the process ends

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Main thread is beginning.");
        //Сконструювати три потока
        MyThread mt1 = new MyThread("mt1");
        MyThread mt2 = new MyThread("mt2");
        MyThread mt3 = new MyThread("mt3");

        //Приєднати перший потік
        mt1.newThrd.Join();
        Console.WriteLine("Thread №1 is joined");

        //Блокувати викликаючий потік до завершення потоку 
        mt2.newThrd.Join();
        Console.WriteLine("Thread №2 is joined");

        //Приєднати другий потік
        mt3.newThrd.Join();
        Console.WriteLine("Thread №3 is joined");
        Console.WriteLine("Main thread is completed");
        Console.ReadLine();
    }
}
