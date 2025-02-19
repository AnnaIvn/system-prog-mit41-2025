using Lab1._2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Main thread is beginning.");
        //Конструюємо об'єкт типу MyThread (поток)
        MyThread mt = new MyThread("Thread #1.2");
        do
        {
            Console.Write(".");
            Thread.Sleep(100);
        } while (mt.Count != 10);
        Console.WriteLine("Main thread is completed.");
        Console.ReadLine();
    }
}
