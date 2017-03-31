using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PR2
{
    class Program
    {
        static ManualResetEvent mReset = new ManualResetEvent(false);
        static AutoResetEvent a1Reset = new AutoResetEvent(false);
        static AutoResetEvent a2Reset = new AutoResetEvent(false);
        static AutoResetEvent a3Reset = new AutoResetEvent(false);
        static AutoResetEvent a4Reset = new AutoResetEvent(false);


        static void Main(string[] args)
        {
            Thread t1 = new Thread(ThreadWork1);
            Thread t2 = new Thread(ThreadWork2);
            Thread t3 = new Thread(ThreadWork3);
            Thread t4 = new Thread(ThreadWork4);
            Thread t5 = new Thread(ThreadWork5);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            Console.ReadLine();
        }

        private static void ThreadWork5()
        {
            a3Reset.WaitOne();
            mReset.WaitOne();
            Console.WriteLine("Thread 5");
            a4Reset.Set();
        }

        private static void ThreadWork4()
        {
            a2Reset.WaitOne();
            mReset.WaitOne();
            Console.WriteLine("Thread 4");
            a3Reset.Set();
        }

        private static void ThreadWork3()
        {
            Console.WriteLine("Thread 3");
            mReset.Set();
        }

        private static void ThreadWork2()
        {
            a1Reset.WaitOne();
            mReset.WaitOne();
            Console.WriteLine("Thread 2");
            a2Reset.Set();
        }

        private static void ThreadWork1()
        {
            Console.WriteLine("Thread 1");
            a1Reset.Set();
        }
    }
}
