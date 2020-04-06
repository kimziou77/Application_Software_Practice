using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.Example1(); // file_Copy with Task class
            //p.Example2(); //nothing happened... Task<TResult>를 사용해보았다.
            //p.Example3(); // Task클래스를 이용해서 여러개로 나누고, 행동하기
            p.Example4(); // parallel클래스!!
        }

        void Example4()
        {
            string a, b;
            Console.Write("from : "); a = Console.ReadLine();
            Console.Write("to : "); b = Console.ReadLine();

            long from = Convert.ToInt64(a);
            long to = Convert.ToInt64(b);

            Console.WriteLine("Please press enter to start..");
            Console.ReadLine();
            Console.WriteLine("Started...");

            
            DateTime startTime = DateTime.Now;
            List<long> total = new List<long>();

            Parallel.For( from,to,(long i) =>{
                if (IsPrime(i))
                    total.Add(i);
            });
            DateTime endTime = DateTime.Now;

            TimeSpan ellapsed = endTime - startTime;
            Console.WriteLine("Prime number count between {0} and {1} : {2} ", from, to, total.Count);
            Console.WriteLine("Ellapsed time : {0}", ellapsed);
        }
        static bool IsPrime(long number)
        {
            if (number < 2) return false;
            if (number % 2 == 0 && number != 2) return false;
            for(long i = 2; i < number; i++)
                if (number % i == 0) return false;
            return true;
        }
        void Example3()
        {
            string a,b,c;
            Console.Write("from : ");   a = Console.ReadLine();
            Console.Write("to : ");   b = Console.ReadLine();
            Console.Write("taskCount : ");   c = Console.ReadLine();

            long from = Convert.ToInt64(a);
            long to = Convert.ToInt64(b);
            int taskCount = Convert.ToInt32(c);

            Func<object, List<long>> FindPrimeFunc = (objRange) =>
             {
                 long[] range = (long[])objRange;
                 List<long> found = new List<long>();
                 for (long i = range[0]; i < range[1]; i++)
                 {
                     if (IsPrime(i))
                         found.Add(i);
                 }
                 return found;
             };
            Task<List<long>>[] tasks = new Task<List<long>>[taskCount];
            long currentFrom = from;
            long currentTo = to / tasks.Length;
            for(int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine("Task[{0}] : {1} ~ {2}", i, currentFrom, currentTo);
                tasks[i] = new Task<List<long>>(FindPrimeFunc, new long[] { currentFrom, currentTo });
                currentFrom = currentTo + 1;
                if (i == tasks.Length - 2)
                    currentTo = to;
                else
                    currentTo = currentTo + (to / tasks.Length);
            }
            Console.WriteLine("Please press enter to start..");
            Console.ReadLine();
            Console.WriteLine("Started...");

            DateTime startTime = DateTime.Now;
            foreach (Task<List<long>> task in tasks)
                task.Start();

            List<long> total = new List<long>();
            foreach(Task<List<long>> task in tasks)
            {
                task.Wait();
                total.AddRange(task.Result.ToArray());
            }
            DateTime endTime = DateTime.Now;
            TimeSpan ellapsed = endTime - startTime;
            Console.WriteLine("Prime number count between {0} and {1} : {2} ", from, to, total.Count);
            Console.WriteLine("Ellapsed time : {0}", ellapsed);
        }
        void Example2()
        {
            var myTask = Task<List<int>>.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                List<int> list = new List<int>();
                list.Add(3);
                list.Add(4);
                list.Add(5);
                return list;//Task<TResult>는 TResult형식의 결과를 반환해야한다.
            });

            var mylist = new List<int>();
            mylist.Add(0);
            mylist.Add(1);
            mylist.Add(2);

            myTask.Wait();
            mylist.AddRange(myTask.Result.ToArray());
        }
        void Example1()
        {
            string p = Console.ReadLine();
            //string srcFile = args[0];
            string srcFile = p;
            Action<object> FileCopyAction = (object state) =>
            {
                String[] paths = (String[])state;
                File.Copy(paths[0], paths[1]);
                Console.WriteLine("TaskID: {0}, ThreadID: {1}, {2} was copied to {3}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, paths[0], paths[1]);
            };
            Task t1 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy1" });
            Task t2 = Task.Factory.StartNew(FileCopyAction, new string[] { srcFile, srcFile + ".copy2" });
            t1.Start();
            Task t3 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy3" });
            t3.RunSynchronously();
            t1.Wait();
            t2.Wait();
            t3.Wait();
        }
    }
}
