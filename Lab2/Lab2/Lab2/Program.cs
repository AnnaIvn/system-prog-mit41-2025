// створення задачі 1.1
namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            Task tsk = new Task(DemoTask.MyTask);         // Створюємо об'єкт задачі за допомогою конструктора Task(Action)

            tsk.Start();                                  // Запускаємо задачу на виконання

            for (int i = 0; i < 60; i++)                  // Залишаємо Main() активним до завершення MyTask()
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}