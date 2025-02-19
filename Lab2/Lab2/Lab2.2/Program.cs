// створення задачі 1.2
namespace Lab2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            MyClass mc = new MyClass();      // створюємо об'єкт типу MyClass

            Task tsk = new Task(mc.MyTask);  // створюємо об'єкт задачі, використовуючи нестатичний метод MyTask()

            tsk.Start();                     // запускаємо задачу на виконання

            for (int i = 0; i < 60; i++)     // залишаємо Main() активним до завершення MyTask()
            {
                Console.Write(".");          // Program is currently running
                Thread.Sleep(100);
            }

            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}