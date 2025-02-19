using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._4
{
    internal class MyThread
    {
        public int Count;  // counter
        public Thread newThrd; // new instance of a thread
        public MyThread(string name)  // creating and starting new thread
        {
            Count = 0;
            //Конструюємо потік з методу цього об'єкта
            newThrd = new Thread(this.Run);
            newThrd.Name = name;
            //Почати виконання потоку
            newThrd.Start();
        }
        //Точка входження у потік
        public void Run()
        {
            Console.WriteLine(newThrd.Name + " starting.");
            do
            {
                Thread.Sleep(500);
                Console.WriteLine("In the thread " + newThrd.Name + ", Count=" + Count);
                Count++;
            } while (Count < 10);
            Console.WriteLine(newThrd.Name + " is completed.");
        }

    }
}
