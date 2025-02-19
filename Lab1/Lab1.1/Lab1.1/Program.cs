using Lab1._1;

var myThread = new MyThread("Thread #1.1");  // створюємо внутрішній потік

var newThread = new Thread(myThread.Run);  // create external thread

newThread.Start();  // start thread before cycle

do  // cycle to see when external thread will be running
{
    Console.WriteLine(".");
    Thread.Sleep(100);
} while (myThread.Count != 10);

Console.ReadLine();

