using System;
using System.Linq;
namespace Study
{
    

    #region class
    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }
        public static int Minus(int a, int b)//정적메소드도 참조할 수 있다.
        {
            return a - b;
        }
    }

    #endregion

    class MainApp
    {
        static void Main(string[] args)
        {
            func f = new func();
            //f.CallbackExample();
            //f.CompareDelegateExample();
            //f.GenericCompareExample();
            //f.ChainExample();
            //f.EventExample();
            //f.DelegateTestAnswer2()
            f.DelegateChainExample()
            ;
            //f.LinqExample();

        }
    }

    #region delegate
    delegate int MyDelegate(int a, int b);
    delegate void MyDelegate2(int a);
    delegate int Compare(int a, int b);
    delegate int Compare<T>(T a, T b);
    delegate void ThereIsAFire(string location);
    delegate void Notify(string message);
    delegate void EventHandler(string message);

    #endregion


    #region function
    class func
    {
        class Woman
        {
            public string name { get; set; }
            public int age { get; set; }
        }
        public void LinqExample()
        {
            Woman[] WomanList =
            {
                new Woman() { name = "아라", age = 24 },
                new Woman() { name = "민희", age = 20 },
                new Woman() { name = "현아", age = 32 },
                new Woman() { name = "수지", age = 20 }
            };
            var Women = from woman in WomanList
                        where woman.age > 20
                        orderby woman.age ascending
                        select new
                        {
                            title = "성인여자",
                            name = woman.name
                        };
            foreach (var woman in Women)
                Console.WriteLine("{0} : {1}", woman.title, woman.name);
        }


        class Market
        {
            public event MyDelegate2 CustomerEvent;
            public void Buysomething(int CustomerNo)
            {
                if (CustomerNo == 30)
                    CustomerEvent(CustomerNo);
            }
        }
        public void DelegateTestAnswer2()
        {
            Market market = new Market();
            market.CustomerEvent += new MyDelegate2(delegate(int a) { Console.WriteLine("축하합니다! {0}번째 고객 이벤트에 당첨되셨습니다.", a); });//축하합니다 30번째 고객 이벤트에 당첨되셨습니다.
            for(int customerNo= 0; customerNo < 100; customerNo += 10)
            {
                market.Buysomething(customerNo);
            }
        }
        public void DelegateTestAnswer1()
        {
            MyDelegate Callback;
            Callback = new MyDelegate(delegate(int a,int b) { return a + b; });
            Console.WriteLine(Callback(3, 4));

            Callback =new MyDelegate(delegate(int a, int b) { return a - b; });
            Console.WriteLine(Callback(7, 5));
        }

        class MyNotifier
        {
            public event EventHandler SomethingHappened;
            public void DoSomething(int number)
            {
                int tmp = number % 10;
                if(tmp!=0 && tmp % 3 == 0)//number가 3,6,9로 끝나면 이벤트가 발생한다.
                {
                    SomethingHappened(String.Format("{0} : 짝", number));//짝이라는
                }
            }
        }
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }
        public void EventExample()
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler);//메세지가 들어오면 출력해주는 이벤트를 이벤트 핸들러에 등록했다.

            for(int i = 1; i < 30; i++)
            {
                notifier.DoSomething(i); //숫자를 넣으면서, Do Something하다가 만족하는 조건이 생기면// 이벤트가 발생한다.
                //발생조건을 바꾸려면 DoSomehing을 바꾸든지, 이벤트 핸들러에 다른걸 등록하든지!!
            }
        }


        public void ChainExample()
        {
            // 1. notifier을 선언한다.
            Notifier notifier = new Notifier();
            // listener1,2,3 이라는 이름을 가진 EventLister를 생성한다.
            EventListener listener1 = new EventListener("Listener1");
            EventListener listener2 = new EventListener("Listener2");
            EventListener listener3 = new EventListener("Listener3");

            //EventOccured라는 Notify 객체에 SomethingHappend라는 함수들을 연결하기 시작한다. (+=를 사용해서)
            // @ somethingHappend는 name과 message를 출력해주는 함수이다.
            notifier.EventOccured += listener1.SomethingHappend;//인자는 어디로간거지?
            notifier.EventOccured += listener2.SomethingHappend;
            notifier.EventOccured += listener3.SomethingHappend;
            notifier.EventOccured("You've got mail"); // ->이곳에서 한번에 인자를 전달해주었다. 어차피 delegate는 모두 인자가 같기 때문이다.
            Console.WriteLine();//그리고 인자가 전달됨과 동시에 Listener1,2,3이 모두 동작하였다.

            notifier.EventOccured -= listener2.SomethingHappend; // 2번 listener연결을 끊어주었다.
            notifier.EventOccured("Download complete.");//이제는 Listener1,3이 동작한다. 2번은 ㅂㅂ했기 때문이다.
            Console.WriteLine();

            //이번에는 새롭게대입을 해주었다. 이제는 기존에있던거 reset하고 새롭게 넣어준다.
            //어차피 EventOccured가 Notify이므로, Notify객체로 알아서 잘 들어갈 테지만, 그냥 new 키워드를 넣어준 모양이다.
            notifier.EventOccured = new Notify(listener2.SomethingHappend)
                                  + new Notify(listener3.SomethingHappend)
                                  + new Notify(delegate (string s) {//익명함수를 사용해서 delegate 구현하기
                                      if (s == "Nuclear launch detected.")
                                      {
                                          Console.WriteLine("detected?");
                                      }
                                      else
                                      {
                                          Console.WriteLine("something wrong");
                                      }
                                  });
            notifier.EventOccured("Nuclear launch detected.");
            Console.WriteLine();

            ///Delegate의 Combine과 Remove 메소드 사용해보기
            //Notify notify1 = new Notify(listener1.SomethingHappend);
            //Notify notify2 = new Notify(listener2.SomethingHappend);

            //notifier.EventOccured = (Notify)Delegate.Combine(notify1, notify2);
            //notifier.EventOccured("Fire!!");
            //Console.WriteLine();

            //notifier.EventOccured = (Notify)Delegate.Remove(notifier.EventOccured, notify2);
            //notifier.EventOccured("RPG!");

        }
        class Notifier
        {
            public Notify EventOccured;// Notify 델리게이트 인스턴스를 가지고 있는 Notifier 선언
        }
        class EventListener
        {
            private string name;
            public EventListener(string name)
            {
                this.name = name;
            }
            public void SomethingHappend(string message)
            {
                Console.WriteLine("{0}.SomethingHappened : {1} ", name, message);
            }
        }

        public void DelegateChainExample()
        {
            //델리게이트 체인 여러개의 델리게이트를 연결해서 사용한다.
            //+ 로 사슬을 연결한다. 끊어낼때는 - 연산자를 사용하면 된다.

            // + 연산자 사용하기
            ThereIsAFire Fire = new ThereIsAFire(Call119)
                              + new ThereIsAFire(ShotOut)
                              + new ThereIsAFire(Escape);

            // Delegate.Combine()메소드 사용하기
            ThereIsAFire Fire2 = (ThereIsAFire)
                Delegate.Combine(new ThereIsAFire(Call119),
                                 new ThereIsAFire(ShotOut),
                                 new ThereIsAFire(Escape));
            Fire("응용소프트웨어실습");
        }

        void Call119(string location)
        {
            Console.WriteLine("여보세요, 소방서죠? 불이 났어요!! 주소는 {0} 입니다.", location);
        }
        void ShotOut(string location)
        {
            Console.WriteLine("피하세요! {0}에 불이 났어요!!",location);
        }
        void Escape(string location)
        {
            Console.WriteLine("{0}에서 어서빨리 나갑시당",location);
        }

        public void GenericCompareExample()
        {
            Console.WriteLine("Sorting ascending...");
            int[] array = { 3, 7, 4, 2, 10 };
            //int array를 정렬할 것이므로, Compare<int>를 호출한다.
            //어떤기준으로 Compare을 사용할 것인지는 인자에 AscendCompare을 넣어서 사용하게된다.
            BubbleSort<int>(array, new Compare<int>(AscendCompare));
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array[i]);

            Console.WriteLine("\nSorting descending...");
            string[] array2 = { "abc", "def", "ghi", "jkl", "mno" };
            //이번엔 string 배열을 정렬할 것이므로 Compare<string>을 사용한다.
            BubbleSort<string>(array2, new Compare<string>(DescendCompare));
            for (int i = 0; i < array2.Length; i++)
                Console.Write("{0} ", array2[i]);
            Console.WriteLine();

        }
        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);//매개변수보다 크면1, 같으면0, 작으면-1을 반환하는 메소드 : IComparable<T>로부터 상속받았다.
        }
        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) * -1;
        }
        static void BubbleSort<T> (T[] DataSet, Compare<T> Comparer)
        {
            for(int i = 0; i < DataSet.Length - 1; i++)
            {
                for(int j=0;j<DataSet.Length - (i + 1); j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        T temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }

        public static int AscendCompare(int a, int b)
        {
            if (a > b) return 1;
            else if (a == b) return 0;
            else return -1;
        }
        public static int DescendCompare(int a, int b)
        {
            if (a < b) return 1;
            else if (a == b) return 0;
            else return -1;
        }
        public static void BubbleSort(int[] DataSet, Compare Comparer)
        {
            int temp = 0;
            for (int i = 0; i < DataSet.Length - 1; i++)
            {
                for (int j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }

        }
        public void CompareDelegateExample()
        {
            int[] array = { 3, 7, 4, 2, 10 };
            Console.WriteLine("Sorting ascending...");
            // BubbleSort에 새로운 Compare을 주는데, 이 Compare은 delegate이고, 아직 정해지지 않았으나 Compare을 수행할것이다.
            // 그것으로 가능한것은 Compare형식과 같은 함수면 모두 되는데, 이중에 Ascending, Descending 함수를 사용해볼 것이다.
            BubbleSort(array, new Compare(AscendCompare));
            for(int i = 0; i < array.Length; i++)
                Console.Write("{0} ",array[i]);
            
            int[] array2 = { 7, 2, 8, 10, 11 };
            Console.WriteLine("\nSorting descending...");
            BubbleSort(array2, new Compare(DescendCompare));
            for (int i = 0; i < array2.Length; i++)
                Console.Write("{0} ", array2[i]);
            Console.WriteLine();

        }

        public void CallbackExample()
        {
            Calculator Calc = new Calculator();
            MyDelegate Callback;

            Callback = new MyDelegate(Calc.Plus);
            Console.WriteLine(Callback(3, 4));

            Callback = new MyDelegate(Calculator.Minus);
            Console.WriteLine(Callback(7, 5));
        }
    }
    #endregion

}

