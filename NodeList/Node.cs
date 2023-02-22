class GenericNode<T>
{
    // FIELDS
    private T _data = default(T);
    private GenericNode<T> _next = null;
    public T Data
    {
        get { return _data; }
        set { _data = value; }
    }    
    public GenericNode<T> Next
    {
        get { return _next; }
        set { _next = value; }
    }
    public GenericNode()
    {
    }   
    public GenericNode(T initialData)
    {
    Data = initialData;
    }

}// End class Node