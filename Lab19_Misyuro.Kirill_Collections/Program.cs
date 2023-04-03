// See https://aka.ms/new-console-template for more information

using System.Collections;

Console.WriteLine("Hello, World!");

var test = new StackCollection<int>();
test.Push(1);
test.Push(2);
test.Push(3);
test.Push(4);
test.Push(5);
test.Pop();

foreach (var t in test)
{
    Console.WriteLine(t);
}
Console.WriteLine($"Peek: {test.Peek()}");


interface IStackCollection<T> : IEnumerable
{
    public void Push(T element);
    public T Pop();
    public T Peek();
}

class StackCollection<T> : IStackCollection<T> where T : struct
{
    private T[] _arr = new T[1];
    private int _pointer = 0;

    public IEnumerator GetEnumerator()
    {
        for (int i= _arr.Length-1; i >=0; i--)
        {
            yield return _arr[i];
        }
    }

    public void Push(T element)
    {
        if (_pointer > _arr.Length-1)
        {
            Array.Resize(ref _arr, _arr.Length + 1);
        }

        _arr[_pointer] = element;
        _pointer++;
    }

    public T Pop()
    {
        var x = _arr[^1];
        Array.Resize(ref _arr, _arr.Length - 1);
        _pointer--;
        return x;
    }
    

    public T Peek()
    {
        return _arr[^1];
    }
}