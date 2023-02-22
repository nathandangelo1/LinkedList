using System;

class GenericNode<T>
{
    private <T> _data = null;
    private GenericNode _next = null;


    public string ToString()
    {
        return _data.ToString();
    }
    public object Data
    {
        get { return _data; }
        set { _data = value; }
    }//end property
    public GenericNode Next
    {
        get { return _next; }
        set { _next = value; }
    }//end property

    public GenericNode<T>(<T> initialData)
    {
        _data = initialData;
    }//end constructor

    public GenericNode()
    {
    }//end constructor

}
