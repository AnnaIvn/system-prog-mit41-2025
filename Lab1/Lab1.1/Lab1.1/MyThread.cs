﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// creating MyThread here

namespace Lab1._1
{
    internal class MyThread
    {
        public int Count;
        string thrdName;
        public MyThread(string name)
        {
            Count = 0;
            thrdName = name;
        }
        //Точка входу у потік
        public void Run()
        {
            Console.WriteLine(thrdName + " starting.");
            do
            {
                // Призупинення даного потоку
                Thread.Sleep(500);
                Console.WriteLine("In the thread " + thrdName + ", Count=" + Count);
                Count++;
            } while (Count < 10);
            Console.WriteLine(thrdName + " is completed.");
        }
    }
}
