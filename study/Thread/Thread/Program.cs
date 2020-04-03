using System;
using System.Threading;

namespace Thread_study
{
    #region class
    class SideTask
    {
        int count;
        public SideTask(int count)
        {
            this.count = count;
        }
        public void KeepAlive()
        {
            try
            {
                while (count > 0)
                {
                    Console.WriteLine("{0} left", count--);
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count : 0");
            }
            catch(ThreadAbortException e)
            {
                Console.WriteLine(e);
                Thread.ResetAbort();//스레드 취소(종료)
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Thread.ResetAbort();//스레드 취소(종료)
            }
            finally
            {
                Console.WriteLine("Clearing resource...");
            }
        }//Keep Alive 되질 않는데..?  - exam 2
    }
    class Counter
    {
        public int count = 0;
        private readonly object thisLock = new object();
        public void Increase()
        {
            count += 1;
        }
        public void Increase_lock()
        {
            lock (thisLock)
            {
                count += 1;
            }
        }
        //크리티컬 섹션 - 한번에 한 스레드만 사용할 수 있는 코드영억
    }
    class TestCounter
    {
        const int LOOP_COUNT = 1000;
        readonly object thisLock;
        private int count;
        public int Count
        {
            get { return count; }
        }
        public TestCounter()
        {
            thisLock = new object();
            count = 0;
        }
        public void Increase()
        {
            int loopCount = LOOP_COUNT;
            while (loopCount-- > 0)
            {
                lock (thisLock)
                {
                    count++;
                }
                Thread.Sleep(1);
            }
        }
        public void Decrease()
        {
            int loopCount = LOOP_COUNT;
            while (loopCount-- > 0)
            {
                lock (thisLock)
                {
                    count--;
                }
                Thread.Sleep(1);
            }
        }

    }
    #endregion

    class Program
    {
        
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.Example1(); //스레드 시작하기
            //p.Example2(); //스레드 임의로 종료시키기
            //p.Example3(); //Enum
            //p.Example4(); //Thread State
            //p.Example5(); //Syncronization - no-lock
            //p.Example6(); //Syncronization - lock
            p.Example7();

        }
        enum Fruits { Apple, Orange, Kiwi, Mango };
        #region method
        void Example7()
        {
            TestCounter counter = new TestCounter();
            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));
            incThread.Start();//1
            decThread.Start();//0

            incThread.Join();
            decThread.Join();

            Console.WriteLine(counter.Count);
        }



        void Example6()
        {
            Counter c = new Counter();
            Thread t1 = new Thread(new ThreadStart(c.Increase_lock));
            Thread t2 = new Thread(new ThreadStart(c.Increase_lock));
            Thread t3 = new Thread(new ThreadStart(c.Increase_lock));

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine(c.count);
        }
        void Example5()
        {
            /*
             스레드들이 순서를 갖춰 자원을 사용하게 하는것 -> 동기화
             이것을 제대로 하는것이 멀티 스레드프로그래밍을 완벽하게 하는 길이라고 할 수 있다.
             */
            Counter c = new Counter();
            Thread t1 = new Thread(new ThreadStart(c.Increase));
            Thread t2 = new Thread(new ThreadStart(c.Increase));
            Thread t3 = new Thread(new ThreadStart(c.Increase));

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine(c.count);
            // 3일수도, 아닐수도 있다. -> t1이 Increase연산을 하는동안 t2,t3가 Increase연산을 위해 count에 접근을 했다면
            // 모두 0인값을 증가시켜 최종값이 1이나올수 있다.
            // 그렇기 때문에 우리는 싱크를 맞춰줘야 한다. 크리티컬섹션으로 지정해서
            //바로 lock 키워드를 사용하면 된다.

        }
        private static void PrintThreadState(ThreadState state)
        {
            Console.WriteLine("{0,-16} :  {1}", state, (int)state);
        }
        void Example4()
        {
            //두배씩 늘어난다 -> 비트로 현재 어떤 상태에 있는지 확인할 수 있기 때문이다.
            PrintThreadState(ThreadState.Running);
            PrintThreadState(ThreadState.StopRequested);
            PrintThreadState(ThreadState.SuspendRequested);
            PrintThreadState(ThreadState.Background);
            PrintThreadState(ThreadState.Unstarted);
            PrintThreadState(ThreadState.Stopped);
            PrintThreadState(ThreadState.WaitSleepJoin);
            PrintThreadState(ThreadState.Suspended);
            PrintThreadState(ThreadState.AbortRequested);
            PrintThreadState(ThreadState.Aborted);
            PrintThreadState(ThreadState.Aborted|ThreadState.Stopped);

        }
        void Example3()
        {
            Console.WriteLine((Fruits)0);
        }
        void Example2()
        {
            SideTask task = new SideTask(100);
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));
            t1.IsBackground = false;
            Console.WriteLine("Starting Thread...");
            t1.Start();

            Thread.Sleep(100);

            Console.WriteLine("Aborting thread..");
            t1.Abort();

            Console.WriteLine("Wating until thread stops..");
            t1.Join();

            Console.WriteLine("Finished");

        }
        static void DoSomething()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Do Something : {0} ", i);
                    Thread.Sleep(10);//다른 스레드도 CPU를 사용할 수 있도록 CPU점유를 내려놓는다. 밀리초단위
                }
            }
            catch (ThreadAbortException e)
            {

            }
            finally
            {

            }
        }
        void Example1()
        {
            Thread T1 = new Thread(new ThreadStart(DoSomething));
            Console.WriteLine("Starting thread...");
            T1.Start();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main : {0}", i);
                Thread.Sleep(10);
            }
            Console.WriteLine("Waiting until thread stops...");
            T1.Join();

            Console.WriteLine("Finished");
        }
        #endregion
    }
}

