using Lab1._7;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an option: 0 - Exit, 1 - Run Threads");
            string option = Console.ReadLine();

            if (option == "0") break;
            if (option != "1") continue;

            Console.Write("Enter number of threads (1 to 10): ");
            if (!int.TryParse(Console.ReadLine(), out int threadCount) || threadCount < 1 || threadCount > 10)   // int.TryParse() attempts to convert a string 
            {                                                                                                    // out int threadCount = converted num stored in the threadCount
                Console.WriteLine("Invalid input.");
                continue;
            }

            MyThread[] threads = new MyThread[threadCount];         // list of threads

            for (int i = 0; i < threadCount; i++)                   // for each thread
            {
                Console.WriteLine("Choose priority for thread " + (i + 1) + " (h - Highest, an - AboveNormal, n - Normal, bn - BelowNormal, l - Lowest): ");
                string priorityInput = Console.ReadLine();
                ThreadPriority priority = priorityInput switch     // evaluate an expression and match it against cases
                {
                    "h" => ThreadPriority.Highest,
                    "an" => ThreadPriority.AboveNormal,
                    "n" => ThreadPriority.Normal,
                    "bn" => ThreadPriority.BelowNormal,
                    "l" => ThreadPriority.Lowest,
                    _ => ThreadPriority.Normal                     // if anithing else => set priority to normal
                };
                                                                             //threads[i] element of the threads array
                threads[i] = new MyThread("Thread " + (i + 1), priority);    // create a new instance of the MyThread class
                                                                             // concatenate the string "Thread " with the thread number
            }                                                                // parse the thread's priority
                                                                             // to sum up: creates a new MyThread object for each thread
            foreach (var thread in threads) thread.Start(); // start all threads
            foreach (var thread in threads) thread.Join();  // wait for the finish for every coresponding thread

            Console.WriteLine("All threads completed.");
        }
    }
}