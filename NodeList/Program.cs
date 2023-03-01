
namespace NodeList;

class Program
{
    static void Main()
    {
        Queue<int> Line = new Queue<int>(1);
        Line.Enqueue(2);
        Line.Enqueue(3);
        Line.Enqueue(4);


        Console.WriteLine(Line.Dequeue());
        Console.WriteLine(Line.Dequeue());

        Console.WriteLine(Line.Peek());
        Console.WriteLine(Line.PeekRear());

        DataStructures.MathProblem.GetData();
        
        Console.ReadKey();
    }
}
