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
            myList.Add('a');
            myList.Add('b');
            myList.Add('c');
            myList.Add('d');
            //myList.Set(0, 'z');

            //myList.Insert(0, 'z');
            //myList.AddFirst('z');
            //myList.Clear();
            bool contained = myList.Contains('a');
            //Console.WriteLine($"{myList.GetFirst()}");
            //Console.WriteLine($"{myList.GetLast()}");

            //int index = myList.IndexOf('z');
            //int count = myList.GetCountOf('a');
            //myList.Remove(2);
            //
            //myList.RemoveFirst();
            //object lastData = myList.RemoveLast();

            Console.ReadKey();
        }
    }
}
