using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._7
{
    internal class MyThread
    {
        private int count;                           // private counter
        private Thread thread;                       // private field named thread of type Thread
        private static bool stop = false;            // stop flag; when one thread will reach the number -> all others will be stopped
        private static string currentThreadName;

        public MyThread(string name, ThreadPriority priority)                // constructor for MyThread class with two parameters
        {
            count = 0;                                                      // counter within each thread
            thread = new Thread(Run) { Name = name, Priority = priority };  // creates a new instance of the Thread class
        }

        public void Start() => thread.Start();           // method of MyThread class, starts the execution of the thread
        public void Join() => thread.Join();             // method ..., waits until the thread that Join() was called on completes its work.

        private void Run()                               //  method ..., will be executed by each thread when it starts
        {
            Console.WriteLine("Thread " + thread.Name + " starting.");        // thread was started
            do                                                                // code inside will execute repeatedly until the condition after while is no longer true
            {
                count++;
                if (currentThreadName != thread.Name)                         // used to track which thread is currently executing
                {                                                             // changes the name, if needed
                    currentThreadName = thread.Name;
                    //Console.WriteLine("In thread " + currentThreadName);    // shows which thread is currently running
                }
            } while (!stop && count < 1e7);                                   // exit when: this is false (if one of the threads reaches the end number) 
                                                                              // and
            stop = true;                                                      // stop is set to true
            Console.WriteLine("Thread " + thread.Name + " completed with count: " + count);    // show with what count each thread was stopped

        }
    }
}
