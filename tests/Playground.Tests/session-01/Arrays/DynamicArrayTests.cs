namespace Playground.Tests.Arrays;

using Playground.Basics;

public class DynamicArrayTests
{
    #region Constructor and Initialization Tests

    [Fact]
    public void Constructor_Default_CreatesEmptyArrayWithDefaultCapacity()
    {
        // Arrange & Act
        var array = new DynamicArray<int>();

        // Assert
        Assert.Equal(0, array.Count);
        Assert.Equal(4, array.Capacity);
    }

    #endregion

    #region Add Tests

    [Fact]
    public void Add_SingleItem_AddsItemToArray()
    {
        // Arrange
        var array = new DynamicArray<int>();

        // Act
        array.Add(42);

        // Assert
        Assert.Equal(1, array.Count);
        Assert.Equal(42, array[0]);
    }

    [Fact]
    public void Add_MultipleItems_AddsItemsInOrder()
    {
        // Arrange
        var array = new DynamicArray<int>();

        // Act
        array.Add(1);
        array.Add(2);
        array.Add(3);

        // Assert
        Assert.Equal(3, array.Count);
        Assert.Equal(1, array[0]);
        Assert.Equal(2, array[1]);
        Assert.Equal(3, array[2]);
    }

    [Fact]
    public void Add_ExceedsInitialCapacity_AutomaticallyResizes()
    {
        // Arrange
        var array = new DynamicArray<int>();
        Assert.Equal(4, array.Capacity);

        // Act - Add more items than initial capacity
        array.Add(1);
        array.Add(2);
        array.Add(3);
        array.Add(4);
        array.Add(5); // Should trigger resize to capacity 8

        // Assert
        Assert.Equal(5, array.Count);
        Assert.Equal(8, array.Capacity);
        Assert.Equal(5, array[4]);
    }

    [Fact]
    public void Add_StringType_WorksWithGenericType()
    {
        // Arrange
        var array = new DynamicArray<string>();

        // Act
        array.Add("first");
        array.Add("second");

        // Assert
        Assert.Equal(2, array.Count);
        Assert.Equal("first", array[0]);
        Assert.Equal("second", array[1]);
    }

    [Fact]
    public void Add_MultipleResizes_DoublesCapacityEachTime()
    {
        // Arrange
        var array = new DynamicArray<int>();

        // Act & Assert
        for (int i = 1; i <= 4; i++)
        {
            array.Add(i);
        }
        Assert.Equal(4, array.Capacity);

        array.Add(5); // Triggers resize to 8
        Assert.Equal(8, array.Capacity);

        for (int i = 6; i <= 8; i++)
        {
            array.Add(i);
        }
        Assert.Equal(8, array.Capacity);

        array.Add(9); // Triggers resize to 16
        Assert.Equal(16, array.Capacity);
    }

    #endregion

    #region Insert Tests

    [Fact]
    public void Insert_AtBeginning_InsertsItemAtIndexZero()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);
        array.Add(3);

        // Act
        array.Insert(0, 99);

        // Assert
        Assert.Equal(4, array.Count);
        Assert.Equal(99, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
        Assert.Equal(3, array[3]);
    }

    [Fact]
    public void Insert_AtMiddle_InsertsItemAtSpecifiedIndex()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);
        array.Add(4);

        // Act
        array.Insert(2, 3);

        // Assert
        Assert.Equal(4, array.Count);
        Assert.Equal(1, array[0]);
        Assert.Equal(2, array[1]);
        Assert.Equal(3, array[2]);
        Assert.Equal(4, array[3]);
    }

    [Fact]
    public void Insert_AtEnd_InsertsItemAtLastIndex()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);

        // Act
        array.Insert(2, 3);

        // Assert
        Assert.Equal(3, array.Count);
        Assert.Equal(3, array[2]);
    }

    [Fact]
    public void Insert_ExceedsCapacity_AutomaticallyResizes()
    {
        // Arrange
        var array = new DynamicArray<int>();
        for (int i = 1; i <= 4; i++)
        {
            array.Add(i);
        }

        // Act
        array.Insert(2, 99); // Should trigger resize

        // Assert
        Assert.Equal(5, array.Count);
        Assert.Equal(8, array.Capacity);
        Assert.Equal(99, array[2]);
    }

    [Fact]
    public void Insert_InvalidIndex_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => array.Insert(-1, 99));
        Assert.Throws<IndexOutOfRangeException>(() => array.Insert(5, 99));
    }

    #endregion

    #region RemoveAt Tests

    [Fact]
    public void RemoveAt_FirstItem_RemovesAndShiftsRemaining()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);
        array.Add(3);

        // Act
        array.RemoveAt(0);

        // Assert
        Assert.Equal(2, array.Count);
        Assert.Equal(2, array[0]);
        Assert.Equal(3, array[1]);
    }

    [Fact]
    public void RemoveAt_MiddleItem_RemovesAndShiftsRemaining()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);
        array.Add(3);

        // Act
        array.RemoveAt(1);

        // Assert
        Assert.Equal(2, array.Count);
        Assert.Equal(1, array[0]);
        Assert.Equal(3, array[1]);
    }

    [Fact]
    public void RemoveAt_LastItem_RemovesItem()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);
        array.Add(3);

        // Act
        array.RemoveAt(2);

        // Assert
        Assert.Equal(2, array.Count);
        Assert.Equal(1, array[0]);
        Assert.Equal(2, array[1]);
    }

    [Fact]
    public void RemoveAt_InvalidIndex_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => array.RemoveAt(-1));
        Assert.Throws<IndexOutOfRangeException>(() => array.RemoveAt(5));
    }

    [Fact]
    public void RemoveAt_AllItems_ResultsInEmptyArray()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);

        // Act
        array.RemoveAt(0);
        array.RemoveAt(0);

        // Assert
        Assert.Equal(0, array.Count);
    }

    #endregion

    #region IndexOf Tests

    [Fact]
    public void IndexOf_ExistingItem_ReturnsCorrectIndex()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(10);
        array.Add(20);
        array.Add(30);

        // Act
        var index = array.IndexOf(20);

        // Assert
        Assert.Equal(1, index);
    }

    [Fact]
    public void IndexOf_FirstItem_ReturnsZero()
    {
        // Arrange
        var array = new DynamicArray<string>();
        array.Add("first");
        array.Add("second");

        // Act
        var index = array.IndexOf("first");

        // Assert
        Assert.Equal(0, index);
    }

    [Fact]
    public void IndexOf_LastItem_ReturnsLastIndex()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);
        array.Add(3);

        // Act
        var index = array.IndexOf(3);

        // Assert
        Assert.Equal(2, index);
    }

    [Fact]
    public void IndexOf_NonExistingItem_ReturnsMinusOne()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);

        // Act
        var index = array.IndexOf(99);

        // Assert
        Assert.Equal(-1, index);
    }

    [Fact]
    public void IndexOf_EmptyArray_ReturnsMinusOne()
    {
        // Arrange
        var array = new DynamicArray<int>();

        // Act
        var index = array.IndexOf(1);

        // Assert
        Assert.Equal(-1, index);
    }

    [Fact]
    public void IndexOf_DuplicateItems_ReturnsFirstOccurrence()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);
        array.Add(1);
        array.Add(3);

        // Act
        var index = array.IndexOf(1);

        // Assert
        Assert.Equal(0, index);
    }

    #endregion

    #region Contains Tests

    [Fact]
    public void Contains_ExistingItem_ReturnsTrue()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);
        array.Add(3);

        // Act
        var result = array.Contains(2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Contains_NonExistingItem_ReturnsFalse()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);

        // Act
        var result = array.Contains(99);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Contains_EmptyArray_ReturnsFalse()
    {
        // Arrange
        var array = new DynamicArray<int>();

        // Act
        var result = array.Contains(1);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Contains_NullInReferenceType_WorksCorrectly()
    {
        // Arrange
        var array = new DynamicArray<string?>();
        array.Add("test");
        array.Add(null);

        // Act & Assert
        Assert.True(array.Contains(null));
        Assert.True(array.Contains("test"));
    }

    #endregion

    #region Clear Tests

    [Fact]
    public void Clear_WithItems_RemovesAllItems()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);
        array.Add(3);

        // Act
        array.Clear();

        // Assert
        Assert.Equal(0, array.Count);
    }

    [Fact]
    public void Clear_EmptyArray_RemainsEmpty()
    {
        // Arrange
        var array = new DynamicArray<int>();

        // Act
        array.Clear();

        // Assert
        Assert.Equal(0, array.Count);
    }

    [Fact]
    public void Clear_DoesNotChangeCapacity()
    {
        // Arrange
        var array = new DynamicArray<int>();
        for (int i = 1; i <= 10; i++)
        {
            array.Add(i);
        }
        var capacityBeforeClear = array.Capacity;

        // Act
        array.Clear();

        // Assert
        Assert.Equal(0, array.Count);
        Assert.Equal(capacityBeforeClear, array.Capacity);
    }

    [Fact]
    public void Clear_ThenAdd_WorksCorrectly()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);

        // Act
        array.Clear();
        array.Add(99);

        // Assert
        Assert.Equal(1, array.Count);
        Assert.Equal(99, array[0]);
    }

    #endregion

    #region Indexer Tests

    [Fact]
    public void Indexer_Get_ReturnsCorrectValue()
    {
        // Arrange
        var array = new DynamicArray<string>();
        array.Add("first");
        array.Add("second");
        array.Add("third");

        // Act & Assert
        Assert.Equal("first", array[0]);
        Assert.Equal("second", array[1]);
        Assert.Equal("third", array[2]);
    }

    [Fact]
    public void Indexer_Set_UpdatesValue()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);
        array.Add(2);
        array.Add(3);

        // Act
        array[1] = 99;

        // Assert
        Assert.Equal(99, array[1]);
        Assert.Equal(1, array[0]);
        Assert.Equal(3, array[2]);
    }

    [Fact]
    public void Indexer_GetInvalidIndex_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => array[-1]);
        Assert.Throws<IndexOutOfRangeException>(() => array[5]);
    }

    [Fact]
    public void Indexer_SetInvalidIndex_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        var array = new DynamicArray<int>();
        array.Add(1);

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => array[-1] = 99);
        Assert.Throws<IndexOutOfRangeException>(() => array[5] = 99);
    }

    #endregion

    #region Integration Tests

    [Fact]
    public void DynamicArray_ComplexScenario_WorksCorrectly()
    {
        // Arrange
        var array = new DynamicArray<int>();

        // Act & Assert - Complex sequence of operations
        array.Add(1);
        array.Add(2);
        array.Add(3);
        Assert.Equal(3, array.Count);

        array.Insert(1, 99);
        Assert.Equal(99, array[1]);
        Assert.Equal(2, array[2]);

        array.RemoveAt(0);
        Assert.Equal(99, array[0]);

        array[1] = 100;
        Assert.Equal(100, array[1]);

        Assert.True(array.Contains(99));
        Assert.False(array.Contains(1));
        Assert.Equal(1, array.IndexOf(100));

        array.Clear();
        Assert.Equal(0, array.Count);
    }

    [Fact]
    public void DynamicArray_WithCustomClass_WorksCorrectly()
    {
        // Arrange
        var array = new DynamicArray<TestClass>();
        var item1 = new TestClass { Id = 1, Name = "First" };
        var item2 = new TestClass { Id = 2, Name = "Second" };
        var item3 = new TestClass { Id = 3, Name = "Third" };

        // Act
        array.Add(item1);
        array.Add(item2);
        array.Add(item3);

        // Assert
        Assert.Equal(3, array.Count);
        Assert.Same(item2, array[1]);
        Assert.True(array.Contains(item2));
        Assert.Equal(1, array.IndexOf(item2));

        array.RemoveAt(1);
        Assert.Equal(2, array.Count);
        Assert.False(array.Contains(item2));
    }

    [Fact]
    public void DynamicArray_LargeNumberOfItems_HandlesResizingCorrectly()
    {
        // Arrange
        var array = new DynamicArray<int>();
        const int itemCount = 1000;

        // Act
        for (int i = 1; i <= itemCount; i++)
        {
            array.Add(i);
        }

        // Assert
        Assert.Equal(itemCount, array.Count);
        Assert.Equal(1, array[0]);
        Assert.Equal(500, array[499]);
        Assert.Equal(itemCount, array[itemCount - 1]);

        // Verify all items
        for (int i = 1; i <= itemCount; i++)
        {
            Assert.Equal(i, array[i - 1]);
        }
    }

    [Fact]
    public void DynamicArray_AlternatingAddAndRemove_MaintainsCorrectState()
    {
        // Arrange
        var array = new DynamicArray<int>();

        // Act & Assert
        array.Add(1);
        array.Add(2);
        Assert.Equal(2, array.Count);

        array.RemoveAt(0);
        Assert.Equal(1, array.Count);
        Assert.Equal(2, array[0]);

        array.Add(3);
        array.Add(4);
        Assert.Equal(3, array.Count);

        array.RemoveAt(1);
        Assert.Equal(2, array.Count);
        Assert.Equal(2, array[0]);
        Assert.Equal(4, array[1]);
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
