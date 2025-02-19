using Lab1._6;

class Program
{
    // setting priorities to the threads

    static void Main()
    {
        MyThread mt1 = new MyThread("With Normal priority.");
        MyThread mt2 = new MyThread("with Above Normal priority.");
        MyThread mt3 = new MyThread("With Highest priority.");

        //Встановити пріоритети для потоків
        //Normal priority
        mt1.Thrd.Priority = System.Threading.ThreadPriority.Normal;
        //Вище середнього
        mt2.Thrd.Priority = System.Threading.ThreadPriority.AboveNormal;
        //Нижче середнього
        mt3.Thrd.Priority = System.Threading.ThreadPriority.Highest;

        //Почати потоки
        mt1.Thrd.Start();
        mt2.Thrd.Start();
        mt3.Thrd.Start();
        mt1.Thrd.Join();
        mt2.Thrd.Join();
        mt3.Thrd.Join();

        Console.WriteLine();
        Console.WriteLine("Thread " + mt1.Thrd.Name + " counted to " + mt1.Count);
        Console.WriteLine("Thread " + mt2.Thrd.Name + " counted to " + mt2.Count);
        Console.WriteLine("Thread " + mt3.Thrd.Name + " counted to " + mt3.Count);
        Console.ReadLine();
    }
}
