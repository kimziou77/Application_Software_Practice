using System;
using System.Collections;

namespace basic2
{
    class Practice2
    {
        static void Main(string[] args)
        {
            Practice2 p = new Practice2();
            p.Example1(); //foreach
            //p.Example2(); //foreach2 _ ArrayList
            //p.Example3(); //NullError
            //p.Example4(); //try-catch
            //p.Example5(); //multi try-catch
            //p.Example6(); //ArrayExample
            //p.Example7(); //ArrayExample2
            //p.Example8(); //ArrayExample3
            //p.Example9(); //derived class
            //p.Example10(); //property
            //p.Example11(); //property2
            //p.Example12(); //indexer

        }

        #region class
        class A
        {
            public void PrintA()
            {
                Console.WriteLine("A class function");
            }
        }
        class B : A
        {
            public void PrintB()
            {
                Console.WriteLine("B class function");
            }
        }
        class Date
        {
            int month = 7;
            public int Month
            {
                get { return month; }
                set { if ((value > 0) && (value < 13)) month = value; }
            }
        }
        abstract class Shape
        {
            public abstract double Area
            {
                get;
                set;
            }
        }
        class Square : Shape
        {
            public double side;
            public Square(double s)
            {
                side = s;
            }
            public override double Area
            {
                get { return side * side; }
                set { side = Math.Sqrt(value); }
            }
        }
        class Cube : Shape
        {
            public double side;
            public Cube(double side)    
            {
                this.side = side;
            }
            public override double Area
            {
                get { return 6 * side * side; }
                set { side = Math.Sqrt(value / 6); }
            }
        }
        class MyIndexerClass
        {
            private string[] data = new string[5];
            public int Length
            {
                get { return data.Length; }
            }
            public string this[int index]
            {
                get { return data[index]; }
                set { data[index] = value; }
            }
        }
        #endregion
        #region method
        void Example12()
        {
            MyIndexerClass mic = new MyIndexerClass();
            mic[0] = "Seoul";
            mic[1] = "Nowon";
            mic[2] = "Kwangwoon";
            mic[3] = "-ro 20";
            mic[4] = "Kwangwoon University";
            for(int i = 0; i < mic.Length; i++)
                Console.Write("{0} ", mic[i]);
            Console.WriteLine();
        }
        void Example11()
        {
            Console.Write("Enter the side : ");
            double side = double.Parse(Console.ReadLine());
            Square s = new Square(side);
            Cube c = new Cube(side);

            Console.WriteLine("Area of the square = {0:F2}", s.Area);
            Console.WriteLine("Area of the cube   = {0:F2}", c.Area);

            Console.Write("Enter the area : ");
            double area = double.Parse(Console.ReadLine());

            s.Area = area;
            c.Area = area;
            Console.WriteLine("side of the square = {0:F2}", s.side);
            Console.WriteLine("side of the cube   = {0:F2}", c.side);

        }
        void Example10()
        {
            Date d1 = new Date();
            Console.WriteLine("Default month : {0}\n", d1.Month);
            while (true)
            {
                Console.Write("Enter month : ");
                int inputMonth = int.Parse(Console.ReadLine());
                if (inputMonth == -1) { break; }
                d1.Month = inputMonth;
                Console.WriteLine("Now Month : {0}\n", d1.Month);
            }
        }
        void Example9() {
            B b = new B();
            b.PrintA();
            b.PrintB();
        }
        void Example8()
        {
            int[,] arr = new int[2, 5] { { 3, 5, 7, 4, 1 }, { 4, 5, 7, 8, 9 } };
            Console.WriteLine("{0}", arr.GetLength(0));
            Console.WriteLine("{0}", arr.GetLength(1));
            Console.WriteLine("{0}", arr.Length);
            Console.WriteLine("{0} 차원", arr.Rank);

        }
        void Example7()
        {
            int[] arr1 = new int[5] { 3, 5, 7, 4, 1 };
            int[] arr2 = new int[5] { 9, 3, 6, 5, 2 };
            int[] arr3 = new int[10];
            arr1.CopyTo(arr3, 0);
            arr2.CopyTo(arr3, 5);
            foreach (int item in arr3)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }
        void Example6()
        {
            int[] arr1= new int[5]{ 3,5,7,4,1};
            int[] arr2 = (int[])arr1.Clone();
            foreach(int item in arr2)
            {
                Console.WriteLine("{0}", item);
            }
        }
        void Example5()
        {
            int[] arr1 = { 1, 11, 22, 33 };
            int[] arr2 = { 0, 1, 2 };
            for(int i = 0; i < arr1.Length; i++)
            {
                try
                {
                    Console.WriteLine(arr1[i] + "/" + arr2[i] + "=" + arr1[i] / arr2[i]);
                }
                catch(DivideByZeroException e)
                {
                    Console.WriteLine("Can't divide");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        void Example4()
        {
            String str = null;
            try
            {
                Console.WriteLine(str.ToString());
                Console.WriteLine("Program Terminated");
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                //Console.WriteLine("test");
            }
        }
        void Example3()
        {
            string str = null;
            Console.WriteLine(str.ToString());
            Console.WriteLine("Program Terminated");

        }
        void Example2()
        {
            ArrayList myAL = new ArrayList();
            myAL.Add("Hello");
            myAL.Add("World");
            myAL.Add("!");
            Console.Write("Values : ");
            PrintValues(myAL);

        }
        void PrintValues(ArrayList myList)
        {
            foreach (string text in myList)
                Console.Write("\t{0}", text);
            Console.WriteLine();
        }
        void Example1()
        {
            int[,] values = { { 1, 2, 3, 4, }, { 5, 6, 7, 8 } };
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 4; j++)
                    Console.Write("{0} ", values[i, j]);
            Console.WriteLine();

            foreach (int v in values)
                Console.Write("{0} ", v);

        }

        #endregion

    }


}

