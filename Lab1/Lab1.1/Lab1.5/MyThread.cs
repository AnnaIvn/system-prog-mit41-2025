using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// passing the argument to the thread 

namespace Lab1._5
{
    internal class MyThread
    {
        public int Count;
        public Thread Thrd;
        public MyThread(string name, int num)
        {
            Count = 0;
            Thrd = new Thread(this.Run);
            Thrd.Name = name;
            //Передати параметр num методу Start()
            Thrd.Start(num);                         // here we pass the num, that says how many times to start this thread
        }
        //У цій формі методу Run() вказується параметр типу object
        void Run(object num)
        {
            Console.WriteLine(Thrd.Name + " exequting to number " + num);
            do
            {
                Thread.Sleep(500);
                Console.WriteLine("In thread " + Thrd.Name + ", Count = " + Count);
                Count++;
            } while (Count <= (int)num);
            Console.WriteLine(Thrd.Name + " completed.");
        }
    }
}
