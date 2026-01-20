# Desk Allocation Challenge

## Problem Statement

You are managing an office space with multiple desks, each having different seating capacities. When a booking request comes in for a group of people (or an individual), you need to allocate them to an appropriate desk based on the desk's available capacity.

### Requirements

1. **Optimal Allocation**: Allocate groups to the smallest desk that can accommodate them to maximise efficient use of space
2. **Availability Tracking**: Track which desks are occupied and which are available
3. **Booking Management**: Support booking and releasing desks
4. **Capacity Validation**: Reject bookings that cannot be accommodated by any available desk
5. **Multiple Bookings**: Handle multiple concurrent bookings

### Business Rules

- A desk can only be allocated if it has sufficient capacity for the entire group
- Once allocated, a desk is fully occupied (no partial occupancy)
- If multiple desks can accommodate a group, choose the one with the smallest capacity (best fit)
- Groups cannot be split across multiple desks
- If no suitable desk is available, the booking should fail gracefully

## Examples

### Example 1: Basic Allocation

**Office Setup:**
- Desk A: Capacity 2
- Desk B: Capacity 4
- Desk C: Capacity 6

**Booking Requests:**
1. Book for 3 people → Allocated to Desk B (capacity 4)
2. Book for 2 people → Allocated to Desk A (capacity 2)
3. Book for 5 people → Allocated to Desk C (capacity 6)
4. Book for 1 person → No available desk (all occupied)

### Example 2: Best Fit Algorithm

**Office Setup:**
- Desk A: Capacity 4
- Desk B: Capacity 6
- Desk C: Capacity 8

**Booking Request:** 5 people

**Result:** Allocated to Desk B (capacity 6) because:
- Desk A (4) is too small
- Desk B (6) can fit 5 people with minimal waste
- Desk C (8) could fit but would waste more space

### Example 3: Release and Reallocation

**Office Setup:**
- Desk A: Capacity 2 (occupied)
- Desk B: Capacity 4 (occupied)

**Actions:**
1. Release Desk A → Now available
2. Book for 2 people → Allocated to Desk A
3. Release Desk B → Now available
4. Book for 3 people → Allocated to Desk B

## Constraints

- 1 ≤ Number of desks ≤ 1000
- 1 ≤ Desk capacity ≤ 100
- 1 ≤ Group size ≤ 100
- Desk IDs must be unique
- Group size must be positive

## Solution Approach

### Data Structures

1. **Desk Class**: Represents a desk with ID, capacity, and occupancy status
2. **Booking Class**: Represents a successful booking with desk assignment
3. **DeskAllocationSystem**: Manages all desks and booking operations

### Algorithm

The solution uses a **Best Fit** allocation strategy:

1. Filter available desks (not currently occupied)
2. Filter desks with sufficient capacity for the group
3. Sort by capacity (ascending) to find the smallest suitable desk
4. Allocate to the first desk in the sorted list
5. Track the booking

### Time Complexity

- **Book Operation**: O(n log n) where n is the number of desks (due to sorting)
- **Release Operation**: O(n) where n is the number of bookings
- **Get Available Desks**: O(n) where n is the number of desks

### Space Complexity

O(n + m) where n is the number of desks and m is the number of active bookings

## C# Implementation

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeskAllocation
{
    /// <summary>
    /// Represents a desk in the office with a unique identifier and capacity.
    /// </summary>
    public class Desk
    {
        public string Id { get; }
        public int Capacity { get; }
        public bool IsOccupied { get; set; }

        public Desk(string id, int capacity)
        {
            // Validation: Ensure desk has valid ID and positive capacity
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Desk ID cannot be null or empty", nameof(id));

            if (capacity <= 0)
                throw new ArgumentException("Desk capacity must be positive", nameof(capacity));

            Id = id;
            Capacity = capacity;
            IsOccupied = false;
        }

        public override string ToString()
        {
            return $"Desk {Id} (Capacity: {Capacity}, {(IsOccupied ? "Occupied" : "Available")})";
        }
    }

    /// <summary>
    /// Represents a booking that links a group to an allocated desk.
    /// </summary>
    public class Booking
    {
        public string BookingId { get; }
        public string DeskId { get; }
        public int GroupSize { get; }
        public DateTime BookingTime { get; }

        public Booking(string bookingId, string deskId, int groupSize)
        {
            BookingId = bookingId;
            DeskId = deskId;
            GroupSize = groupSize;
            BookingTime = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"Booking {BookingId}: {GroupSize} people at Desk {DeskId} (Time: {BookingTime:yyyy-MM-dd HH:mm:ss})";
        }
    }

    /// <summary>
    /// Result of a booking attempt.
    /// </summary>
    public class BookingResult
    {
        public bool Success { get; }
        public string Message { get; }
        public Booking? Booking { get; }

        private BookingResult(bool success, string message, Booking? booking = null)
        {
            Success = success;
            Message = message;
            Booking = booking;
        }

        public static BookingResult CreateSuccess(Booking booking)
        {
            return new BookingResult(true, "Booking successful", booking);
        }

        public static BookingResult CreateFailure(string reason)
        {
            return new BookingResult(false, reason);
        }
    }

    /// <summary>
    /// Manages desk allocation using a best-fit algorithm.
    /// </summary>
    public class DeskAllocationSystem
    {
        private readonly Dictionary<string, Desk> _desks;
        private readonly Dictionary<string, Booking> _bookings;
        private int _bookingCounter;

        public DeskAllocationSystem()
        {
            _desks = new Dictionary<string, Desk>();
            _bookings = new Dictionary<string, Booking>();
            _bookingCounter = 0;
        }

        /// <summary>
        /// Adds a desk to the system.
        /// </summary>
        public void AddDesk(Desk desk)
        {
            // Validation: Prevent duplicate desk IDs
            if (_desks.ContainsKey(desk.Id))
                throw new InvalidOperationException($"Desk with ID '{desk.Id}' already exists");

            _desks[desk.Id] = desk;
        }

        /// <summary>
        /// Attempts to book a desk for the specified group size using best-fit algorithm.
        /// </summary>
        /// <param name="groupSize">Number of people in the group</param>
        /// <returns>BookingResult indicating success or failure</returns>
        public BookingResult BookDesk(int groupSize)
        {
            // Validation: Ensure group size is positive
            if (groupSize <= 0)
                return BookingResult.CreateFailure("Group size must be positive");

            // Find the best-fit desk: smallest available desk with sufficient capacity
            var suitableDesk = _desks.Values
                .Where(d => !d.IsOccupied && d.Capacity >= groupSize)
                .OrderBy(d => d.Capacity)  // Best fit: smallest capacity first
                .FirstOrDefault();

            if (suitableDesk == null)
            {
                return BookingResult.CreateFailure(
                    $"No available desk found for group of {groupSize} people");
            }

            // Mark desk as occupied
            suitableDesk.IsOccupied = true;

            // Create booking record
            var bookingId = $"BK{++_bookingCounter:D6}";
            var booking = new Booking(bookingId, suitableDesk.Id, groupSize);
            _bookings[bookingId] = booking;

            return BookingResult.CreateSuccess(booking);
        }

        /// <summary>
        /// Releases a desk by cancelling the booking.
        /// </summary>
        /// <param name="bookingId">The booking ID to cancel</param>
        /// <returns>True if booking was cancelled, false if not found</returns>
        public bool ReleaseDesk(string bookingId)
        {
            // Validation: Check if booking exists
            if (!_bookings.TryGetValue(bookingId, out var booking))
                return false;

            // Release the desk
            if (_desks.TryGetValue(booking.DeskId, out var desk))
            {
                desk.IsOccupied = false;
            }

            // Remove booking record
            _bookings.Remove(bookingId);
            return true;
        }

        /// <summary>
        /// Gets all desks in the system.
        /// </summary>
        public IReadOnlyCollection<Desk> GetAllDesks()
        {
            return _desks.Values.ToList().AsReadOnly();
        }

        /// <summary>
        /// Gets all available (unoccupied) desks.
        /// </summary>
        public IReadOnlyCollection<Desk> GetAvailableDesks()
        {
            return _desks.Values
                .Where(d => !d.IsOccupied)
                .ToList()
                .AsReadOnly();
        }

        /// <summary>
        /// Gets all active bookings.
        /// </summary>
        public IReadOnlyCollection<Booking> GetActiveBookings()
        {
            return _bookings.Values.ToList().AsReadOnly();
        }

        /// <summary>
        /// Gets statistics about desk utilisation.
        /// </summary>
        public (int Total, int Occupied, int Available, double UtilisationRate) GetStatistics()
        {
            var total = _desks.Count;
            var occupied = _desks.Values.Count(d => d.IsOccupied);
            var available = total - occupied;
            var utilisationRate = total > 0 ? (double)occupied / total * 100 : 0;

            return (total, occupied, available, utilisationRate);
        }
    }

    /// <summary>
    /// Demonstration program showing desk allocation system in action.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Desk Allocation System Demo ===\n");

            // Initialise the system
            var system = new DeskAllocationSystem();

            // Add desks with various capacities
            system.AddDesk(new Desk("A101", 2));
            system.AddDesk(new Desk("A102", 4));
            system.AddDesk(new Desk("A103", 6));
            system.AddDesk(new Desk("B201", 4));
            system.AddDesk(new Desk("B202", 8));

            Console.WriteLine("Office Setup:");
            foreach (var desk in system.GetAllDesks())
            {
                Console.WriteLine($"  {desk}");
            }
            Console.WriteLine();

            // Scenario 1: Book desks for various group sizes
            Console.WriteLine("--- Scenario 1: Booking Desks ---");
            BookAndDisplay(system, 3);  // Should get A102 (capacity 4)
            BookAndDisplay(system, 2);  // Should get A101 (capacity 2)
            BookAndDisplay(system, 5);  // Should get A103 (capacity 6)
            BookAndDisplay(system, 7);  // Should get B202 (capacity 8)

            DisplayStatistics(system);
            Console.WriteLine();

            // Scenario 2: Try booking when limited desks available
            Console.WriteLine("--- Scenario 2: Limited Availability ---");
            BookAndDisplay(system, 3);  // Should get B201 (capacity 4) - only one left

            DisplayStatistics(system);
            Console.WriteLine();

            // Scenario 3: Try booking when no desks available
            Console.WriteLine("--- Scenario 3: No Availability ---");
            BookAndDisplay(system, 1);  // Should fail - all desks occupied

            Console.WriteLine();

            // Scenario 4: Release a desk and book again
            Console.WriteLine("--- Scenario 4: Release and Rebook ---");
            var bookings = system.GetActiveBookings().ToList();
            if (bookings.Count > 0)
            {
                var firstBooking = bookings[0];
                Console.WriteLine($"Releasing: {firstBooking}");
                system.ReleaseDesk(firstBooking.BookingId);
                Console.WriteLine("Desk released successfully\n");
            }

            DisplayStatistics(system);

            BookAndDisplay(system, 2);  // Should now succeed

            Console.WriteLine();

            // Final state
            Console.WriteLine("--- Final Office State ---");
            foreach (var desk in system.GetAllDesks())
            {
                Console.WriteLine($"  {desk}");
            }
        }

        private static void BookAndDisplay(DeskAllocationSystem system, int groupSize)
        {
            Console.WriteLine($"Attempting to book desk for {groupSize} people...");
            var result = system.BookDesk(groupSize);

            if (result.Success && result.Booking != null)
            {
                Console.WriteLine($"  ✓ Success: {result.Booking}");
            }
            else
            {
                Console.WriteLine($"  ✗ Failed: {result.Message}");
            }
        }

        private static void DisplayStatistics(DeskAllocationSystem system)
        {
            var stats = system.GetStatistics();
            Console.WriteLine($"\nStatistics:");
            Console.WriteLine($"  Total Desks: {stats.Total}");
            Console.WriteLine($"  Occupied: {stats.Occupied}");
            Console.WriteLine($"  Available: {stats.Available}");
            Console.WriteLine($"  Utilisation Rate: {stats.UtilisationRate:F1}%");
        }
    }
}
```

## Test Cases

### Test Case 1: Basic Booking Flow

```csharp
[Test]
public void BookDesk_WithAvailableCapacity_ShouldSucceed()
{
    var system = new DeskAllocationSystem();
    system.AddDesk(new Desk("D1", 4));

    var result = system.BookDesk(3);

    Assert.IsTrue(result.Success);
    Assert.IsNotNull(result.Booking);
    Assert.AreEqual("D1", result.Booking.DeskId);
}
```

### Test Case 2: Best Fit Algorithm

```csharp
[Test]
public void BookDesk_MultipleOptions_ShouldSelectSmallestSuitable()
{
    var system = new DeskAllocationSystem();
    system.AddDesk(new Desk("Small", 4));
    system.AddDesk(new Desk("Large", 10));

    var result = system.BookDesk(3);

    Assert.IsTrue(result.Success);
    Assert.AreEqual("Small", result.Booking.DeskId);
}
```

### Test Case 3: Insufficient Capacity

```csharp
[Test]
public void BookDesk_InsufficientCapacity_ShouldFail()
{
    var system = new DeskAllocationSystem();
    system.AddDesk(new Desk("D1", 2));

    var result = system.BookDesk(5);

    Assert.IsFalse(result.Success);
    Assert.IsNull(result.Booking);
}
```

### Test Case 4: Release and Rebook

```csharp
[Test]
public void ReleaseDesk_ThenBook_ShouldSucceed()
{
    var system = new DeskAllocationSystem();
    system.AddDesk(new Desk("D1", 4));

    var booking1 = system.BookDesk(3);
    system.ReleaseDesk(booking1.Booking.BookingId);
    var booking2 = system.BookDesk(2);

    Assert.IsTrue(booking2.Success);
    Assert.AreEqual("D1", booking2.Booking.DeskId);
}
```

### Test Case 5: Invalid Input Validation

```csharp
[Test]
public void BookDesk_WithZeroGroupSize_ShouldFail()
{
    var system = new DeskAllocationSystem();
    system.AddDesk(new Desk("D1", 4));

    var result = system.BookDesk(0);

    Assert.IsFalse(result.Success);
}

[Test]
public void AddDesk_WithDuplicateId_ShouldThrowException()
{
    var system = new DeskAllocationSystem();
    system.AddDesk(new Desk("D1", 4));

    Assert.Throws<InvalidOperationException>(() =>
        system.AddDesk(new Desk("D1", 6)));
}
```

## Complexity Analysis

| Operation | Time Complexity | Space Complexity |
|-----------|----------------|------------------|
| AddDesk | O(1) | O(1) |
| BookDesk | O(n log n) | O(1) |
| ReleaseDesk | O(n) | O(1) |
| GetAvailableDesks | O(n) | O(n) |
| GetStatistics | O(n) | O(1) |

**Where:**
- n = number of desks in the system
- m = number of active bookings

## Extensions and Enhancements

### Possible Improvements

1. **Priority Booking**: Add priority levels for VIP bookings
2. **Time-based Booking**: Support specific time slots (9am-5pm)
3. **Desk Features**: Add desk attributes (window seat, standing desk, etc.)
4. **Waitlist**: Queue requests when no desks available
5. **Analytics**: Track utilisation patterns over time
6. **Notifications**: Alert when desks become available
7. **Multi-room Support**: Extend to multiple rooms/floors
8. **Optimisation**: Use min-heap for O(log n) booking instead of sorting

### Alternative Algorithms

1. **First Fit**: Allocate to first available desk (faster but less optimal)
2. **Worst Fit**: Allocate to largest desk (minimises fragmentation)
3. **Load Balancing**: Distribute bookings evenly across desks

## Usage Example

```csharp
// Create and configure the system
var allocationSystem = new DeskAllocationSystem();

// Add desks
allocationSystem.AddDesk(new Desk("Desk-A", 2));
allocationSystem.AddDesk(new Desk("Desk-B", 4));
allocationSystem.AddDesk(new Desk("Desk-C", 6));

// Book a desk
var result = allocationSystem.BookDesk(3);
if (result.Success)
{
    Console.WriteLine($"Booked: {result.Booking}");

    // Later, release the desk
    allocationSystem.ReleaseDesk(result.Booking.BookingId);
}

// Check statistics
var stats = allocationSystem.GetStatistics();
Console.WriteLine($"Utilisation: {stats.UtilisationRate:F1}%");
```

## Conclusion

This solution provides a robust desk allocation system using the **Best Fit** algorithm, ensuring efficient space utilisation while maintaining code quality through proper validation, clear separation of concerns, and comprehensive error handling. The implementation follows C# best practices and is production-ready with room for extensions based on business requirements.
