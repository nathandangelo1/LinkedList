﻿using System;
using System.Collections.Generic;
using System.Reflection;

public class LinkedList<T> 
{
    private GenericNode<T> _head = null;
    private int _count = 0;

    public int Count
    {
        get { return _count; }
        private set { _count = value; }
    }//end property

    public T this[int index]
    {
        get { return Get(index); }
        set { Set(index, value); }
    }

    public LinkedList()
    {
    }

    public static LinkedList<T> operator +(LinkedList<T> one, LinkedList<T> two)
    {
        if (one._head == null || two._head == null)
        {
            throw new NullReferenceException();
        }

        GenericNode<T> currentNode = one._head;

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
        GenericNode<T> currentNode = _head;

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

    public T[] ToArray()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        T[] elements = new T[_count];

        GenericNode<T> currentNode = _head;

        int i = 0;
        while (i < _count)
        {
            elements[i] = currentNode.Data;

            currentNode = currentNode.Next;
            i++;
        }
        return elements;
    }

    public bool RemoveAll(T element)
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

            T elem = Remove(index);

            index = IndexOf(element);
        }

        return true;
    }

    public bool RemoveValue(T element)
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

        T elem = Remove(index);

        return true;
    }


    public T RemoveLast()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        GenericNode<T> currentNode = _head;

        int i = 0;
        while (i < Count - 2)
        {
            currentNode = currentNode.Next;
            i++;
        }

        GenericNode<T> newLast = currentNode;
        Count -= 1;
        GenericNode<T> returnValue = newLast.Next;
        newLast.Next = null;

        return returnValue.Data;
    }

    public T RemoveFirst()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        GenericNode<T> firstNode = _head;
        _head = _head.Next;
        Count -= 1;
        return firstNode.Data;
    }

    public T Remove(int index)
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        GenericNode<T> currentNode = _head;
        GenericNode<T> previous = new();
        GenericNode<T> next = new();
        T returnElm = default(T);


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

    public int GetCountOf(T element)
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

       GenericNode<T>currentNode = _head;
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

        if (count == 0)
        {
            return -1;
        }
        else
        {
            return count;
        }

    }

    public int IndexOf(T element)
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

       GenericNode<T>currentNode = _head;
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

    public T GetLast()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

       GenericNode<T>currentNode = _head;
        int index = 0;

        while (index < Count - 1)
        {
            currentNode = currentNode.Next;
            index++;
        }
       GenericNode<T>last = currentNode;

        return last.Data;

    }

    public T GetFirst()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        return _head.Data;
    }

    //private bool ObjectIsEqual(T obj1, T obj2)
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

    public bool Contains(T element)
    {
        //REFRENCE HEAD OF LIST
       GenericNode<T>currentNode = _head;
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
       GenericNode<T>newHead = new();
        _head = newHead;
        Count = 0;
    }

    public void AddFirst(T element)
    {
        Insert(0, element);
    }

    public void Insert(int index, T element)
    {
        //SAFETY CHECKS
        if (index >= Count || index < 0)
        {
            throw new IndexOutOfRangeException($"Index is outside the bounds of the LinkedList. List is {Count} in size. index is currently {index}");
        }//end if 

        //REFRENCE HEAD OF LIST
       GenericNode<T>currentNode = _head;
        int currentIndex = 0;

       GenericNode<T>newNode = new(element);

        if (index == 0)
        {
           GenericNode<T>oldHead = _head;
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

           GenericNode<T>newNext = currentNode.Next;

            currentNode.Next = newNode;
            newNode.Next = newNext;

        }
    }

    public void Set(int index, T element)
    {
        //SAFETY CHECKS
        if (index >= Count || index < 0)
        {
            throw new IndexOutOfRangeException($"Index is outside the bounds of the LinkedList. List is {Count} in size. index is currently {index}");
        }//end if 

        //REFRENCE HEAD OF LIST
       GenericNode<T>currentNode = _head;
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

    public T Get(int index)
    {
        //SAFETY CHECKS
        if (index >= Count || index < 0)
        {
            throw new IndexOutOfRangeException($"Index is outside the bounds of the LinkedList. List is {Count} in size. index is currently {index}");
        }//end if 

        //REFRENCE HEAD OF LIST
       GenericNode<T>currentNode = _head;
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

    public void Add(T value)
    {
        //CREATE NEW NODE & FILL ITS DATA
       GenericNode<T>newNode = new GenericNode<T>(value);

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            //REFRENCE HEAD OF LIST
           GenericNode<T>currentNode = _head;

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

