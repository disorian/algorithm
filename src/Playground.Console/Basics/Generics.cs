namespace Playground.Basics;

public class GenericLibrary
{
    public static T FindMax<T>(T[] array) where T : IComparable<T>
    {
        if (array.Length == 0)
            throw new ArgumentException("Array cannot be empty");

        T max = array[0];

        foreach (var item in array.Skip(1))
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }

        return max;
    }
}

public class Stack<T>(int capacity = 10)
{
    private T[] items = new T[capacity];
    private int top = -1;

    public void Push(T item)
    {
        if (top == items.Length - 1)
            Resize();
        items[++top] = item;
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty");
        return items[top--];
    }

    public T pick()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty");
        return items[top];
    }

    public bool IsEmpty() => top == -1;

    private void Resize() => Array.Resize(ref items, items.Length + capacity);
}

public class BinarySearchTree<T> where T : IComparable<T>
{
    private class Node(T value)
    {
        public T Value { get; set; } = value;
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }

    private Node? root;

    public void Insert(T value) =>
        root = InsertRecursively(root, value);

    private Node InsertRecursively(Node? node, T value)
    {
        if (node is null)
            return new Node(value);

        if (value.CompareTo(node.Value) < 0)
            node.Left = InsertRecursively(node.Left, value);
        else if (value.CompareTo(node.Value) > 0)
            node.Right = InsertRecursively(node.Right, value);

        return node;
    }
}

public class Generics
{
    public static void Run()
    {
        int[] numbers = [1, 2, 54, 8, 5, 65, 98, 45, 12, 78, 65, 98, 45, 12, 3, 56];
        Console.WriteLine($"Max is: {GenericLibrary.FindMax(numbers)}");
    }
}