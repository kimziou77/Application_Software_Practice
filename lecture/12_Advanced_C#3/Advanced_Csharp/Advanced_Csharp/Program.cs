#define TEST
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;


namespace Advanced_Csharp
{
    class Profile
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public void Print()
        {
            Console.WriteLine("{0}, {1} ", Name, Phone);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //example1();
            //example2();
            //example3();
            //example4();
            //example5();
            //example6();
            //example7();
            //example8();
            //example9();
            //example10();
            //example11();
            //example12();
            //example13();
            //example14();
            //example15();
            example16();
        }
        static void example1()//IEnumberable<int> 로 반환 .Where함수
        {
            int[] digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> enumerable = digits.Where(num => num % 2 == 0);
            enumerable.ToList().ForEach(i => Console.WriteLine(i));
        }
        static void example2()// 제일 먼저 조건을 만족하는 인자가 반환됨.
        {
            int[] digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int n = Array.Find<int>(digits, num => num % 2 == 0);
            Console.WriteLine(n);
        }
        static void example3()// Sum
        {
            int[] digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(
                digits.Sum<int>(num =>
                {
                    return (num % 2 == 0) ? 0 : num * num;
                }));
        }
        static void example4()// Sort
        {
            int[] digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> list = digits.ToList();
            list.Sort((x, y) => x < y ? 1 : -1);
            list.ForEach(i => Console.WriteLine(i));
            Console.WriteLine("Other sort");
            list.Sort((x, y) =>
            {
                double temp_x = Math.Pow(-1, x) * 1.0 / x;
                double temp_y = Math.Pow(-1, y) * 1.0 / y;
                return temp_x < temp_y ? -1 : 1;//오름차순으로 정렬됨. 홀수 먼저 그 후 짝수
            });
            list.ForEach(i => Console.WriteLine(i));
        }
        static void example5()//Reflection
        {
            Type type = typeof(Profile);
            Object profile = Activator.CreateInstance(type);
            PropertyInfo name = type.GetProperty("Name");
            PropertyInfo phone = type.GetProperty("Phone");
            name.SetValue(profile, "김수빈", null);
            phone.SetValue(profile, "000-0000", null);
            Console.WriteLine("{0}, {1}", name.GetValue(profile, null), phone.GetValue(profile, null));
        }
        static void example6()//Reflection Method Invoke
        {
            Type type = typeof(Profile);
            Profile profile = (Profile)Activator.CreateInstance(type);
            profile.Name = "김수빈";
            profile.Phone = "000-0000";
            MethodInfo method = type.GetMethod("Print");
            method.Invoke(profile, null);
        }
        static void PrintInterfaces(Type type)
        {
            Console.WriteLine("-----------------interface--------------");
            Type[] interfaces = type.GetInterfaces();
            foreach(Type i in interfaces)
            {
                Console.WriteLine("Name : {0} ", i.Name);
            }
            Console.WriteLine();
        }
        static void PrintField(Type type)
        {
            Console.WriteLine("-----------------Fields--------------");
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public |
                                                BindingFlags.Static | BindingFlags.Instance);
            foreach(FieldInfo fi in fields)
            {
                String accessLevel = "protected";
                if (fi.IsPublic) accessLevel = "public";
                else if (fi.IsPrivate) accessLevel = "private";
                Console.WriteLine("Access Level : {0}, Type : {1}, Name : {2}", accessLevel, fi.FieldType.Name, fi.Name);
            }
            Console.WriteLine();
        }
        static void PrintMethod(Type type)
        {
            Console.WriteLine("-----------------Method--------------");
            MethodInfo[] methods = type.GetMethods();
            foreach(MethodInfo mi in methods)
            {
                Console.Write("Return Type : {0}, Name : {1}, Input Parameter",mi.ReturnType.Name,mi.Name);
                ParameterInfo[] args = mi.GetParameters();
                for(int i=0;i<args.Length; i++)
                {
                    Console.Write("{0}", args[i].ParameterType.Name);
                    if(i<args.Length - 1)
                    {
                        Console.Write(",");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void PrintProperties(Type type)
        {
            Console.WriteLine("-----------------Property--------------");
            PropertyInfo[] properties = type.GetProperties();
            foreach(PropertyInfo pi in properties)
            {
                Console.WriteLine("Type : {0}, Name : {1}", pi.PropertyType.Name, pi.Name);
            }
            Console.WriteLine();
        }
        static void example7()
        {
            int a = 0;
            Type type = a.GetType();
            PrintInterfaces(type);
            PrintField(type);
            PrintMethod(type);
            PrintProperties(type);
        }

        [Conditional("TEST")]
        static void TestConditionalMehtod()
        {
            Console.WriteLine("Conditional 호출 완료");
        }
        static void example8()
        {
            TestConditionalMehtod();
        }

        static void example9()
        {
            Trace.WriteLine("호출!");
        }
        static void example10()
        {
            Type type = typeof(TargetClass);
            Attribute[] atts = Attribute.GetCustomAttributes(type);
            Console.WriteLine("TargetClass change History");
            foreach(Attribute att in atts)
            {
                HistoryAttribute h = att as HistoryAttribute;
                if (h != null)
                {
                    Console.WriteLine("Ver : {0}, Programmer : {1}, Changes : {2}",
                        h.version, h.GetProgrammer(), h.changes);
                }
            }
        }
        static void example11()
        {
            var obj = new { Amount = 108, Message = "hello" };
            var type = obj.GetType();
            Console.WriteLine("obj : {0}", type);
            foreach(var p in type.GetProperties())
            {
                Console.WriteLine("obj's member : {0} ", p);
            }
        }
        static void example12()
        {
            List<Employee> eList = new List<Employee>();
            eList.Add(new Employee("kim", 25));
            eList.Add(new Employee("lee",30));
            eList.Add(new Employee("jung",21));
            eList.Add(new Employee("nam",24));
            eList.Add(new Employee("park",27));
            eList.Add(new Employee("Lim",43));
            eList.Add(new Employee("Woo",37));
            eList.Add(new Employee("Kim",44));
            eList.Add(new Employee("conan",31));
            List<Employee> youngEmplyeeList = new List<Employee>();
            foreach(Employee e in eList)
            {
                if(e.age <= 30)
                {
                    youngEmplyeeList.Add(e);
                }
            }
            foreach(Employee e in youngEmplyeeList)
            {
                Console.WriteLine("Name : " + e.name + ", Age : " + e.age);
            }

        }
        static void example13()
        {
            List<Employee> eList = new List<Employee>();
            eList.Add(new Employee("kim", 25));
            eList.Add(new Employee("lee", 30));
            eList.Add(new Employee("jung", 21));
            eList.Add(new Employee("nam", 24));
            eList.Add(new Employee("park", 27));
            eList.Add(new Employee("Lim", 43));
            eList.Add(new Employee("Woo", 37));
            eList.Add(new Employee("Kim", 44));
            eList.Add(new Employee("conan", 31));
            var younEmployeeList = from e in eList
                                   where e.age <= 30
                                   select e;
            foreach(var e in younEmployeeList)
            {
                Console.WriteLine("Name : " + e.name + " , Age : " + e.age);
            }
        }
        static void example14()
        {
            List<Student> students = GetStudents();
            var booleanGroupQuery = from student in students
                                    group student by student.Scores.Average() >= 80;//pass or fail
            foreach(var studentGroup in booleanGroupQuery)
            {
                Console.WriteLine(studentGroup.Key == true ? "High averages" : "Low averages");
                foreach(var student in studentGroup)
                {
                    Console.WriteLine("{0}, {1}:{2}", student.Last, student.First, student.Scores.Average());
                }
            }
        }
        static void example15()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weeiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };
            Person rui = new Person { FirstName = "Rui", LastName = "Raposo" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = rui };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene, rui };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };
            var query = from person in people
                        join pet in pets on person equals pet.Owner
                        select new { OwnerName = person.FirstName, PetName = pet.Name };
            foreach(var ownerAndPet in query)
            {
                Console.WriteLine("\"{0}\" is owned by{1}", ownerAndPet.PetName, ownerAndPet.OwnerName);
            }

        }
        static void example16()
        {
            DataSet1 dataset = new DataSet1();
            dataset.Tables["Person"].Rows.Add(new object[] { 1, "Kim", 30 });
            dataset.Tables["Person"].Rows.Add(new object[] { 2, "Kong", 35 });
            dataset.Tables["Person"].Rows.Add(new object[] { 3, "Park", 20 });
            dataset.Tables["Person"].Rows.Add(new object[] { 4, "Lee", 22 });
            DataTable persons = dataset.Tables["Person"];
            IEnumerable<DataRow> query = from person in persons.AsEnumerable()
                                         select person;
            foreach(DataRow dr in query)
            {
                Console.WriteLine("Number : {0}, Name ; {1}, Age : {2}",
                    dr["number"], dr["name"], dr["age"]); 
            }

        }
        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>
        {
            new Student {First = "Svetlana", Last = "Omelchenko", ID=111,Scores=new List<int>{97,72,81,60}},
            new Student {First = "Claire", Last = "O'Donnell", ID=112,Scores=new List<int>{75,84,91,39}},
            new Student {First = "Sven", Last = "Mortensen", ID=113,Scores=new List<int>{99,89,91,95}},
            new Student {First = "Cesar", Last = "Garcia", ID=114,Scores=new List<int>{72,81,65,84}},
            new Student {First = "Debra", Last = "Garcia", ID=115,Scores=new List<int>{97,89,85,82}}
        };
            return students;
        }
    }
    class Person 
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }
   
    public static class Trace
    {
        public static void WriteLine(string msg,
            [CallerFilePath] string file = "",
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string member="")
        {
            Console.WriteLine("{0} (Line : {1}) {2} {3}", file, line, member, msg);
        }
    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple =true)]
    class HistoryAttribute : Attribute
    {
        private string programmer;
        public double version;
        public string changes;
        public HistoryAttribute(string programmer)
        {
            this.programmer = programmer;
            this.version = 1.0;
            this.changes = "First Release";
        }
        public string GetProgrammer()
        {
            return programmer;
        }
    }
    [History("SU",version =0.1,changes ="2020.06.17")]
    [History("kim", version = 0.2, changes = "2020.06.17")]
    class TargetClass
    {
        public void Func()
        {
            Console.WriteLine("func() Called");
        }
    }
    class Employee 
    {
        public string name;
        public int age;
        public Employee(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;

    }
    
}
