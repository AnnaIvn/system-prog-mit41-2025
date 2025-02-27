// застосування/використання ідентифікатора задачі 2.3
// #1st task
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2._3SecondTask
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

            Task tsk1 = new Task(MyTask);    // створюємо об'єкти двох задач, що виконують метод MyTask()
            Task tsk2 = new Task(MyTask);

            tsk1.Start();                    // запускаємо задач на виконання
            tsk2.Start();

            Console.WriteLine("Id of task tsk1 = " + tsk1.Id);     // виведимо ідентифікатори задач після їх створення
            Console.WriteLine("Id of task tsk2 = " + tsk2.Id);

            //tsk1.Wait();
            //tsk2.Wait();
            Task.WaitAll(tsk1, tsk2);                   // очікуємо завершення обох задач

            tsk1.Dispose();                             // викликаємо Dispose() для звільнення ресурсів після завершення задач
            tsk2.Dispose();

            Console.WriteLine("Main() is done.");
            Console.ReadLine();                         // очікуємо введення, щоб побачити результат виконання
        }
    }
}
