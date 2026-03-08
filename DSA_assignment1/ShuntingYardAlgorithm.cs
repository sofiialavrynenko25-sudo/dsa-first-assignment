namespace DSA_assignment1;

public class ShuntingYardAlgorithm
{
    private string _infix;
    private string _buffer; //additional space till the number is formed
    private QueueClass _numbersQueue;
    private StackClass _operatorsStack;
    private string[] _operators = { "+", "-", "*", "/", "(", ")" };
    
    public ShuntingYardAlgorithm(string infix)
    {
        _infix = infix.Trim();
        _buffer = "";
        _numbersQueue = new QueueClass(); //will be the output too
        _operatorsStack = new StackClass();
    }

    public static int OperatorPriority(string element)
    {
        if (element == "*" || element == "/")
            return 1;
        
        if (element == "+" || element == "-")
            return 2;
        
        return 0;
    }
    
    public QueueClass RunAndPrintPostfix()
    {
        _infix += "."; //adding random char so it counts the last number too
        foreach (var ch in _infix)
        {
            if (char.IsDigit(ch))
            {
                _buffer += ch;
            }
            
            else
            {
                if (!string.IsNullOrEmpty(_buffer))
                {
                    _numbersQueue.EnqueueMethod(_buffer);
                    _buffer = "";
                }
                
                if (ch == ' ')
                {
                    continue;
                }
                
                if (_operators.Contains(ch.ToString()))
                {
                    var token = ch.ToString();
                    var priority = OperatorPriority(token);
                    
                    if (token == ")")
                    {
                        while (_operatorsStack.Length() > 0 && _operatorsStack.PeekMethod() != "(")
                        {
                            var temp = _operatorsStack.PopMethod();
                            _numbersQueue.EnqueueMethod(temp);
                        }
                        _operatorsStack.PopMethod();
                    }
                    
                    else
                    {
                        while (_operatorsStack.Length() > 0)
                        {
                            var top = _operatorsStack.PeekMethod();

                            if (top == "(")
                                break;
                            
                            var topPrior = OperatorPriority(top);

                            if (topPrior <= priority)
                            {
                                var temp = _operatorsStack.PopMethod();
                                _numbersQueue.EnqueueMethod(temp);
                            }
                            else
                            {
                                break;
                            }
                        }
                        _operatorsStack.PushMethod(token);
                    }
                }
            }
        }
        
        while (_operatorsStack.Length() > 0)
        {
            var element = _operatorsStack.PopMethod();
            _numbersQueue.EnqueueMethod(element);
        }

        Console.WriteLine("Postfix: ");
        _numbersQueue.Print();

        return _numbersQueue;
    }

    public void CalculatePostfix(QueueClass postfix)
    {
        var res = new StackClass();

        var count = postfix.Length();

        for (var i = 0; i < count; i++)
        {
            var token = postfix.DequeueMethod();
            
            if (int.TryParse(token, out _))
            {
                res.PushMethod(token);
            }

            else if (_operators.Contains(token))
            {
                var firstNum = int.Parse(res.PopMethod());
                var secondNum = int.Parse(res.PopMethod());
                var thirdNum = 0;

                if (token == "+")
                    thirdNum = firstNum + secondNum;
                
                else if (token == "-")
                    thirdNum = secondNum - firstNum;
                
                else if (token == "*")
                    thirdNum = firstNum * secondNum;
                
                else if (token == "/")
                    thirdNum = secondNum / firstNum;
                
                res.PushMethod(thirdNum.ToString());
            }
        }
        
        Console.WriteLine("Result: ");
        Console.WriteLine(res.PopMethod());
    }
}