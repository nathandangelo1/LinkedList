
namespace NodeList;

class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);

        stack.Pop();

        Console.WriteLine(stack.Peek());
        
        Console.ReadKey();
    }
}
