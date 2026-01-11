namespace Playground.Basics;

public class DynamicArray<T>
{
    private int count = 0;
    private const int DefaultCapacity = 4;
    private T[] items = new T[DefaultCapacity];

    public int Count => count;
    public int Capacity => items.Length;

    public T this[int index]
    {
        get
        {
            CheckIndexValidity(index);

            return items[index];
        }
        set
        {
            CheckIndexValidity(index);
            items[index] = value;
        }
    }

    public void Add(T item)
    {
        ValidateAndResize();

        items[count++] = item;
    }

    public void Insert(int index, T value)
    {
        CheckIndexValidity(index);
        ValidateAndResize();

        // Shift elements to the right
        for (int i = count; i > index; i--)
        {
            items[i] = items[i - 1];
        }

        items[index] = value;
        count++;
    }

    public void RemoveAt(int index)
    {
        CheckIndexValidity(index);

        // Shift elements to the left
        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        items[--count] = default!;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(items[i], item))
                return i;
        }
        return -1;
    }

    public bool Contains(T item) => IndexOf(item) != -1;

    public void Clear()
    {
        Array.Clear(items, 0, count);
        count = 0;
    }

    private void Resize()
    {
        // Doubling capacity ensures amortised O(1) insertions.
        int newCapacity = items.Length * 2;
        T[] newArray = new T[newCapacity];
        Array.Copy(items, newArray, count);
        items = newArray;
    }

    private void ValidateAndResize()
    {
        if (count == items.Length)
            Resize();
    }

    private void CheckIndexValidity(int index)
    {
        if (index < 0 || index > count)
            throw new IndexOutOfRangeException();
    }
}