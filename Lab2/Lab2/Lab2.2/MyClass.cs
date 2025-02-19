namespace Lab2._2
{
    internal class MyClass    // Клас, в якому інкапсульований метод MyTask()
    {
        public void MyTask()  // Метод, що виконується в якості задачі
        {
            Console.WriteLine("MyTask() is started.");
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In the method MyTask() counter = " + count);
            }
            Console.WriteLine("MyTask() is done.");
        }
    }
}
