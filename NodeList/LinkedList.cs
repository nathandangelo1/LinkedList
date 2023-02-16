using System;
using System.Collections.Generic;
using System.Reflection;

class LinkedList
{
    private Node _head = null;
    private int _count = 0;

    public int Count
    {
        get { return _count; }
        private set { _count = value; }
    }//end property

    public LinkedList()
    {
    }

    public static LinkedList operator +(LinkedList one, LinkedList two)
    {
        if (one._head == null || two._head == null)
        {
            throw new NullReferenceException();
        }

        Node currentNode = one._head;

        int i = 0;
        while (i < one._count - 1)
        {
            currentNode = currentNode.Next;
            i++;
        }
        currentNode.Next = two._head;
        one._count += two._count;

        return one;
    }

    public override string ToString()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }
        string myString = "[ ";
        Node currentNode = _head;

        int i = 0;
        while (i < _count - 1)
        {
            myString += currentNode.ToString() + ", ";

            currentNode = currentNode.Next;
            i++;
        }

        myString += currentNode.ToString() + " ]";
        return myString;
    }

    public object[] ToArray()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        object[] objects = new object[_count];

        Node currentNode = _head;

        int i = 0;
        while (i < _count)
        {
            objects[i] = currentNode.Data;

            currentNode = currentNode.Next;
            i++;
        }
        return objects;
    }

    public Boolean RemoveAll(object element)
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        int index = IndexOf(element);

        while (index != -1)
        {
            
            if (index == -1)
            {
                return false;
            }
            
            object elem = Remove(index);
            
            index = IndexOf(element);
        }

        return true;
    }

    public Boolean RemoveValue(object element)
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        int index = IndexOf(element);

        if (index == -1)
        {
            return false;
        }

        object elem = Remove(index);

        return true;
    }


    public object RemoveLast()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        Node currentNode = _head;

        int i = 0;
        while (i < Count - 2)
        {
            currentNode = currentNode.Next;
            i++;
        }

        Node newLast = currentNode;
        Count -= 1;
        Node returnValue = newLast.Next;
        newLast.Next = null;

        return returnValue.Data;
    }

    public object RemoveFirst()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        Node firstNode = _head;
        _head = _head.Next;
        Count -= 1;
        return firstNode.Data;
    }

    public object Remove(int index)
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        Node currentNode = _head;
        Node previous = new();
        Node next = new();
        Object returnElm = null;

        int i = 0;
        while (i < Count)
        {
            if (i == index - 1)
            {
                previous = currentNode;
                returnElm = currentNode.Next.Data;
            }
            if (i == index + 1)
            {
                next = currentNode;
                break;
            }
            currentNode = currentNode.Next;
            i++;
        }
        previous.Next = next;
        Count -= 1;

        return returnElm;

    }

    public int GetCountOf(object element)
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        Node currentNode = _head;
        int index = 0;
        int count = 0;

        while (index < Count)
        {
            if (currentNode.Data.Equals(element))
            {
                count++;
            }
            currentNode = currentNode.Next;
            index++;
        }

        if(count == 0)
        {
            return -1;
        }
        else
        {
            return count;
        }
       
    }

    public int IndexOf(object element)
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        Node currentNode = _head;
        int index = 0;

        while (index < Count)
        {
            if (currentNode.Data.Equals(element))
            {
                return index;
            }
            currentNode = currentNode.Next;
            index++;
        }

        return -1;

    }

    public object GetLast()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        Node currentNode = _head;
        int index = 0;

        while(index < Count - 1)
        {
            currentNode = currentNode.Next;
            index++;
        }
        Node last = currentNode;

        return last.Data;

    }

    public object GetFirst()
    {
        if(_head == null) 
        { 
            throw new NullReferenceException(); 
        }

        return _head.Data;
    }

    //private bool ObjectIsEqual(object obj1, object obj2)
    //{
    //    if(obj1.GetHashCode() == obj2.GetHashCode())
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    public bool Contains(object element)
    {
        //REFRENCE HEAD OF LIST
        Node currentNode = _head;
        int currentIndex = 0;

        //LOOP UNTIL END WE REACH THE INDEX
        while (currentIndex < Count)
        {
            //bool IsEqual = ObjectIsEqual(element, currentNode.Data);
            bool IsEqual = currentNode.Data.Equals(element);
            if (IsEqual)
            {
                return true;
            }
           
            currentNode = currentNode.Next;
            currentIndex += 1;
        }//end while
        

        return false; 

    }

    public void Clear()
    {
        Node newHead = new();
        _head = newHead;
        Count = 0;
    }

    public void AddFirst(object element)
    {
        Insert(0, element);
    }

    public void Insert(int index, object element)
    {
        //SAFETY CHECKS
        if (index >= Count || index < 0)
        {
            throw new IndexOutOfRangeException($"Index is outside the bounds of the LinkedList. List is {Count} in size. index is currently {index}");
        }//end if 

        //REFRENCE HEAD OF LIST
        Node currentNode = _head;
        int currentIndex = 0;
            
        Node newNode = new(element);

        if (index == 0)
        {
            Node oldHead = _head;
            _head = newNode;
            newNode.Next = oldHead;
        }
        else
        {
            //LOOP UNTIL END WE REACH THE INDEX
            while (currentIndex < index - 1)
            {
                currentNode = currentNode.Next;
                currentIndex += 1;
            }//end while

            Node newNext = currentNode.Next;

            currentNode.Next = newNode;
            newNode.Next = newNext;

        }
    }

    public void Set(int index, object element)
    {
        //SAFETY CHECKS
        if (index >= Count || index < 0)
        {
            throw new IndexOutOfRangeException($"Index is outside the bounds of the LinkedList. List is {Count} in size. index is currently {index}");
        }//end if 

        //REFRENCE HEAD OF LIST
        Node currentNode = _head;
        int currentIndex = 0;

        //LOOP UNTIL END WE REACH THE INDEX
        while (currentIndex < index)
        {
            currentNode = currentNode.Next;
            currentIndex += 1;
        }//end while

        currentNode.Data = element;
        //return true;
    }

    public object Get(int index)
    {
        //SAFETY CHECKS
        if (index >= Count || index < 0)
        {
            throw new IndexOutOfRangeException($"Index is outside the bounds of the LinkedList. List is {Count} in size. index is currently {index}");
        }//end if 

        //REFRENCE HEAD OF LIST
        Node currentNode = _head;
        int currentIndex = 0;

        //LOOP UNTIL END WE REACH THE INDEX
        while (currentIndex < index)
        {
            currentNode = currentNode.Next;
            currentIndex += 1;
        }//end while

        //RETURN DATA
        return currentNode.Data;
    }//end method

    public void Add(object value)
    {
        //CREATE NEW NODE & FILL ITS DATA
        Node newNode = new Node(value);

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            //REFRENCE HEAD OF LIST
            Node currentNode = _head;

            //LOOP UNTIL END OF LIST
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }//end while

            //ADD NEW NODE TO END OF LIST
            currentNode.Next = newNode;
        }//end if

        Count += 1;
    }//end method
}

