using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AliceLab2
{
    class Program
    {
            static AutoResetEvent waitHandler = new AutoResetEvent(false);

            public static void Th1()
            {
                Console.WriteLine("Hi,I am 1 th");
            waitHandler.Set();//ВЫСВОБОЖДАЕТ ПОТОКИ
            }
            public static void Th2()
            {
                Console.WriteLine("Hi,I am 2 th");
            waitHandler.Set();

            }
            public static void Th3()
            {
                Console.WriteLine("Hi,I am 3 th");
            waitHandler.Set();

            }
            public static void Th4()
            {
                Console.WriteLine("Hi,I am 4 th");
            waitHandler.Set();
            }
            public static void Th5()
            {
            Console.WriteLine("Hi,I am 5 th");
            waitHandler.Set();
            }
            public static void Th6()
            {
            Console.WriteLine("Hi,I am 6 th");
            }
            public static void stayTh()
            {
            waitHandler.WaitOne();//ЗАДЕРЖИВАЕТ ПОТОКИ

            }

        static void Main(string[] args)
        {

            Thread t1 = new Thread(() => Th1());//Конструктор вызова функции потока 1
            t1.Priority = ThreadPriority.Highest;//Установка самого высокого приоритета 1-му потоку
            t1.Start();//Старт потока 1
            waitHandler.WaitOne();
            Thread t2 = new Thread(() => Th2());
            t2.Start();
            waitHandler.WaitOne();

            Thread t3 = new Thread(() => Th3());
            Thread t4 = new Thread(() => Th4());
            t3.Start();
            waitHandler.WaitOne();
            t4.Start();
            waitHandler.WaitOne();//добавил ~1
            Thread t5 = new Thread(() => Th5());
            waitHandler.Set();//добавил ~1
            t5.Start();
            waitHandler.WaitOne();

            Thread stay = new Thread(() => stayTh());
            stay.Start();
            waitHandler.Set();
            Thread t6 = new Thread(() => Th6());
            t6.Start();


            Console.ReadKey();

        }
    }
}
