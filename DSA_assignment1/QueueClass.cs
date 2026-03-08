namespace DSA_assignment1;

public class QueueClass
{
    private int _start;
    private int _end;
    private int _length; //since the end might not be the actual length
    private const int _standartCapacity = 15;
    private string[] _buffer = new string[_standartCapacity];

    public void EnqueueMethod(string infix_element)
    {
        if (_length == _buffer.Length)
        {
            Resize();
        }

        _buffer[_end] = infix_element;
        
        _end = (_end + 1) % _buffer.Length;

        _length++;
    }

    public string DequeueMethod()
    {
        if (_length == 0)
        {
            throw new Exception("Queue's empty, nothing to remove.");
        }

        var element = _buffer[_start];
        
        _buffer[_start] = null;
        
        _start = (_start + 1) % _buffer.Length;

        _length--;

        return element;
    }

    public string PeekMethod()
    {
        if (_length == 0)
        {
            throw new Exception("Queue's empty, nothing to see.");
        }
        
        var element = _buffer[_start];

        return element;
    }

    public void Resize()
    {
        string[] newBuffer = new string[_buffer.Length * 2];

        for (var i = 0; i < _length; i++)
        {
            newBuffer[i] = _buffer[(_start + i) % _buffer.Length];
        }

        _buffer = newBuffer;

        _start = 0;

        _end = _length;
    }

    public int Length()
    {
        return _length;
    }
    
    public void Print()
        {
            foreach (var a in _buffer)
                Console.Write(a + " ");
        }
}