
namespace NodeList;

class Program
{
    static void Main()
    {
        LinkedList<char> myList = new LinkedList<char>();
        // LinkedList<object> myList1 = new System.Collections.Generic.LinkedList<Object>();

        myList.Add('a');
        myList.Add('z');
        myList.Add('b');
        myList.Add('z');
        myList.Add('c');
        myList.Add('z');
        myList.Add('d');

        LinkedList<char> myList2 = new LinkedList<char>();
        myList2.Add('z');
        myList2.Add('z');
        myList2.Add('z');
        myList2.Add('z');
        
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
        myList += myList2;

        myList[1] = 'z';
        var temp = myList[1];
        Console.WriteLine(temp);
        
        Console.ReadKey();
    }
}
