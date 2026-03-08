namespace DSA_assignment1;

public class StackClass
{
    private int _point;
    private const int _standartCapacity = 15;
    private string[] _buffer = new string[_standartCapacity];

    public void PushMethod(string infix_element)
    {
        if (_point >= _buffer.Length)
        {
            Resize(); //double the size if needed
        }
        
        _buffer[_point] = infix_element;
        
        _point++; //points to the next element after adding
    }

    public string PopMethod()
    {
        if (_point <= 0)
        {
            throw new Exception("Stack's empty, nothing to remove.");
        }
        
        _point--;
        
        var element = _buffer[_point];

        _buffer[_point] = null;

        return element;
    }

    public string PeekMethod()
    {
        if (_point <= 0)
        {
            throw new Exception("Stack's empty, nothing to see.");
        }

        var element = _buffer[_point - 1];
        
        return element;
    }

    public void Resize()
    {
        string[] newBuffer = new string[_buffer.Length * 2];
        
        Array.Copy(_buffer, newBuffer, _buffer.Length);

        _buffer = newBuffer;
    }

    public int Length()
    {
        return _point;
    }
    
    public void Print()
    {
        foreach (var a in _buffer)
            Console.WriteLine(a);
    }
}