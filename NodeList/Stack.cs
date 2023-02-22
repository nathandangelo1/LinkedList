using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal class Stack<T>
{

    private Node<T> _top = null;
    private Node<T> _bottom;
    private int _count;

    public Stack() { }

    public bool IsEmpty {
        get
        {
            if (_top == null) return true;
            else return false;
        }  
    }

    public int Count { get
        {
            return _count;
        } 
    }

    public void Push(T item)
    {
        //CREATE NEW NODE & FILL ITS DATA
        Node<T> newNode = new Node<T>(item);

        if (_top == null)
        {
            _top = newNode;
            _bottom = newNode;
        }
        else
        {
            Node<T> former = _top;

            _top = newNode;
            _top.Next = former;
        }//end if

        _count++;
  
    }

    public T Pop()
    {
        T popTop = _top.Data;
        _top = _top.Next;

        _count--;

        return popTop;
    }

    public T Peek()
    {
        T peekTop = _top.Data;
        return peekTop;
    }
}
