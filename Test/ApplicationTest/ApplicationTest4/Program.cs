using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest4
{
    class Program
    {
        class Customer
        {
            public int id;
            public string name;
            public Customer(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }
        
        class ItemOrder
        {
            public int oid;
            public int cid;
            public string oItem;
            public string oDate;
            public ItemOrder(int oid,int cid, string oitem, string odate)
            {
                this.oid = oid;
                this.cid = cid;
                oItem = oitem;
                oDate = odate;
            }

        }
        static void Main(string[] args)
        {
            List<Customer> cList = new List<Customer>();
            cList.Add(new Customer(1,"Kim"));
            cList.Add(new Customer(2,"Lee"));
            cList.Add(new Customer(3,"Park"));
            cList.Add(new Customer(4,"Choi"));
            cList.Add(new Customer(5,"Jung"));
            cList.Add(new Customer(6,"Kang"));
            Console.WriteLine("Customers Information");
            Console.WriteLine("CID \t CName");

            foreach (var e in cList)
            {
                Console.WriteLine( e.id + " \t " + e.name);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Orders Information");
            Console.WriteLine("OID \t CID \t OItem \t\tODate");

            List<ItemOrder> oList = new List<ItemOrder>();
            oList.Add(new ItemOrder(1, 1, "Water", "2020-06-01"));
            oList.Add(new ItemOrder(2, 3, "Apple", "2020-06-01"));
            oList.Add(new ItemOrder(3, 2, "Pencil", "2020-06-05"));
            oList.Add(new ItemOrder(4, 3, "T-shirt", "2020-06-07"));
            oList.Add(new ItemOrder(5, 5, "Candy", "2020-06-07"));
            oList.Add(new ItemOrder(6, 1, "Cup", "2020-06-08"));
            oList.Add(new ItemOrder(7, 3, "Brush", "2020-06-14"));
            oList.Add(new ItemOrder(8, 5, "Book", "2020-06-15"));
            foreach (var e in oList)
            {
                Console.WriteLine(e.oid + " \t " + e.cid + " \t " + e.oItem + "    \t" + e.oDate);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("LINQ Result");
            var linq = from os in oList
                       join cs in cList on os.cid equals cs.id
                       orderby os.oid ascending
                       select new { CID = cs.id, CName = cs.name , OID = os.oid, OItem = os.oItem, ODate = os.oDate};

            Console.WriteLine("CID \t CName \t OID \t OItem \t\tODate");
            foreach (var result in linq)
            {
                Console.WriteLine(result.CID + " \t " + result.CName+ " \t " + result.OID+ " \t " + result.OItem+ "     \t" + result.ODate);
            }

        }
    }
}
