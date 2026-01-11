namespace Playground.Tests.Basics;

using Playground.Basics;

public class ThreadSafeQueueTests
{
    #region Enqueue Tests

    [Fact]
    public void Enqueue_SingleItem_AddsItemToQueue()
    {
        // Arrange
        var queue = new ThreadSafeQueue<int>();

        // Act
        queue.Enqueue(42);

        // Assert
        Assert.True(queue.TryDequeue(out var result));
        Assert.Equal(42, result);
    }

    [Fact]
    public void Enqueue_MultipleItems_AddsItemsInFifoOrder()
    {
        // Arrange
        var queue = new ThreadSafeQueue<int>();

        // Act
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        // Assert
        Assert.True(queue.TryDequeue(out var first));
        Assert.Equal(1, first);
        Assert.True(queue.TryDequeue(out var second));
        Assert.Equal(2, second);
        Assert.True(queue.TryDequeue(out var third));
        Assert.Equal(3, third);
    }

    [Fact]
    public void Enqueue_StringType_WorksWithGenericType()
    {
        // Arrange
        var queue = new ThreadSafeQueue<string>();

        // Act
        queue.Enqueue("first");
        queue.Enqueue("second");

        // Assert
        Assert.True(queue.TryDequeue(out var result));
        Assert.Equal("first", result);
    }

    [Fact]
    public void Enqueue_NullValue_AllowsNullForReferenceTypes()
    {
        // Arrange
        var queue = new ThreadSafeQueue<string?>();

        // Act
        queue.Enqueue(null);

        // Assert
        Assert.True(queue.TryDequeue(out var result));
        Assert.Null(result);
    }

    #endregion

    #region TryDequeue Tests

    [Fact]
    public void TryDequeue_EmptyQueue_ReturnsFalseAndDefaultValue()
    {
        // Arrange
        var queue = new ThreadSafeQueue<int>();

        // Act
        var result = queue.TryDequeue(out var item);

        // Assert
        Assert.False(result);
        Assert.Equal(default, item);
    }

    [Fact]
    public void TryDequeue_SingleItem_ReturnsItemAndRemovesFromQueue()
    {
        // Arrange
        var queue = new ThreadSafeQueue<int>();
        queue.Enqueue(42);

        // Act
        var success = queue.TryDequeue(out var item);

        // Assert
        Assert.True(success);
        Assert.Equal(42, item);
        Assert.False(queue.TryDequeue(out _)); // Queue should now be empty
    }

    [Fact]
    public void TryDequeue_MultipleItems_ReturnsItemsInFifoOrder()
    {
        // Arrange
        var queue = new ThreadSafeQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        // Act & Assert
        Assert.True(queue.TryDequeue(out var first));
        Assert.Equal(1, first);
        Assert.True(queue.TryDequeue(out var second));
        Assert.Equal(2, second);
        Assert.True(queue.TryDequeue(out var third));
        Assert.Equal(3, third);
        Assert.False(queue.TryDequeue(out _)); // Queue should now be empty
    }

    [Fact]
    public void TryDequeue_AfterEnqueueAndDequeue_MaintainsCorrectState()
    {
        // Arrange
        var queue = new ThreadSafeQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);

        // Act
        queue.TryDequeue(out _);
        queue.Enqueue(3);

        // Assert
        Assert.True(queue.TryDequeue(out var result));
        Assert.Equal(2, result);
    }

    #endregion

    #region Thread Safety Tests

    [Fact]
    public async Task Enqueue_ConcurrentEnqueues_AllItemsAreAdded()
    {
        // Arrange
        var queue = new ThreadSafeQueue<int>();
        const int threadCount = 10;
        const int itemsPerThread = 100;
        var tasks = new Task[threadCount];

        // Act - Multiple threads enqueuing concurrently
        for (int i = 0; i < threadCount; i++)
        {
            int threadId = i;
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < itemsPerThread; j++)
                {
                    queue.Enqueue(threadId * itemsPerThread + j);
                }
            });
        }

        await Task.WhenAll(tasks);

        // Assert - All items should be in the queue
        var items = new List<int>();
        while (queue.TryDequeue(out var item))
        {
            items.Add(item);
        }

        Assert.Equal(threadCount * itemsPerThread, items.Count);
        Assert.Equal(threadCount * itemsPerThread, items.Distinct().Count()); // All items should be unique
    }

    [Fact]
    public async Task TryDequeue_ConcurrentDequeues_NoItemsAreLost()
    {
        // Arrange
        var queue = new ThreadSafeQueue<int>();
        const int itemCount = 1000;

        // Pre-populate queue
        for (int i = 0; i < itemCount; i++)
        {
            queue.Enqueue(i);
        }

        var dequeuedItems = new System.Collections.Concurrent.ConcurrentBag<int>();
        const int threadCount = 10;
        var tasks = new Task[threadCount];

        // Act - Multiple threads dequeuing concurrently
        for (int i = 0; i < threadCount; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                while (queue.TryDequeue(out var item))
                {
                    dequeuedItems.Add(item);
                }
            });
        }

        await Task.WhenAll(tasks);

        // Assert - All items should be dequeued exactly once
        Assert.Equal(itemCount, dequeuedItems.Count);
        Assert.Equal(itemCount, dequeuedItems.Distinct().Count()); // All items should be unique
        Assert.False(queue.TryDequeue(out _)); // Queue should be empty
    }

    [Fact]
    public async Task Queue_ConcurrentEnqueuesAndDequeues_MaintainsDataIntegrity()
    {
        // Arrange
        var queue = new ThreadSafeQueue<int>();
        const int operationsPerThread = 1000;
        var dequeuedItems = new System.Collections.Concurrent.ConcurrentBag<int>();
        var enqueueTask = Task.Run(() =>
        {
            for (int i = 0; i < operationsPerThread; i++)
            {
                queue.Enqueue(i);
                Thread.Sleep(0); // Yield to allow interleaving
            }
        });

        var dequeueTask = Task.Run(() =>
        {
            int dequeueCount = 0;
            while (dequeueCount < operationsPerThread)
            {
                if (queue.TryDequeue(out var item))
                {
                    dequeuedItems.Add(item);
                    dequeueCount++;
                }
                else
                {
                    Thread.Sleep(0); // Yield if queue is empty
                }
            }
        });

        // Act
        await Task.WhenAll(enqueueTask, dequeueTask);

        // Assert - All enqueued items should be dequeued exactly once
        Assert.Equal(operationsPerThread, dequeuedItems.Count);
        Assert.Equal(operationsPerThread, dequeuedItems.Distinct().Count());
        Assert.False(queue.TryDequeue(out _)); // Queue should be empty
    }

    [Fact]
    public async Task Queue_HighlyContentiousAccess_NoDataCorruption()
    {
        // Arrange
        var queue = new ThreadSafeQueue<int>();
        const int threadCount = 20;
        const int operationsPerThread = 100;
        var allEnqueuedItems = new System.Collections.Concurrent.ConcurrentBag<int>();
        var allDequeuedItems = new System.Collections.Concurrent.ConcurrentBag<int>();
        var tasks = new Task[threadCount];

        // Act - Mixed operations from multiple threads
        for (int i = 0; i < threadCount; i++)
        {
            int threadId = i;
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < operationsPerThread; j++)
                {
                    int value = threadId * operationsPerThread + j;
                    queue.Enqueue(value);
                    allEnqueuedItems.Add(value);

                    // Try to dequeue immediately
                    if (queue.TryDequeue(out var item))
                    {
                        allDequeuedItems.Add(item);
                    }
                }
            });
        }

        await Task.WhenAll(tasks);

        // Dequeue any remaining items
        while (queue.TryDequeue(out var item))
        {
            allDequeuedItems.Add(item);
        }

        // Assert - All enqueued items should eventually be dequeued
        Assert.Equal(allEnqueuedItems.Count, allDequeuedItems.Count);
        Assert.Equal(allEnqueuedItems.OrderBy(x => x), allDequeuedItems.OrderBy(x => x));
        Assert.False(queue.TryDequeue(out _)); // Queue should be empty
    }

    #endregion

    #region Integration Tests

    [Fact]
    public void Queue_ComplexScenario_WorksCorrectly()
    {
        // Arrange
        var queue = new ThreadSafeQueue<string>();

        // Act & Assert - Complex sequence of operations
        queue.Enqueue("first");
        queue.Enqueue("second");

        Assert.True(queue.TryDequeue(out var item1));
        Assert.Equal("first", item1);

        queue.Enqueue("third");
        queue.Enqueue("fourth");

        Assert.True(queue.TryDequeue(out var item2));
        Assert.Equal("second", item2);
        Assert.True(queue.TryDequeue(out var item3));
        Assert.Equal("third", item3);

        queue.Enqueue("fifth");

        Assert.True(queue.TryDequeue(out var item4));
        Assert.Equal("fourth", item4);
        Assert.True(queue.TryDequeue(out var item5));
        Assert.Equal("fifth", item5);
        Assert.False(queue.TryDequeue(out _));
    }

    [Fact]
    public void Queue_WithCustomClass_WorksCorrectly()
    {
        // Arrange
        var queue = new ThreadSafeQueue<TestClass>();
        var item1 = new TestClass { Id = 1, Name = "First" };
        var item2 = new TestClass { Id = 2, Name = "Second" };

        // Act
        queue.Enqueue(item1);
        queue.Enqueue(item2);

        // Assert
        Assert.True(queue.TryDequeue(out var dequeuedItem1));
        Assert.Equal(1, dequeuedItem1.Id);
        Assert.Equal("First", dequeuedItem1.Name);
        Assert.Same(item1, dequeuedItem1);

        Assert.True(queue.TryDequeue(out var dequeuedItem2));
        Assert.Same(item2, dequeuedItem2);
    }

    [Fact]
    public void Queue_LargeNumberOfItems_WorksCorrectly()
    {
        // Arrange
        var queue = new ThreadSafeQueue<int>();
        const int itemCount = 10000;

        // Act
        for (int i = 0; i < itemCount; i++)
        {
            queue.Enqueue(i);
        }

        // Assert
        for (int i = 0; i < itemCount; i++)
        {
            Assert.True(queue.TryDequeue(out var item));
            Assert.Equal(i, item);
        }

        Assert.False(queue.TryDequeue(out _));
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
