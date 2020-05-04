using System;

namespace mainHW01
{
    class StaticMethod
    {
        public static void Example()
        {
            Console.WriteLine("StaticMethod 클래스 내의 Example 메소드 호출");
        }
    }
    class Example
    {
        static void Main(string[] args)
        {
            StaticMethod.Example();
        }
    }
    public enum Column
    {
        None = 0,
        First = 1<<0,
        Second = 1<<1,
        Third = 1<<2,
        Fourth = 1<<3,
        All = int.MaxValue
    };

    class Program
    {
        void Practice()
        {
            int? variable=null;

            // 1
            if(variable is null)
                variable = 2;

            // 2
            variable ??= 2;

        }
        delegate int Func(int a, int b);
        private void use()
        {
            Func func = (a,b)=>(a+b);
            int t = func(100, 100);
        }
        public static void NullableExample()
        {
            Nullable<int> a; //int? a;
            a = null;
            Console.WriteLine(a);//null
            Console.WriteLine(a.HasValue);//false
            //Console.WriteLine(a.Value); //Exception 
            Console.WriteLine(a.GetValueOrDefault());//int의 default:0

            Console.WriteLine("------------");

            int? b;
            b = 10;
            Console.WriteLine(b);//10
            Console.WriteLine(b.HasValue);//true
            Console.WriteLine(b.Value);//10
            Console.WriteLine(b.GetValueOrDefault());//10
        }

        delegate int Ex(int a, int b);
        delegate void Statement();

        static void LambdaExample()
        {
            // 1. 람다식을 이용한 표현(매개변수 타입 있는 경우)
            Ex ex = (int a, int b) => a + b;
            Console.WriteLine(ex(4, 5));

            // 2. 람다식을 이용한 표현(매개변수 타입 없는 경우)
            Ex ex2 = (a, b) => a + b;
            Console.WriteLine(ex2(4, 5));

            // 3. 델리게이트를 이용한 표현
            Ex ex3 = delegate (int a, int b) { return a + b; };
            Console.WriteLine(ex3(4, 5));

            // 문람다
            Statement st = () =>
            {
                Console.WriteLine("응용 ");
                Console.WriteLine("소프트웨어실습 ");
            };
            st();

        }


        
    }
}
