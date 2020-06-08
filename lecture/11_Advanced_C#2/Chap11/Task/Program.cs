using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        delegate int MyOperation(int p1, string p2);

        static void Main(string[] args)
        {
            example1();
            //example2();
            //example4();
            //TaskExample();
            //TaskExample2();
            //TaskExample3();
            //Caller();
        }

        public static void example1()
        {
            MyOperation op1 = delegate (int a, string s)
            {
                return a + int.Parse(s);
            };
            MyOperation op2 = (int a, string s) =>
            {
                return a + int.Parse(s) * 2;
            };
            MyOperation op3 = (a, s) =>
            {
                return a + int.Parse(s) * 3;
            };
            MyOperation op4 = (a, s) => a + int.Parse(s) * 4;
            Console.WriteLine(op1(1, "2"));
            Console.WriteLine(op2(1, "2"));
            Console.WriteLine(op3(1, "2"));
            Console.WriteLine(op4(1, "2"));
        }
        public static void example2()
        {
            Action act = () => Console.WriteLine("Lambda one line");
            Action<int> act1 = (int a) => Console.WriteLine(a.ToString());
            Action<uint> act2 = (a) => Console.WriteLine(a.ToString());
            Action<ulong> act3 = a => Console.WriteLine(a.ToString());
            act();
            act1((int)Math.Pow(2, 19) - 1);
            act2((uint)Math.Pow(2, 31) - 1);
            act3((ulong)Math.Pow(2, 61) - 1);
        }
        public static void example4()
        {
            Action<int> act = delegate (int i)
            {
                Console.WriteLine("Work1 ... using {0}", i);
            };
            act += (int i) =>
            {
                Console.WriteLine("Work2 ... using {0}", i);
            };
            act += i =>
            {
                Console.WriteLine("End Log using {0}", i);
            };
            act(11);
        }

        //Task를 잘못 사용하면 교착상태가 발생할 수 있음.
        public static void TaskExample()
        {
            Action action = () =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("printAsync");
            };
            Task t1 = new Task(action);
            t1.Start();//비동기 호출
            Console.WriteLine("Print Sync");
            t1.Wait();
            Console.WriteLine("Main End");
        }
        public static void TaskExample2()
        {//반환값이 없는 Task
            Task t1 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("print Async");
            });
            Console.WriteLine("print Sync");
            t1.Wait();
            Console.WriteLine("Main end");
        }
        public static void TaskExample3()
        {
            Task<double> t1 = Task<double>.Run(() =>
            {
                int max = 10000;
                ulong idx = 0;
                double result = 0;
                for (idx = 0; (int)idx <= max; ++idx)
                {
                    result += idx % 2 == 1 ? 1 / (double)idx : idx * idx;
                }
                return result;
            });
            Console.WriteLine("print Sync");
            Console.WriteLine("result : {0}", t1.Result);
            Console.WriteLine("print sync2");
        }

        async static private void AsyncMethod(int count)
        {
            Console.WriteLine("1...");
            await Task.Run(async () =>
            {
                for (int i = 1; i < count; i++)
                {
                    Console.WriteLine("{0}/{1}", i, count);
                    await Task.Delay(1000);
                }
            });
            Console.WriteLine("2...");
        }
        static void Caller()
        {
            Console.WriteLine("3...");
            AsyncMethod(3);
            Console.WriteLine("4...");
        }
    }
}
