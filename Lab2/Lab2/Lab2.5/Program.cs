// використання TaskFactory для запуску задач 2.5
namespace Lab2._5 
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

            Console.WriteLine("MyTask() №" + Task.CurrentId + " is done.");     // завершення виконання задачі з виведенням ідентифікатора
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            Task tsk1 = Task.Factory.StartNew(MyTask);             // створюємо та одразу запускаємо об'єктів двох задач за допомогою TaskFactory
            Task tsk2 = Task.Factory.StartNew(MyTask);


            Console.WriteLine("Id of task tsk1 = " + tsk1.Id);     // вивідимо ідентифікатори задач після їх створення
            Console.WriteLine("Id of task tsk2 = " + tsk2.Id);

            Task.WaitAll(tsk1, tsk2);                              // очікуємо завершення обох задач

            tsk1.Dispose();                                        // викликаємо Dispose() для звільнення ресурсів після завершення задач
            tsk2.Dispose();

            Console.WriteLine("Main() is done.");
            Console.ReadLine();                                    // очікуємо введення, щоб побачити результат виконання
        }
    }
}
