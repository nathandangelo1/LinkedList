class Node
{
    private object _data = null;
    private Node _next = null;


    public object Data
    {
        get { return _data; }
        set { _data = value; }
    }//end property
    public Node Next
    {
        get { return _next; }
        set { _next = value; }
    }//end property

    public Node(object initialData)
    {
        _data = initialData;
    }//end constructor

    public Node()
    {
    }//end constructor


}//end class