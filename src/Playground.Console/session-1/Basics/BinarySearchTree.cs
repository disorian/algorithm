
namespace Playground.Basics;

// Node class to represent each node in the BST
public class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

// Binary Search Tree class
public class BinarySearchTree
{
    public TreeNode Root { get; private set; }

    public BinarySearchTree()
    {
        Root = null;
    }

    // Insert a value into the BST
    public void Insert(int value)
    {
        Root = InsertRecursive(Root, value);
    }

    private TreeNode InsertRecursive(TreeNode node, int value)
    {
        // Base case: if node is null, create new node
        if (node == null)
        {
            return new TreeNode(value);
        }

        // Recursive case: traverse left or right
        if (value < node.Value)
        {
            node.Left = InsertRecursive(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = InsertRecursive(node.Right, value);
        }
        // If value equals node.Value, we don't insert duplicates

        return node;
    }

    // Search for a value in the BST
    public bool Search(int value)
    {
        return SearchRecursive(Root, value);
    }

    private bool SearchRecursive(TreeNode node, int value)
    {
        // Base case: node is null, value not found
        if (node == null)
        {
            return false;
        }

        // Value found
        if (value == node.Value)
        {
            return true;
        }

        // Search left or right subtree
        if (value < node.Value)
        {
            return SearchRecursive(node.Left, value);
        }
        else
        {
            return SearchRecursive(node.Right, value);
        }
    }

    // Delete a value from the BST
    public void Delete(int value)
    {
        Root = DeleteRecursive(Root, value);
    }

    private TreeNode DeleteRecursive(TreeNode node, int value)
    {
        // Base case: node is null
        if (node == null)
        {
            return null;
        }

        // Find the node to delete
        if (value < node.Value)
        {
            node.Left = DeleteRecursive(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = DeleteRecursive(node.Right, value);
        }
        else
        {
            // Node found! Handle three cases:

            // Case 1: Node has no children (leaf node)
            if (node.Left == null && node.Right == null)
            {
                return null;
            }

            // Case 2: Node has one child
            if (node.Left == null)
            {
                return node.Right;
            }
            if (node.Right == null)
            {
                return node.Left;
            }

            // Case 3: Node has two children
            // Find the minimum value in the right subtree (in-order successor)
            int minValue = FindMin(node.Right);
            node.Value = minValue;
            // Delete the in-order successor
            node.Right = DeleteRecursive(node.Right, minValue);
        }

        return node;
    }

    // Find minimum value in a subtree
    private int FindMin(TreeNode node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node.Value;
    }

    // Find maximum value in a subtree
    public int FindMax()
    {
        if (Root == null)
        {
            throw new InvalidOperationException("Tree is empty");
        }

        TreeNode current = Root;
        while (current.Right != null)
        {
            current = current.Right;
        }
        return current.Value;
    }

    // Get the height of the tree
    public int Height()
    {
        return HeightRecursive(Root);
    }

    private int HeightRecursive(TreeNode node)
    {
        if (node == null)
        {
            return -1; // Height of empty tree is -1
        }

        int leftHeight = HeightRecursive(node.Left);
        int rightHeight = HeightRecursive(node.Right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    // Count total nodes in the tree
    public int Count()
    {
        return CountRecursive(Root);
    }

    private int CountRecursive(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        return 1 + CountRecursive(node.Left) + CountRecursive(node.Right);
    }

    // In-order traversal (Left, Root, Right) - produces sorted order
    public List<int> InOrderTraversal()
    {
        List<int> result = new List<int>();
        InOrderRecursive(Root, result);
        return result;
    }

    private void InOrderRecursive(TreeNode node, List<int> result)
    {
        if (node != null)
        {
            InOrderRecursive(node.Left, result);
            result.Add(node.Value);
            InOrderRecursive(node.Right, result);
        }
    }

    // Pre-order traversal (Root, Left, Right)
    public List<int> PreOrderTraversal()
    {
        List<int> result = new List<int>();
        PreOrderRecursive(Root, result);
        return result;
    }

    private void PreOrderRecursive(TreeNode node, List<int> result)
    {
        if (node != null)
        {
            result.Add(node.Value);
            PreOrderRecursive(node.Left, result);
            PreOrderRecursive(node.Right, result);
        }
    }

    // Post-order traversal (Left, Right, Root)
    public List<int> PostOrderTraversal()
    {
        List<int> result = new List<int>();
        PostOrderRecursive(Root, result);
        return result;
    }

    private void PostOrderRecursive(TreeNode node, List<int> result)
    {
        if (node != null)
        {
            PostOrderRecursive(node.Left, result);
            PostOrderRecursive(node.Right, result);
            result.Add(node.Value);
        }
    }

    // Level-order traversal (breadth-first)
    public List<int> LevelOrderTraversal()
    {
        List<int> result = new List<int>();
        if (Root == null)
        {
            return result;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            result.Add(current.Value);

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }
            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }

        return result;
    }

    // Check if tree is empty
    public bool IsEmpty()
    {
        return Root == null;
    }

    // Clear the tree
    public void Clear()
    {
        Root = null;
    }

    // Print tree structure (simple visualization)
    public void PrintTree()
    {
        PrintTreeRecursive(Root, "", true);
    }

    private void PrintTreeRecursive(TreeNode node, string indent, bool isRight)
    {
        if (node != null)
        {
            Console.WriteLine(indent + (isRight ? "└── " : "├── ") + node.Value);
            PrintTreeRecursive(node.Right, indent + (isRight ? "    " : "│   "), true);
            PrintTreeRecursive(node.Left, indent + (isRight ? "    " : "│   "), false);
        }
    }
}

// Example usage program
class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();

        Console.WriteLine("=== Binary Search Tree Demo ===\n");

        // Insert values
        Console.WriteLine("Inserting: 50, 30, 70, 20, 40, 60, 80, 10, 25, 35, 65");
        int[] values = { 50, 30, 70, 20, 40, 60, 80, 10, 25, 35, 65 };
        foreach (int value in values)
        {
            bst.Insert(value);
        }

        // Print tree structure
        Console.WriteLine("\nTree Structure:");
        bst.PrintTree();

        // Search operations
        Console.WriteLine("\n--- Search Operations ---");
        Console.WriteLine($"Search 40: {bst.Search(40)}");
        Console.WriteLine($"Search 100: {bst.Search(100)}");

        // Traversals
        Console.WriteLine("\n--- Traversals ---");
        Console.WriteLine($"In-Order (sorted): {string.Join(", ", bst.InOrderTraversal())}");
        Console.WriteLine($"Pre-Order: {string.Join(", ", bst.PreOrderTraversal())}");
        Console.WriteLine($"Post-Order: {string.Join(", ", bst.PostOrderTraversal())}");
        Console.WriteLine($"Level-Order: {string.Join(", ", bst.LevelOrderTraversal())}");

        // Tree properties
        Console.WriteLine("\n--- Tree Properties ---");
        Console.WriteLine($"Total Nodes: {bst.Count()}");
        Console.WriteLine($"Height: {bst.Height()}");
        Console.WriteLine($"Maximum Value: {bst.FindMax()}");

        // Delete operations
        Console.WriteLine("\n--- Delete Operations ---");
        Console.WriteLine("Deleting 20 (node with two children)");
        bst.Delete(20);
        Console.WriteLine($"In-Order after deletion: {string.Join(", ", bst.InOrderTraversal())}");

        Console.WriteLine("\nDeleting 30 (node with two children)");
        bst.Delete(30);
        Console.WriteLine($"In-Order after deletion: {string.Join(", ", bst.InOrderTraversal())}");

        Console.WriteLine("\nTree Structure after deletions:");
        bst.PrintTree();

        Console.WriteLine("\n=== Demo Complete ===");
    }
}