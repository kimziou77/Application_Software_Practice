using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Collection1();
            //Collection2();
            //IEnumerableExample();
            DictionaryExample();
            //Application.Run(new Form1());
        }
        static void Collection1()
        {
            List<String> salmons = new List<string>();
            salmons.Add("chinook");
            salmons.Add("coho");
            salmons.Add("pink");
            salmons.Add("sockeye"); ;
            foreach(string salmon in salmons)
            {
                Console.WriteLine(salmon + " ");
            }
        }
        static void Collection2()
        {
            ArrayList myAL = new ArrayList();
            myAL.Add("Hello");
            myAL.Add("World");
            myAL.Add("!");
            Console.WriteLine("Count:   {0}", myAL.Count);
            Console.WriteLine("Capacity:{0}", myAL.Capacity);
            Console.WriteLine("Values: ");
            PrintValues(myAL);
        }
        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("     {0}", obj);
            Console.WriteLine();
        }
        
        public class Person
        {
            public string firstName;
            public string lastName;
            public Person(string fName, string lName)
            {
                this.firstName = fName;
                this.lastName = lName;
            }
        }
        public class People : IEnumerable
        {
            private Person[] _people;
            public People(Person[] pArray)
            {
                _people = new Person[pArray.Length];
                for(int i = 0; i < pArray.Length; i++)
                {
                    _people[i] = pArray[i];
                }
            }
            public IEnumerator GetEnumerator()
            {
                return new PeopleEnum(_people);
            }
        }
        public class PeopleEnum : IEnumerator
        {
            public Person[] _people;
            int position = -1;
            public PeopleEnum(Person[] list)
            {
                _people = list;
            }
            public bool MoveNext()
            {
                position++;
                return (position < _people.Length);
            }
            public void Reset()
            {
                position = -1;
            }
            public object Current
            {
                get
                {
                    try
                    {
                        return _people[position];
                    }
                    catch(IndexOutOfRangeException e)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
        static void IEnumerableExample()
        {
            Person[] peopleArray = new Person[3]
            {
                    new Person("John","Smith"),
                    new Person("Jim","Johnson"),
                    new Person("Sue","Rabon")
            };

            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
                Console.WriteLine(p.firstName + " " + p.lastName);
        }
        static void DictionaryExample()
        {
            Dictionary<string, double> testDictionary =
                new Dictionary<string, double>();
            testDictionary.Add("pi", 3.141592);
            testDictionary.Add("e", 2.71828);
            testDictionary.Add("kong", 2);
            foreach(KeyValuePair<string,double> kvp in testDictionary)
            {
                Console.WriteLine("Key : " + kvp.Key + ", Value : " + kvp.Value);
            }
            Console.WriteLine("Kong : " + testDictionary["kong"]);
        }

    }
}
