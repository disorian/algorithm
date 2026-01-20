namespace Playground.Tests.Session2;

using Playground.Session2;
using Xunit;

public class HasCycleTests
{
    private readonly FastSlowPointers _solution;

    public HasCycleTests()
    {
        _solution = new FastSlowPointers();
    }

    [Fact]
    public void HasCycle_NullHead_ReturnsFalse()
    {
        // Arrange
        ListNode? head = null;

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasCycle_SingleNode_NoCycle_ReturnsFalse()
    {
        // Arrange
        var head = new ListNode(1);

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasCycle_TwoNodes_NoCycle_ReturnsFalse()
    {
        // Arrange
        var head = new ListNode(1)
        {
            Next = new ListNode(2)
        };

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasCycle_MultipleNodes_NoCycle_ReturnsFalse()
    {
        // Arrange
        var head = new ListNode(1)
        {
            Next = new ListNode(2)
            {
                Next = new ListNode(3)
                {
                    Next = new ListNode(4)
                }
            }
        };

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasCycle_SingleNodePointingToItself_ReturnsTrue()
    {
        // Arrange
        var head = new ListNode(1);
        head.Next = head; // Creates cycle

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasCycle_TwoNodesWithCycle_ReturnsTrue()
    {
        // Arrange
        var head = new ListNode(1);
        var second = new ListNode(2);
        head.Next = second;
        second.Next = head; // Creates cycle: 1 → 2 → 1

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasCycle_CycleAtEnd_ReturnsTrue()
    {
        // Arrange
        // List: 3 → 2 → 0 → -4
        //            ↑________↓
        var head = new ListNode(3);
        var second = new ListNode(2);
        var third = new ListNode(0);
        var fourth = new ListNode(-4);

        head.Next = second;
        second.Next = third;
        third.Next = fourth;
        fourth.Next = second; // Cycle back to position 1

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasCycle_CycleInMiddle_ReturnsTrue()
    {
        // Arrange
        // List: 1 → 2 → 3 → 4 → 5
        //            ↑_______↓
        var head = new ListNode(1);
        var second = new ListNode(2);
        var third = new ListNode(3);
        var fourth = new ListNode(4);
        var fifth = new ListNode(5);

        head.Next = second;
        second.Next = third;
        third.Next = fourth;
        fourth.Next = fifth;
        fifth.Next = third; // Cycle back to position 2

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasCycle_LongListWithCycleAtTail_ReturnsTrue()
    {
        // Arrange
        // List: 1 → 2 → 3 → 4 → 5 → 6 → 7 → 8
        //                        ↑__________↓
        var head = new ListNode(1);
        var current = head;
        ListNode? cycleStart = null;

        // Create nodes 2-8
        for (int i = 2; i <= 8; i++)
        {
            current.Next = new ListNode(i);
            current = current.Next;

            if (i == 5)
            {
                cycleStart = current; // Mark node 5 as cycle start
            }
        }

        // Create cycle: last node points back to node 5
        current.Next = cycleStart;

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasCycle_LongListNoCycle_ReturnsFalse()
    {
        // Arrange
        var head = new ListNode(1);
        var current = head;

        // Create a long list of 100 nodes with no cycle
        for (int i = 2; i <= 100; i++)
        {
            current.Next = new ListNode(i);
            current = current.Next;
        }

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasCycle_CycleToHead_ReturnsTrue()
    {
        // Arrange
        // List: 1 → 2 → 3 → 4
        //       ↑__________↓
        var head = new ListNode(1);
        var second = new ListNode(2);
        var third = new ListNode(3);
        var fourth = new ListNode(4);

        head.Next = second;
        second.Next = third;
        third.Next = fourth;
        fourth.Next = head; // Cycle back to head

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasCycle_DuplicateValues_NoCycle_ReturnsFalse()
    {
        // Arrange
        // List with duplicate values but no cycle: 1 → 2 → 2 → 3 → 1
        var head = new ListNode(1)
        {
            Next = new ListNode(2)
            {
                Next = new ListNode(2)
                {
                    Next = new ListNode(3)
                    {
                        Next = new ListNode(1)
                    }
                }
            }
        };

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasCycle_DuplicateValues_WithCycle_ReturnsTrue()
    {
        // Arrange
        // List with duplicate values and cycle: 1 → 2 → 2 → 3
        //                                       ↑__________↓
        var head = new ListNode(1);
        var second = new ListNode(2);
        var third = new ListNode(2);
        var fourth = new ListNode(3);

        head.Next = second;
        second.Next = third;
        third.Next = fourth;
        fourth.Next = head; // Cycle

        // Act
        var result = _solution.HasCycle(head);

        // Assert
        Assert.True(result);
    }
}
