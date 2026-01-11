namespace Playground.Tests.Basics;

using Playground.Basics;

public class StackTests
{
    #region Constructor Tests

    [Fact]
    public void Constructor_DefaultCapacity_CreatesEmptyStack()
    {
        // Arrange & Act
        var stack = new Stack<int>();

        // Assert
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void Constructor_CustomCapacity_CreatesEmptyStack()
    {
        // Arrange & Act
        var stack = new Stack<int>(5);

        // Assert
        Assert.True(stack.IsEmpty());
    }

    #endregion

    #region Push Tests

    [Fact]
    public void Push_SingleItem_AddsItemToStack()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act
        stack.Push(42);

        // Assert
        Assert.False(stack.IsEmpty());
        Assert.Equal(42, stack.pick());
    }

    [Fact]
    public void Push_MultipleItems_AddsItemsInOrder()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Assert
        Assert.Equal(3, stack.pick());
    }

    [Fact]
    public void Push_ExceedsInitialCapacity_AutomaticallyResizes()
    {
        // Arrange
        var stack = new Stack<int>(2);

        // Act - Push more items than initial capacity
        stack.Push(1);
        stack.Push(2);
        stack.Push(3); // Should trigger resize
        stack.Push(4);

        // Assert
        Assert.Equal(4, stack.pick());
        Assert.Equal(4, stack.Pop());
        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
    }

    [Fact]
    public void Push_StringType_WorksWithGenericType()
    {
        // Arrange
        var stack = new Stack<string>();

        // Act
        stack.Push("first");
        stack.Push("second");

        // Assert
        Assert.Equal("second", stack.pick());
    }

    #endregion

    #region Pop Tests

    [Fact]
    public void Pop_SingleItem_ReturnsItemAndRemovesFromStack()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(42);

        // Act
        var result = stack.Pop();

        // Assert
        Assert.Equal(42, result);
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void Pop_MultipleItems_ReturnsItemsInLifoOrder()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act & Assert
        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void Pop_EmptyStack_ThrowsInvalidOperationException()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => stack.Pop());
        Assert.Equal("Stack is empty", exception.Message);
    }

    [Fact]
    public void Pop_AfterPushAndPop_MaintainsCorrectState()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);

        // Act
        stack.Pop();
        stack.Push(3);

        // Assert
        Assert.Equal(3, stack.pick());
        Assert.False(stack.IsEmpty());
    }

    #endregion

    #region Pick Tests

    [Fact]
    public void Pick_WithItems_ReturnsTopItemWithoutRemoving()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(42);

        // Act
        var result = stack.pick();

        // Assert
        Assert.Equal(42, result);
        Assert.False(stack.IsEmpty());
        Assert.Equal(42, stack.pick()); // Should still return same item
    }

    [Fact]
    public void Pick_MultipleItems_ReturnsTopMostItem()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act
        var result = stack.pick();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Pick_EmptyStack_ThrowsInvalidOperationException()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => stack.pick());
        Assert.Equal("Stack is empty", exception.Message);
    }

    [Fact]
    public void Pick_CalledMultipleTimes_ReturnsSameValue()
    {
        // Arrange
        var stack = new Stack<string>();
        stack.Push("test");

        // Act & Assert
        Assert.Equal("test", stack.pick());
        Assert.Equal("test", stack.pick());
        Assert.Equal("test", stack.pick());
    }

    #endregion

    #region IsEmpty Tests

    [Fact]
    public void IsEmpty_NewStack_ReturnsTrue()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act & Assert
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void IsEmpty_AfterPush_ReturnsFalse()
    {
        // Arrange
        var stack = new Stack<int>();

        // Act
        stack.Push(1);

        // Assert
        Assert.False(stack.IsEmpty());
    }

    [Fact]
    public void IsEmpty_AfterPushAndPop_ReturnsTrue()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(1);

        // Act
        stack.Pop();

        // Assert
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void IsEmpty_AfterMultiplePushAndPopToEmpty_ReturnsTrue()
    {
        // Arrange
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act
        stack.Pop();
        stack.Pop();
        stack.Pop();

        // Assert
        Assert.True(stack.IsEmpty());
    }

    #endregion

    #region Integration Tests

    [Fact]
    public void Stack_ComplexScenario_WorksCorrectly()
    {
        // Arrange
        var stack = new Stack<int>(2);

        // Act & Assert - Complex sequence of operations
        stack.Push(1);
        stack.Push(2);
        Assert.Equal(2, stack.pick());

        stack.Push(3); // Triggers resize
        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());

        stack.Push(4);
        stack.Push(5);
        Assert.False(stack.IsEmpty());

        Assert.Equal(5, stack.pick());
        Assert.Equal(5, stack.Pop());
        Assert.Equal(4, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void Stack_WithCustomClass_WorksCorrectly()
    {
        // Arrange
        var stack = new Stack<TestClass>();
        var item1 = new TestClass { Id = 1, Name = "First" };
        var item2 = new TestClass { Id = 2, Name = "Second" };

        // Act
        stack.Push(item1);
        stack.Push(item2);

        // Assert
        var peeked = stack.pick();
        Assert.Equal(2, peeked.Id);
        Assert.Equal("Second", peeked.Name);

        var popped = stack.Pop();
        Assert.Equal(2, popped.Id);
        Assert.Same(item2, popped);
    }

    [Fact]
    public void Stack_LargeNumberOfItems_HandlesResizingCorrectly()
    {
        // Arrange
        var stack = new Stack<int>(5);
        const int itemCount = 100;

        // Act
        for (int i = 1; i <= itemCount; i++)
        {
            stack.Push(i);
        }

        // Assert
        Assert.False(stack.IsEmpty());
        Assert.Equal(itemCount, stack.pick());

        // Pop all items and verify order
        for (int i = itemCount; i >= 1; i--)
        {
            Assert.Equal(i, stack.Pop());
        }

        Assert.True(stack.IsEmpty());
    }

    #endregion

    #region Helper Classes

    private class TestClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    #endregion
}
