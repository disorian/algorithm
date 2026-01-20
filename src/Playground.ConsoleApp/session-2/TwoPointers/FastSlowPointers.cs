namespace Playground.Session2;

public class FastSlowPointers
{
    // Floyd's Cycle Detection Algorithm
    // Time: O(n), Space: O(1)
    public bool HasCycle(ListNode? head)
    {
        var fast = head;
        var slow = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow?.Next;
            fast = fast?.Next?.Next;

            if (slow == fast) return true;
        }

        return false;
    }

    // Find cycle start
    public ListNode? DetectCycle(ListNode? head)
    {
        var fast = head;
        var slow = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow?.Next;
            fast = fast?.Next?.Next;

            if (slow == fast)
            {
                slow = head;
                while (slow != fast)
                {
                    slow = slow?.Next;
                    fast = fast?.Next;
                }
                return slow;
            }
        }

        return null;
    }

    public ListNode MiddleNode(ListNode head)
    {
        ListNode? slow = head, fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow?.Next;
            fast = fast?.Next?.Next;

        }

        return slow;
    }
}

//Definition for singly-linked list.
public class ListNode(int value)
{
    public int Value = value;
    public ListNode? Next = null;
}