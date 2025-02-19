using Lab1._5;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Main thread is beginning.");
        MyThread mt1 = new MyThread("mt1", 5);
        MyThread mt2 = new MyThread("mt2", 8);
        do
        {
            Console.Write(".");
            Thread.Sleep(100);
        } while (mt1.Thrd.IsAlive | mt2.Thrd.IsAlive) ;
        
        Console.WriteLine("Main Thread is completed.");
        Console.ReadLine();
     }
}