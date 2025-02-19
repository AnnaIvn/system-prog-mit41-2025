using System.Threading;
using Lab1._3;

// adding multipple threads
// using IsAlive property from Thread to know, when each threat is active

class Program
{
    static void Main()
    {
        Console.WriteLine("Main thread is beginning.");
        //Конструюємо декілька потоків (об'єктів типу MyThread)
        MyThread mt1 = new MyThread("Thread #1.3");
        MyThread mt2 = new MyThread("Thread #2.3");
        MyThread mt3 = new MyThread("Thread #3.3");
        do
        {
            Console.Write(".");
            Thread.Sleep(100);
        } while (mt1.newThrd.IsAlive && mt2.newThrd.IsAlive && mt3.newThrd.IsAlive);   // activity check
        Console.WriteLine("Main thread is completed.");
        Console.ReadLine();
    }
}