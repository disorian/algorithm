namespace Playground.Basics;

public class ThreadSafeQueue<T>
{
    private readonly Queue<T> _queue = new();
    private readonly Lock _lock = new();

    public void Enqueue(T item)
    {
        lock (_lock)
        {
            _queue.Enqueue(item);
        }
    }

    public bool TryDequeue(out T item)
    {
        lock (_lock)
        {
            if (_queue.Count > 0)
            {
                item = _queue.Dequeue();
                return true;
            }
            item = default;
            return false;
        }
    }
}