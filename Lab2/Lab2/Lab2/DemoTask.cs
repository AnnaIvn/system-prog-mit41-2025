namespace Lab2
{
    internal class DemoTask
    {
        public static void MyTask()
        {
            Console.WriteLine("MyTask() is started.");
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In the method MyTask() counter = " + count);        // this task is currently running
            }
            Console.WriteLine("MyTask() is done.");
        }
    }
}
