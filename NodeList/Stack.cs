using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal class Queue2<Type>
{

    private Node<Type> _top = null;
    private Node<Type> _bottom;
    private uint _count;

    public Queue2() { }
    public Queue2(Type item) 
    {
        Push(item); 
    }

    public bool IsEmpty {
        get
        {
            return _top == null;
        }  
    }

    public uint Count { get
        {
            return _count;
        } 
    }

    public void Push(Type item)
    {
        //CREATE NEW NODE & FILL ITS DATA
        Node<Type> newNode = new(item);

        if (_top == null)
        {
            _top = newNode;
            _bottom = newNode;
        }
        else
        {
            Node<Type> former = _top;

            _top = newNode;
            _top.Next = former;
        }//end if

        _count++;
    }

    public Type Pop()
    {
        //if (_top == null)
        //{
        //    throw new NullReferenceException();
        //}

        Type popTop = _top.Data;
        _top = _top.Next;

        _count--;

        return popTop;
    }

    public Type Peek()
    {
        //if (_top == null)
        //{
        //    throw new NullReferenceException();
        //}

        Type peekTop = _top.Data;
        return peekTop;
    }
}
