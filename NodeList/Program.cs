using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeList
{
    class Program
    {
        static void Main()
        {
            LinkedList myList = new LinkedList();
            //LinkedList<object> myList1 = new System.Collections.Generic.LinkedList<Object>();

            myList.Add('a');
            myList.Add('z');
            myList.Add('b');
            myList.Add('z');
            myList.Add('c');
            myList.Add('z');
            myList.Add('d');

            LinkedList myList2 = new LinkedList();
            myList2.Add("1");
            myList2.Add("2");
            myList2.Add("3");
            myList2.Add("4");
            //myList.Set(0, 'z');

            //myList.Insert(0, 'z');
            //myList.AddFirst('z');
            //myList.Clear();
            //bool contained = myList.Contains('a');
            //Console.WriteLine($"{myList.GetFirst()}");
            //Console.WriteLine($"{myList.GetLast()}");

            //int index = myList.IndexOf('z');
            //int count = myList.GetCountOf('a');
            //object elem = myList.Remove(2);
            //
            //myList.RemoveFirst();
            //object lastData = myList.RemoveLast();

            myList.RemoveAll('z');

            //object[] myListToArray = myList.ToArray();
            //string myString = myList.ToString();
            //Console.WriteLine(myString);
            myList = myList + myList2;

            Console.ReadKey();
        }
    }
}
