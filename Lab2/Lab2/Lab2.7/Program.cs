// використання ContinueWith() для створення продовження задач 2.7
namespace Lab2._7
{
    class Program
    {
        static void MyTask()                  // метод, що виконується як основна задача
        {
            Console.WriteLine("MyTask №" + Task.CurrentId + " is started.");

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);            // затримка для імітації тривалого виконання
                Console.WriteLine("In the method MyTask() №" + Task.CurrentId + " counter = " + count);
            }

            Console.WriteLine("MyTask() №" + Task.CurrentId + " is done.");
        }

        static void ContTask(Task prevTask)   // метод, що виконується як продовження задачі
        {
            Console.WriteLine("ContTask is started after MyTask №" + prevTask.Id);

            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(400);
                Console.WriteLine("In the method ContTask counter = " + count);
            }

            Console.WriteLine("ContTask is done.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            Task tsk = new Task(MyTask);                       // створюємо об'єкт першої задачі
            Task TaskCont = tsk.ContinueWith(ContTask);        // створюємо продовження задачі

            Task LambdaTaskCont = TaskCont.ContinueWith((first) =>    // створюємо продовження задачі TaskCont, у вигляді лямбда-виразу
            {
                Console.WriteLine("LambdaTaskCont is started after ContTask.");
                for (int count = 0; count < 5; count++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("In the method LambdaTaskCont counter = " + count);
                }
                Console.WriteLine("LambdaTaskCont is done.");
            });

            tsk.Start();                 // запускаємо першу задачу

            LambdaTaskCont.Wait();       // очікуємо завершення всіх задач

            tsk.Dispose();               // викликаємо Dispose() для звільнення ресурсів
            TaskCont.Dispose();
            LambdaTaskCont.Dispose();

            Console.WriteLine("Main() is done.");
            Console.ReadLine();          // очікуємо введення, щоб побачити результат виконання
        }
    }
}
