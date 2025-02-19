// використання лямбда-виразу в якості задачі 2.6, ThirdTask
namespace Lab2._6ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");

            Action myLambda = () =>       // оголошуємо лямбда-виразу і збереження в Action
            {
                Console.WriteLine("Lambda_expr is started. Task №" + Task.CurrentId);
                for (int count = 0; count < 10; count++)
                {
                    Thread.Sleep(500);    // затримка для імітації тривалого виконання
                    Console.WriteLine("In the Lambda_expr Task №" + Task.CurrentId + " counter = " + count);
                }
                Console.WriteLine("Lambda_expr is done. Task №" + Task.CurrentId);
            };

            Task tsk1 = Task.Factory.StartNew(myLambda);     // використання лямбда-виразу у двох різних задачах
            Task tsk2 = Task.Factory.StartNew(myLambda);

            Task.WaitAll(tsk1, tsk2);                        // очікуємо виконання обох задач

            tsk1.Dispose();                                  // вивільнюємо задачі після завершення їх виконання
            tsk2.Dispose();

            Console.WriteLine("Main() is done.");
            Console.ReadLine();                              // очікуємо введення, щоб побачити результат виконання
        }
    }
}

