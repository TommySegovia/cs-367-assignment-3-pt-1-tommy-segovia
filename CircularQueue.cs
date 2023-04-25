namespace CircularQueue.Lib;

public class CircularQueue<T> : ICircularQueue<T>
{
    private T[] _queue;

    int _count;
    int _front;
    int _rear;

    public CircularQueue(int size)
    {
        _queue = new T[size];
        _count = 0;
        _front = 0;
        _rear = -1;
    }
    public bool IsEmpty => _count == 0;

    public int Count => _count;

    public T Back()
    {

        return (_queue[_rear]);
    }

    public T Dequeue()
    {
        if (IsEmpty) throw new Exception();
        var dequeuedItem = _queue[_front];
        _front = (_front + 1) % _queue.Length;
        _count--;
        return dequeuedItem;
        
    }

    public void Enqueue(T item)
    {
        
        if (_count == _queue.Length - 1) throw new Exception();
        _rear = (_rear + 1) % _queue.Length;
        _queue[_rear] = item;
        _count++;
        
    }

    public T Front()
    {        
        return (_queue[_front]);
    }

    public void Resize(int newSize)
    {
        T[] newQueue = new T[newSize];

        if (newSize < Count)
        {
            for (int i = 0; i < newQueue.Count(); i++)
            {
                newQueue[i] = _queue[i];
            }
            _queue = newQueue;
            _count -= Count - newSize;
            _rear = _count;
        }
        else
        {
            _queue.CopyTo(newQueue, 0);
            _queue = newQueue;
            _count += Count - newSize;
            _rear = _count;
        }
        
    }
}