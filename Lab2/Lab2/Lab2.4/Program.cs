// застосування/використання ідентифікатора задачі, різні модифікації, 2.4
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2._4 // використання ідентифікатора задачі
{
    class Program
    {
        static void MyTask() // метод, що виконується як задача
        {
            Console.WriteLine("MyTask №" + Task.CurrentId + " is started.");    // виводимо інформації про початок виконання задачі з ідентифікатором

            for (int count = 0; count < 10; count++)                            // цикл з 10 ітерацій з паузою у 500 мс на кожній ітерації
            {
                Thread.Sleep(500);                                              // затримка для імітації тривалого виконання
                Console.WriteLine("In the method MyTask() №" + Task.CurrentId + " counter = " + count);   // вивід значення лічильника для поточної задачі
            }

            Console.WriteLine("MyTask() №" + Task.CurrentId + " is done.");    // завершення виконання задачі з виведенням ідентифікатора
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            Task tsk1 = new Task(MyTask);   // створюємо об'єкти двох задач, що виконують метод MyTask()
            Task tsk2 = new Task(MyTask);

            
            tsk1.Start();                   // запускаємо задач на виконання
            tsk2.Start();

            Console.WriteLine("Id of task tsk1 = " + tsk1.Id);  // виводимо ідентифікаторів задач після їх створення
            Console.WriteLine("Id of task tsk2 = " + tsk2.Id);

            // 1. Використання методу Wait() для очікування завершення кожної задачі окремо
            tsk1.Wait();
            Console.WriteLine("Task tsk1 is completed.");

            tsk2.Wait();
            Console.WriteLine("Task tsk2 is completed.");

            // 2. Використання методу WaitAll() для очікування завершення всіх задач одночасно
            Console.WriteLine("Using Task.WaitAll()...");
            Task tsk3 = new Task(MyTask);
            Task tsk4 = new Task(MyTask);
            tsk3.Start();
            tsk4.Start();
            Task.WaitAll(tsk3, tsk4);                           // очікуємо завершення обох задач
            Console.WriteLine("All tasks (tsk3 and tsk4) are completed.");

            // 3. Використання методу WaitAny() для очікування завершення будь-якої з задач
            Console.WriteLine("Using Task.WaitAny()...");
            Task tsk5 = new Task(MyTask);
            Task tsk6 = new Task(MyTask);
            tsk5.Start();
            tsk6.Start();
            int completedTaskIndex = Task.WaitAny(tsk5, tsk6); // очікуємо завершення однієї з задач
            Console.WriteLine($"Task №{completedTaskIndex + 5} is completed first.");

            // 4. Використання Dispose() після завершення задач
            tsk1.Dispose();
            tsk2.Dispose();
            tsk3.Dispose();
            tsk4.Dispose();
            //tsk5.Dispose();
            tsk6.Dispose();

            Console.WriteLine("Main() is done.");
            Console.ReadLine(); // очікуємо введення, щоб побачити результат виконання
        }
    }
}
