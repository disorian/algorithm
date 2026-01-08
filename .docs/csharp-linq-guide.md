# C# LINQ Comprehensive Guide

## Table of Contents
1. [Introduction](#introduction)
2. [LINQ Basics](#linq-basics)
3. [Query Syntax vs Method Syntax](#query-syntax-vs-method-syntax)
4. [Filtering Operations](#filtering-operations)
5. [Projection Operations](#projection-operations)
6. [Sorting Operations](#sorting-operations)
7. [Grouping Operations](#grouping-operations)
8. [Join Operations](#join-operations)
9. [Aggregation Operations](#aggregation-operations)
10. [Set Operations](#set-operations)
11. [Partitioning Operations](#partitioning-operations)
12. [Quantifier Operations](#quantifier-operations)
13. [Element Operations](#element-operations)
14. [Generation Operations](#generation-operations)
15. [Conversion Operations](#conversion-operations)
16. [Deferred vs Immediate Execution](#deferred-vs-immediate-execution)
17. [Complex Real-World Examples](#complex-real-world-examples)
18. [Performance Considerations](#performance-considerations)
19. [Best Practices](#best-practices)

## Introduction

LINQ (Language Integrated Query) is a powerful feature in C# that provides a consistent query experience across different data sources. It enables you to query collections, databases, XML, and more using a unified syntax.

### Key Benefits
- **Type Safety**: Compile-time checking of queries
- **IntelliSense Support**: Full IDE support with autocomplete
- **Readability**: Declarative syntax that expresses intent clearly
- **Composability**: Chain operations to build complex queries
- **Consistency**: Same syntax across different data sources

## LINQ Basics

### Required Namespace
```csharp
using System.Linq;
using System.Collections.Generic;
```

### Sample Data Classes
```csharp
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
}

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
```

## Query Syntax vs Method Syntax

LINQ offers two syntaxes: query syntax (SQL-like) and method syntax (fluent API with lambda expressions).

### Query Syntax
```csharp
var result = from person in people
             where person.Age > 25
             select person.Name;
```

### Method Syntax
```csharp
var result = people
    .Where(person => person.Age > 25)
    .Select(person => person.Name);
```

### When to Use Each

**Query Syntax:**
- More readable for complex queries with multiple operations
- Better for joins and group operations
- Similar to SQL, easier for those familiar with databases

**Method Syntax:**
- More flexible and powerful
- Required for certain operations (Count, Sum, Average, etc.)
- Better for chaining operations
- Preferred by many C# developers

## Filtering Operations

### Where - Basic Filtering

**Simple Filter (Method Syntax)**
```csharp
var adults = people.Where(p => p.Age >= 18);
```

**Simple Filter (Query Syntax)**
```csharp
var adults = from p in people
             where p.Age >= 18
             select p;
```

**Multiple Conditions**
```csharp
// Method syntax
var filtered = people
    .Where(p => p.Age >= 25 && p.City == "Sydney");

// Query syntax
var filtered = from p in people
               where p.Age >= 25 && p.City == "Sydney"
               select p;
```

**Complex Filtering**
```csharp
var complexFilter = people
    .Where(p => p.Age >= 25
        && (p.City == "Sydney" || p.City == "Melbourne")
        && p.Salary > 50000
        && p.Department.StartsWith("IT"));
```

**Filtering with Index**
```csharp
// Get every second person
var everySecond = people
    .Where((person, index) => index % 2 == 0);
```

### OfType - Filter by Type

```csharp
object[] mixed = { 1, "hello", 2, "world", 3.14, 42 };

// Get only integers
var integers = mixed.OfType<int>();
// Result: { 1, 2, 42 }

// Get only strings
var strings = mixed.OfType<string>();
// Result: { "hello", "world" }
```

## Projection Operations

### Select - Transform Data

**Simple Projection (Method Syntax)**
```csharp
var names = people.Select(p => p.Name);
```

**Simple Projection (Query Syntax)**
```csharp
var names = from p in people
            select p.Name;
```

**Anonymous Type Projection**
```csharp
// Method syntax
var personInfo = people.Select(p => new
{
    FullName = p.Name,
    p.Age,
    IsAdult = p.Age >= 18
});

// Query syntax
var personInfo = from p in people
                 select new
                 {
                     FullName = p.Name,
                     p.Age,
                     IsAdult = p.Age >= 18
                 };
```

**Projection to Named Type**
```csharp
public class PersonDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}

var dtos = people.Select(p => new PersonDto
{
    Name = p.Name,
    Age = p.Age
});
```

**Projection with Index**
```csharp
var numberedNames = people
    .Select((person, index) => new
    {
        Position = index + 1,
        Name = person.Name
    });
```

### SelectMany - Flatten Collections

**Basic SelectMany**
```csharp
public class Department
{
    public string Name { get; set; }
    public List<Person> Employees { get; set; }
}

var departments = new List<Department>();

// Get all employees from all departments (flattened)
var allEmployees = departments.SelectMany(d => d.Employees);
```

**SelectMany with Transformation**
```csharp
var employeeInfo = departments.SelectMany(
    dept => dept.Employees,
    (dept, employee) => new
    {
        DepartmentName = dept.Name,
        EmployeeName = employee.Name,
        employee.Age
    });
```

**SelectMany with Multiple Levels**
```csharp
public class Company
{
    public string Name { get; set; }
    public List<Department> Departments { get; set; }
}

var companies = new List<Company>();

// Get all employees from all departments in all companies
var allEmployees = companies
    .SelectMany(c => c.Departments)
    .SelectMany(d => d.Employees);
```

**SelectMany with Arrays**
```csharp
var sentences = new[]
{
    "LINQ is powerful",
    "C# is versatile"
};

var words = sentences.SelectMany(s => s.Split(' '));
// Result: { "LINQ", "is", "powerful", "C#", "is", "versatile" }
```

## Sorting Operations

### OrderBy / OrderByDescending

**Simple Sorting (Method Syntax)**
```csharp
// Ascending
var sortedByAge = people.OrderBy(p => p.Age);

// Descending
var sortedByAgeDesc = people.OrderByDescending(p => p.Age);
```

**Simple Sorting (Query Syntax)**
```csharp
// Ascending
var sortedByAge = from p in people
                  orderby p.Age
                  select p;

// Descending
var sortedByAgeDesc = from p in people
                      orderby p.Age descending
                      select p;
```

### ThenBy / ThenByDescending - Multiple Sort Keys

**Method Syntax**
```csharp
var sorted = people
    .OrderBy(p => p.City)
    .ThenByDescending(p => p.Age)
    .ThenBy(p => p.Name);
```

**Query Syntax**
```csharp
var sorted = from p in people
             orderby p.City, p.Age descending, p.Name
             select p;
```

**Complex Sorting with Custom Logic**
```csharp
var sorted = people
    .OrderBy(p => p.Department)
    .ThenByDescending(p => p.Salary)
    .ThenBy(p => p.Name.Length)
    .ThenBy(p => p.Name);
```

### Reverse - Reverse Order

```csharp
var reversed = people
    .OrderBy(p => p.Age)
    .Reverse();
```

## Grouping Operations

### GroupBy - Group Elements

**Simple Grouping (Method Syntax)**
```csharp
var groupedByCity = people.GroupBy(p => p.City);

// Iterate through groups
foreach (var group in groupedByCity)
{
    Console.WriteLine($"City: {group.Key}");
    foreach (var person in group)
    {
        Console.WriteLine($"  - {person.Name}");
    }
}
```

**Simple Grouping (Query Syntax)**
```csharp
var groupedByCity = from p in people
                    group p by p.City;
```

**Grouping with Projection**
```csharp
var cityGroups = people
    .GroupBy(
        p => p.City,
        p => p.Name
    );

// Result: Groups with city as key, list of names as values
```

**Grouping with Result Selector**
```csharp
var citySummary = people.GroupBy(
    p => p.City,
    (city, persons) => new
    {
        City = city,
        Count = persons.Count(),
        AverageAge = persons.Average(p => p.Age),
        TotalSalary = persons.Sum(p => p.Salary)
    });
```

**Complex Grouping**
```csharp
// Group by multiple properties
var grouped = people.GroupBy(p => new
{
    p.City,
    p.Department
});

// Group with detailed statistics
var statistics = people
    .GroupBy(p => p.Department)
    .Select(g => new
    {
        Department = g.Key,
        EmployeeCount = g.Count(),
        AverageSalary = g.Average(p => p.Salary),
        MinSalary = g.Min(p => p.Salary),
        MaxSalary = g.Max(p => p.Salary),
        TotalSalary = g.Sum(p => p.Salary),
        Employees = g.Select(p => p.Name).ToList()
    });
```

**Grouping with Query Syntax**
```csharp
var grouped = from p in people
              group p by p.City into cityGroup
              select new
              {
                  City = cityGroup.Key,
                  Count = cityGroup.Count(),
                  People = cityGroup.ToList()
              };
```

### ToLookup - Create Lookup Dictionary

```csharp
// Similar to GroupBy but returns ILookup (immediately executed)
var lookup = people.ToLookup(p => p.City);

// Access specific group
var sydneyPeople = lookup["Sydney"];

// Check if key exists
bool hasMelbourne = lookup.Contains("Melbourne");
```

## Join Operations

### Join - Inner Join

**Simple Join (Method Syntax)**
```csharp
var orders = new List<Order>();
var customers = new List<Person>();

var orderDetails = orders.Join(
    customers,
    order => order.CustomerId,
    customer => customer.Id,
    (order, customer) => new
    {
        OrderId = order.OrderId,
        CustomerName = customer.Name,
        OrderDate = order.OrderDate,
        TotalAmount = order.TotalAmount
    });
```

**Simple Join (Query Syntax)**
```csharp
var orderDetails = from order in orders
                   join customer in customers
                   on order.CustomerId equals customer.Id
                   select new
                   {
                       OrderId = order.OrderId,
                       CustomerName = customer.Name,
                       OrderDate = order.OrderDate,
                       TotalAmount = order.TotalAmount
                   };
```

**Multiple Joins**
```csharp
public class OrderItem
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

var orderItems = new List<OrderItem>();
var products = new List<Product>();

var fullOrderDetails = from order in orders
                       join customer in customers
                       on order.CustomerId equals customer.Id
                       join item in orderItems
                       on order.OrderId equals item.OrderId
                       join product in products
                       on item.ProductId equals product.ProductId
                       select new
                       {
                           OrderId = order.OrderId,
                           CustomerName = customer.Name,
                           ProductName = product.Name,
                           Quantity = item.Quantity,
                           TotalPrice = item.Quantity * product.Price
                       };
```

### GroupJoin - Left Outer Join

**Method Syntax**
```csharp
var customersWithOrders = customers.GroupJoin(
    orders,
    customer => customer.Id,
    order => order.CustomerId,
    (customer, customerOrders) => new
    {
        CustomerName = customer.Name,
        Orders = customerOrders.ToList(),
        OrderCount = customerOrders.Count(),
        TotalSpent = customerOrders.Sum(o => o.TotalAmount)
    });
```

**Query Syntax**
```csharp
var customersWithOrders = from customer in customers
                          join order in orders
                          on customer.Id equals order.CustomerId into customerOrders
                          select new
                          {
                              CustomerName = customer.Name,
                              Orders = customerOrders.ToList(),
                              OrderCount = customerOrders.Count()
                          };
```

**Left Outer Join Pattern**
```csharp
// Get all customers including those without orders
var leftJoin = from customer in customers
               join order in orders
               on customer.Id equals order.CustomerId into customerOrders
               from order in customerOrders.DefaultIfEmpty()
               select new
               {
                   CustomerName = customer.Name,
                   OrderId = order?.OrderId ?? 0,
                   OrderAmount = order?.TotalAmount ?? 0
               };
```

### Cross Join

```csharp
// Cartesian product
var crossJoin = from size in new[] { "S", "M", "L", "XL" }
                from colour in new[] { "Red", "Blue", "Green" }
                select new { Size = size, Colour = colour };

// Method syntax
var crossJoinMethod = sizes.SelectMany(
    size => colours,
    (size, colour) => new { Size = size, Colour = colour }
);
```

## Aggregation Operations

### Count / LongCount

```csharp
// Count all
var totalCount = people.Count();

// Count with condition
var adultsCount = people.Count(p => p.Age >= 18);

// LongCount for large collections
var largeCount = people.LongCount();
```

### Sum

```csharp
// Sum of property
var totalSalary = people.Sum(p => p.Salary);

// Sum with condition
var itSalaryTotal = people
    .Where(p => p.Department == "IT")
    .Sum(p => p.Salary);
```

### Average

```csharp
// Average age
var averageAge = people.Average(p => p.Age);

// Average with filtering
var avgItSalary = people
    .Where(p => p.Department == "IT")
    .Average(p => p.Salary);
```

### Min / Max

```csharp
// Minimum and maximum values
var minAge = people.Min(p => p.Age);
var maxAge = people.Max(p => p.Age);

var lowestSalary = people.Min(p => p.Salary);
var highestSalary = people.Max(p => p.Salary);

// Get person with maximum salary
var highestEarner = people
    .OrderByDescending(p => p.Salary)
    .First();

// Or using MaxBy (C# 6+)
var highestEarnerMaxBy = people.MaxBy(p => p.Salary);
```

### Aggregate - Custom Aggregation

```csharp
// Sum using Aggregate
var sum = new[] { 1, 2, 3, 4, 5 }.Aggregate((acc, x) => acc + x);
// Result: 15

// Product
var product = new[] { 1, 2, 3, 4, 5 }.Aggregate((acc, x) => acc * x);
// Result: 120

// Aggregate with seed value
var concatenated = people.Aggregate(
    "Employees: ",
    (acc, person) => acc + person.Name + ", "
);

// Complex aggregation with seed and result selector
var result = people.Aggregate(
    new { TotalAge = 0, Count = 0 },
    (acc, person) => new { TotalAge = acc.TotalAge + person.Age, Count = acc.Count + 1 },
    acc => acc.Count > 0 ? (double)acc.TotalAge / acc.Count : 0
);
```

## Set Operations

### Distinct - Remove Duplicates

```csharp
var numbers = new[] { 1, 2, 2, 3, 3, 3, 4, 5, 5 };
var uniqueNumbers = numbers.Distinct();
// Result: { 1, 2, 3, 4, 5 }

// Distinct with complex types
var cities = people.Select(p => p.City).Distinct();

// Distinct with custom comparer
public class PersonNameComparer : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y)
    {
        return x.Name == y.Name;
    }

    public int GetHashCode(Person obj)
    {
        return obj.Name.GetHashCode();
    }
}

var uniquePeople = people.Distinct(new PersonNameComparer());
```

### DistinctBy (C# 9+)

```csharp
// Get people with unique names
var uniqueByName = people.DistinctBy(p => p.Name);

// Get people with unique city
var uniqueByCity = people.DistinctBy(p => p.City);
```

### Union - Combine Sets

```csharp
var list1 = new[] { 1, 2, 3, 4 };
var list2 = new[] { 3, 4, 5, 6 };

var union = list1.Union(list2);
// Result: { 1, 2, 3, 4, 5, 6 }

// Union of complex types
var allPeople = sydneyPeople.Union(melbournePeople);
```

### Intersect - Common Elements

```csharp
var common = list1.Intersect(list2);
// Result: { 3, 4 }

// Find people in both lists
var commonPeople = group1.Intersect(group2);
```

### Except - Set Difference

```csharp
var difference = list1.Except(list2);
// Result: { 1, 2 }

// People in first group but not second
var uniqueToGroup1 = group1.Except(group2);
```

## Partitioning Operations

### Take / TakeLast

```csharp
// Take first 5
var firstFive = people.Take(5);

// Take last 3
var lastThree = people.TakeLast(3);
```

### TakeWhile

```csharp
var numbers = new[] { 1, 2, 3, 4, 5, 1, 2, 3 };

// Take while condition is true
var taken = numbers.TakeWhile(n => n < 4);
// Result: { 1, 2, 3 }

// Take while with index
var takenWithIndex = numbers.TakeWhile((n, index) => n < 4 && index < 5);
```

### Skip / SkipLast

```csharp
// Skip first 3
var skipped = people.Skip(3);

// Skip last 2
var skippedLast = people.SkipLast(2);
```

### SkipWhile

```csharp
// Skip while condition is true
var skipped = numbers.SkipWhile(n => n < 4);
// Result: { 4, 5, 1, 2, 3 }
```

### Pagination Pattern

```csharp
public class PagedResult<T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}

public PagedResult<Person> GetPeoplePaged(int pageNumber, int pageSize)
{
    var query = people.OrderBy(p => p.Name);

    var totalCount = query.Count();
    var items = query
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    return new PagedResult<Person>
    {
        Items = items,
        TotalCount = totalCount,
        PageNumber = pageNumber,
        PageSize = pageSize
    };
}
```

### Chunk (C# 6+)

```csharp
// Split collection into chunks
var numbers = Enumerable.Range(1, 10);
var chunks = numbers.Chunk(3);

foreach (var chunk in chunks)
{
    Console.WriteLine(string.Join(", ", chunk));
}
// Output:
// 1, 2, 3
// 4, 5, 6
// 7, 8, 9
// 10
```

## Quantifier Operations

### Any - Check if Any Element Matches

```csharp
// Check if any elements exist
bool hasElements = people.Any();

// Check if any adult exists
bool hasAdults = people.Any(p => p.Age >= 18);

// Check if any person in IT department
bool hasItEmployees = people.Any(p => p.Department == "IT");
```

### All - Check if All Elements Match

```csharp
// Check if all are adults
bool allAdults = people.All(p => p.Age >= 18);

// Check if all earn above minimum wage
bool allAboveMinimum = people.All(p => p.Salary >= 50000);
```

### Contains - Check if Specific Element Exists

```csharp
var numbers = new[] { 1, 2, 3, 4, 5 };
bool hasThree = numbers.Contains(3);

// Contains with custom comparer
var person = new Person { Id = 1, Name = "John" };
bool hasPerson = people.Contains(person, new PersonIdComparer());
```

## Element Operations

### First / FirstOrDefault

```csharp
// Get first element (throws if empty)
var first = people.First();

// Get first element or default if empty
var firstOrDefault = people.FirstOrDefault();

// Get first matching element
var firstAdult = people.First(p => p.Age >= 18);

// Get first matching or default
var firstItEmployee = people.FirstOrDefault(p => p.Department == "IT");
```

### Last / LastOrDefault

```csharp
// Get last element
var last = people.Last();

// Get last element or default
var lastOrDefault = people.LastOrDefault();

// Get last matching element
var lastAdult = people.Last(p => p.Age >= 18);
```

### Single / SingleOrDefault

```csharp
// Get single element (throws if 0 or more than 1)
var single = people.Single(p => p.Id == 5);

// Get single element or default (throws if more than 1)
var singleOrDefault = people.SingleOrDefault(p => p.Id == 5);
```

### ElementAt / ElementAtOrDefault

```csharp
// Get element at specific index
var third = people.ElementAt(2);

// Get element at index or default
var tenth = people.ElementAtOrDefault(9);
```

### DefaultIfEmpty

```csharp
var emptyList = new List<Person>();

// Get default if empty
var result = emptyList.DefaultIfEmpty();
// Result: collection with one null element

// With custom default
var resultWithDefault = emptyList.DefaultIfEmpty(new Person { Name = "Unknown" });
```

## Generation Operations

### Range - Generate Number Sequence

```csharp
// Generate numbers 1 to 10
var numbers = Enumerable.Range(1, 10);

// Generate and transform
var squares = Enumerable.Range(1, 10).Select(n => n * n);

// Generate with dates
var next7Days = Enumerable.Range(0, 7)
    .Select(day => DateTime.Today.AddDays(day));
```

### Repeat - Repeat Value

```csharp
// Repeat value 5 times
var repeated = Enumerable.Repeat("Hello", 5);

// Create default instances
var defaultPeople = Enumerable.Repeat(new Person(), 10);
```

### Empty - Create Empty Sequence

```csharp
// Create empty sequence
var empty = Enumerable.Empty<Person>();

// Useful for default returns
public IEnumerable<Person> GetPeople(string filter)
{
    if (string.IsNullOrEmpty(filter))
        return Enumerable.Empty<Person>();

    return people.Where(p => p.Name.Contains(filter));
}
```

## Conversion Operations

### ToList / ToArray

```csharp
// Convert to List
var personList = people
    .Where(p => p.Age >= 18)
    .ToList();

// Convert to Array
var personArray = people
    .Where(p => p.Age >= 18)
    .ToArray();
```

### ToDictionary

```csharp
// Create dictionary with Id as key
var personDict = people.ToDictionary(p => p.Id);

// Create dictionary with custom key and value
var nameAgeDict = people.ToDictionary(
    p => p.Name,
    p => p.Age
);

// With duplicate key handling
var cityPersonDict = people
    .GroupBy(p => p.City)
    .ToDictionary(
        g => g.Key,
        g => g.ToList()
    );
```

### ToHashSet

```csharp
// Create HashSet
var citySet = people
    .Select(p => p.City)
    .ToHashSet();
```

### ToLookup

```csharp
// Create lookup (multi-value dictionary)
var cityLookup = people.ToLookup(p => p.City);

// Access values
var sydneyPeople = cityLookup["Sydney"];
```

### AsEnumerable / AsQueryable

```csharp
// Convert to IEnumerable
IEnumerable<Person> enumerable = people.AsEnumerable();

// Convert to IQueryable (for LINQ to SQL, EF, etc.)
IQueryable<Person> queryable = people.AsQueryable();
```

### Cast

```csharp
// Cast all elements
ArrayList arrayList = new ArrayList { 1, 2, 3, 4, 5 };
var integers = arrayList.Cast<int>();
```

## Deferred vs Immediate Execution

### Deferred Execution

```csharp
// Query is defined but not executed
var query = people.Where(p => p.Age > 25);

// Executed when enumerated
foreach (var person in query)
{
    Console.WriteLine(person.Name);
}

// Executed again (may give different results if source changed)
var count = query.Count();
```

### Immediate Execution

```csharp
// Immediately executed and stored
var list = people.Where(p => p.Age > 25).ToList();

// These operators cause immediate execution:
var count = people.Count();
var array = people.ToArray();
var dict = people.ToDictionary(p => p.Id);
var first = people.First();
var sum = people.Sum(p => p.Salary);
```

### Multiple Enumeration Issues

```csharp
// BAD: Multiple enumeration
var query = people.Where(p => p.Age > 25);
var count = query.Count();  // First enumeration
var list = query.ToList();  // Second enumeration

// GOOD: Single enumeration
var list = people.Where(p => p.Age > 25).ToList();
var count = list.Count;
```

## Complex Real-World Examples

### Example 1: Sales Report

```csharp
public class Sale
{
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime SaleDate { get; set; }
    public string Region { get; set; }
}

// Generate comprehensive sales report
var salesReport = sales
    .Where(s => s.SaleDate.Year == DateTime.Now.Year)
    .GroupBy(s => new { s.Region, Month = s.SaleDate.Month })
    .Select(g => new
    {
        Region = g.Key.Region,
        Month = g.Key.Month,
        TotalSales = g.Sum(s => s.Quantity * s.UnitPrice),
        TotalUnits = g.Sum(s => s.Quantity),
        AverageOrderValue = g.Average(s => s.Quantity * s.UnitPrice),
        OrderCount = g.Count(),
        TopProducts = g
            .GroupBy(s => s.ProductId)
            .OrderByDescending(pg => pg.Sum(s => s.Quantity))
            .Take(5)
            .Select(pg => new
            {
                ProductId = pg.Key,
                QuantitySold = pg.Sum(s => s.Quantity)
            })
            .ToList()
    })
    .OrderBy(r => r.Region)
    .ThenBy(r => r.Month)
    .ToList();
```

### Example 2: Employee Hierarchy

```csharp
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ManagerId { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}

// Get employee with their direct reports
var employeeHierarchy = employees
    .GroupJoin(
        employees,
        manager => manager.Id,
        employee => employee.ManagerId,
        (manager, reports) => new
        {
            Manager = manager,
            DirectReports = reports.ToList(),
            DirectReportCount = reports.Count(),
            TotalTeamSalary = reports.Sum(e => e.Salary) + manager.Salary,
            DepartmentDistribution = reports
                .GroupBy(e => e.Department)
                .Select(g => new { Department = g.Key, Count = g.Count() })
                .ToList()
        }
    )
    .Where(h => h.DirectReportCount > 0)
    .OrderByDescending(h => h.DirectReportCount)
    .ToList();
```

### Example 3: Inventory Analysis

```csharp
public class InventoryItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public int CurrentStock { get; set; }
    public int ReorderLevel { get; set; }
    public decimal UnitCost { get; set; }
    public DateTime LastRestockDate { get; set; }
}

// Complex inventory analysis
var inventoryAnalysis = inventory
    .Select(item => new
    {
        Item = item,
        StockValue = item.CurrentStock * item.UnitCost,
        DaysSinceRestock = (DateTime.Now - item.LastRestockDate).Days,
        StockStatus = item.CurrentStock <= item.ReorderLevel ? "Reorder" :
                     item.CurrentStock <= item.ReorderLevel * 1.5m ? "Low" : "OK"
    })
    .GroupBy(i => i.Item.Category)
    .Select(g => new
    {
        Category = g.Key,
        TotalItems = g.Count(),
        TotalValue = g.Sum(i => i.StockValue),
        AverageStockValue = g.Average(i => i.StockValue),
        ItemsToReorder = g.Count(i => i.StockStatus == "Reorder"),
        LowStockItems = g.Count(i => i.StockStatus == "Low"),
        OldestRestockDays = g.Max(i => i.DaysSinceRestock),
        ReorderList = g
            .Where(i => i.StockStatus == "Reorder")
            .OrderBy(i => i.DaysSinceRestock)
            .Select(i => new
            {
                i.Item.ProductName,
                i.Item.CurrentStock,
                i.Item.ReorderLevel,
                i.DaysSinceRestock
            })
            .ToList()
    })
    .OrderByDescending(c => c.TotalValue)
    .ToList();
```

### Example 4: Student Performance Analysis

```csharp
public class StudentGrade
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string Subject { get; set; }
    public int Score { get; set; }
    public DateTime ExamDate { get; set; }
}

// Comprehensive student performance report
var performanceReport = grades
    .GroupBy(g => g.StudentId)
    .Select(studentGrades => new
    {
        StudentId = studentGrades.Key,
        StudentName = studentGrades.First().StudentName,
        OverallAverage = studentGrades.Average(g => g.Score),
        SubjectScores = studentGrades
            .GroupBy(g => g.Subject)
            .Select(subjectGroup => new
            {
                Subject = subjectGroup.Key,
                AverageScore = subjectGroup.Average(g => g.Score),
                BestScore = subjectGroup.Max(g => g.Score),
                WorstScore = subjectGroup.Min(g => g.Score),
                Improvement = subjectGroup
                    .OrderBy(g => g.ExamDate)
                    .Last().Score -
                    subjectGroup
                    .OrderBy(g => g.ExamDate)
                    .First().Score
            })
            .OrderBy(s => s.Subject)
            .ToList(),
        StrongSubjects = studentGrades
            .GroupBy(g => g.Subject)
            .Where(g => g.Average(x => x.Score) >= 85)
            .Select(g => g.Key)
            .ToList(),
        WeakSubjects = studentGrades
            .GroupBy(g => g.Subject)
            .Where(g => g.Average(x => x.Score) < 60)
            .Select(g => g.Key)
            .ToList(),
        PerformanceGrade = studentGrades.Average(g => g.Score) switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        }
    })
    .OrderByDescending(s => s.OverallAverage)
    .ToList();
```

### Example 5: Time Series Analysis

```csharp
public class MetricReading
{
    public DateTime Timestamp { get; set; }
    public string MetricName { get; set; }
    public double Value { get; set; }
}

// Analyse metric trends with moving average
var timeSeriesAnalysis = readings
    .Where(r => r.Timestamp >= DateTime.Now.AddDays(-30))
    .GroupBy(r => r.MetricName)
    .Select(metricGroup => new
    {
        MetricName = metricGroup.Key,
        DailyAverages = metricGroup
            .GroupBy(r => r.Timestamp.Date)
            .Select(dayGroup => new
            {
                Date = dayGroup.Key,
                Average = dayGroup.Average(r => r.Value),
                Min = dayGroup.Min(r => r.Value),
                Max = dayGroup.Max(r => r.Value),
                Samples = dayGroup.Count()
            })
            .OrderBy(d => d.Date)
            .ToList(),
        OverallStats = new
        {
            Mean = metricGroup.Average(r => r.Value),
            StdDev = Math.Sqrt(
                metricGroup.Average(r => Math.Pow(r.Value - metricGroup.Average(x => x.Value), 2))
            ),
            Min = metricGroup.Min(r => r.Value),
            Max = metricGroup.Max(r => r.Value),
            Median = metricGroup
                .OrderBy(r => r.Value)
                .Skip(metricGroup.Count() / 2)
                .First().Value
        }
    })
    .ToList();

// Calculate moving average
var movingAverage = readings
    .OrderBy(r => r.Timestamp)
    .Select((reading, index) => new
    {
        reading.Timestamp,
        reading.Value,
        MovingAvg = readings
            .OrderBy(r => r.Timestamp)
            .Skip(Math.Max(0, index - 4))
            .Take(5)
            .Average(r => r.Value)
    })
    .ToList();
```

### Example 6: E-commerce Order Processing

```csharp
public class OrderLine
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public DateTime OrderDate { get; set; }
}

// Complex order analysis
var orderAnalysis = orderLines
    .GroupBy(ol => ol.OrderId)
    .Select(orderGroup => new
    {
        OrderId = orderGroup.Key,
        CustomerId = orderGroup.First().CustomerId,
        OrderDate = orderGroup.First().OrderDate,
        SubTotal = orderGroup.Sum(ol => ol.Quantity * ol.UnitPrice),
        TotalDiscount = orderGroup.Sum(ol => ol.Discount),
        TotalAmount = orderGroup.Sum(ol => (ol.Quantity * ol.UnitPrice) - ol.Discount),
        ItemCount = orderGroup.Sum(ol => ol.Quantity),
        UniqueProducts = orderGroup.Select(ol => ol.ProductId).Distinct().Count(),
        AverageItemPrice = orderGroup.Average(ol => ol.UnitPrice),
        MostExpensiveItem = orderGroup.Max(ol => ol.UnitPrice),
        HasDiscount = orderGroup.Any(ol => ol.Discount > 0)
    })
    .Join(
        orderLines.GroupBy(ol => ol.CustomerId),
        order => order.CustomerId,
        customer => customer.Key,
        (order, customerOrders) => new
        {
            order.OrderId,
            order.CustomerId,
            order.OrderDate,
            order.TotalAmount,
            order.ItemCount,
            CustomerLifetimeValue = customerOrders.Sum(ol => (ol.Quantity * ol.UnitPrice) - ol.Discount),
            CustomerOrderCount = customerOrders.Select(ol => ol.OrderId).Distinct().Count(),
            IsRepeatCustomer = customerOrders.Select(ol => ol.OrderId).Distinct().Count() > 1
        }
    )
    .OrderByDescending(o => o.TotalAmount)
    .ToList();
```

## Performance Considerations

### 1. Deferred Execution and Multiple Enumeration

```csharp
// BAD: Multiple enumerations
var expensiveQuery = people
    .Where(p => ExpensiveOperation(p))
    .Select(p => AnotherExpensiveOperation(p));

var count = expensiveQuery.Count();      // First enumeration
var list = expensiveQuery.ToList();      // Second enumeration
var first = expensiveQuery.First();      // Third enumeration

// GOOD: Single enumeration
var results = people
    .Where(p => ExpensiveOperation(p))
    .Select(p => AnotherExpensiveOperation(p))
    .ToList();  // Execute once

var count = results.Count;
var first = results.First();
```

### 2. Early Filtering

```csharp
// BAD: Filter after expensive operations
var result = people
    .Select(p => new { Person = p, Score = CalculateComplexScore(p) })
    .Where(x => x.Person.Age > 25)
    .ToList();

// GOOD: Filter first
var result = people
    .Where(p => p.Age > 25)
    .Select(p => new { Person = p, Score = CalculateComplexScore(p) })
    .ToList();
```

### 3. Use Any() Instead of Count()

```csharp
// BAD: Counts all elements
if (people.Count() > 0)
{
    // ...
}

// GOOD: Stops at first element
if (people.Any())
{
    // ...
}

// BAD: Counts all matching elements
if (people.Count(p => p.Age > 25) > 0)
{
    // ...
}

// GOOD: Stops at first match
if (people.Any(p => p.Age > 25))
{
    // ...
}
```

### 4. Avoid Unnecessary Operations

```csharp
// BAD: Multiple sorting operations
var result = people
    .OrderBy(p => p.City)
    .Where(p => p.Age > 25)
    .OrderBy(p => p.Name)  // Previous sort wasted
    .ToList();

// GOOD: Filter first, sort once
var result = people
    .Where(p => p.Age > 25)
    .OrderBy(p => p.Name)
    .ToList();
```

### 5. Use Appropriate Data Structures

```csharp
// BAD: Repeated Contains checks on List
var idList = new List<int> { 1, 2, 3, 4, 5, /*...*/ 10000 };
var filtered = people.Where(p => idList.Contains(p.Id));  // O(n*m)

// GOOD: Use HashSet for lookups
var idSet = new HashSet<int> { 1, 2, 3, 4, 5, /*...*/ 10000 };
var filtered = people.Where(p => idSet.Contains(p.Id));  // O(n)
```

### 6. Avoid Closure Capture in Loops

```csharp
// BAD: Capturing changing variable
var queries = new List<IEnumerable<Person>>();
for (int i = 0; i < 10; i++)
{
    queries.Add(people.Where(p => p.Age > i));  // All capture same 'i'
}

// GOOD: Capture loop variable properly
var queries = new List<IEnumerable<Person>>();
for (int i = 0; i < 10; i++)
{
    int capturedValue = i;
    queries.Add(people.Where(p => p.Age > capturedValue));
}
```

## Best Practices

### 1. Prefer Method Syntax for Complex Queries

```csharp
// Query syntax can get verbose
var result = from p in people
             where p.Age > 25
             orderby p.Name
             select new { p.Name, p.Age };

// Method syntax is more concise
var result = people
    .Where(p => p.Age > 25)
    .OrderBy(p => p.Name)
    .Select(p => new { p.Name, p.Age });
```

### 2. Use Query Syntax for Joins

```csharp
// Query syntax is clearer for joins
var result = from order in orders
             join customer in customers on order.CustomerId equals customer.Id
             join product in products on order.ProductId equals product.Id
             select new { order, customer, product };

// Method syntax is more complex
var result = orders.Join(
    customers,
    order => order.CustomerId,
    customer => customer.Id,
    (order, customer) => new { order, customer })
.Join(
    products,
    oc => oc.order.ProductId,
    product => product.Id,
    (oc, product) => new { oc.order, oc.customer, product });
```

### 3. Use Meaningful Variable Names

```csharp
// BAD: Single letter variables
var result = people.Where(p => p.Age > 25).Select(p => p.Name);

// GOOD: Descriptive names for complex queries
var adultNames = people
    .Where(person => person.Age >= 18)
    .Select(person => person.Name);
```

### 4. Break Complex Queries into Steps

```csharp
// BAD: One giant query
var result = people
    .Where(p => p.Age > 25 && p.Salary > 50000)
    .GroupBy(p => p.Department)
    .Select(g => new {
        Dept = g.Key,
        Avg = g.Average(p => p.Salary),
        Count = g.Count(),
        Names = g.Select(p => p.Name).ToList()
    })
    .OrderByDescending(x => x.Avg)
    .Take(5)
    .ToList();

// GOOD: Break into logical steps
var qualifiedPeople = people
    .Where(p => p.Age > 25 && p.Salary > 50000);

var departmentStats = qualifiedPeople
    .GroupBy(p => p.Department)
    .Select(g => new
    {
        Department = g.Key,
        AverageSalary = g.Average(p => p.Salary),
        EmployeeCount = g.Count(),
        EmployeeNames = g.Select(p => p.Name).ToList()
    });

var topDepartments = departmentStats
    .OrderByDescending(d => d.AverageSalary)
    .Take(5)
    .ToList();
```

### 5. Handle Null Values

```csharp
// Use null-conditional operators
var cities = people
    .Select(p => p.Address?.City)
    .Where(city => city != null)
    .Distinct();

// Or use null-coalescing
var cities = people
    .Select(p => p.Address?.City ?? "Unknown")
    .Distinct();
```

### 6. Use Expression-Bodied Members

```csharp
public class PersonService
{
    private List<Person> _people;

    // Expression-bodied property
    public IEnumerable<Person> Adults => _people.Where(p => p.Age >= 18);

    // Expression-bodied method
    public Person GetById(int id) => _people.FirstOrDefault(p => p.Id == id);

    // Expression-bodied method with complex query
    public IEnumerable<string> GetDepartments() =>
        _people
            .Select(p => p.Department)
            .Distinct()
            .OrderBy(d => d);
}
```

### 7. Consider AsParallel for Large Datasets

```csharp
// Sequential processing
var result = largeCollection
    .Where(item => ExpensiveOperation(item))
    .Select(item => TransformItem(item))
    .ToList();

// Parallel processing (use with caution)
var result = largeCollection
    .AsParallel()
    .Where(item => ExpensiveOperation(item))
    .Select(item => TransformItem(item))
    .ToList();

// Parallel with ordering preserved
var result = largeCollection
    .AsParallel()
    .AsOrdered()
    .Where(item => ExpensiveOperation(item))
    .Select(item => TransformItem(item))
    .ToList();
```

### 8. Use Let in Query Syntax

```csharp
// Avoid recalculating the same value
var result = from p in people
             let fullName = $"{p.FirstName} {p.LastName}"
             let age = DateTime.Now.Year - p.BirthYear
             where age >= 18
             orderby fullName
             select new { fullName, age };
```

### 9. Document Complex Queries

```csharp
/// <summary>
/// Calculates department performance metrics including
/// average salary, headcount, and retention rate.
/// </summary>
/// <param name="minimumTenure">Minimum years of service to include</param>
/// <returns>Performance metrics grouped by department</returns>
public IEnumerable<DepartmentMetrics> CalculateDepartmentMetrics(int minimumTenure)
{
    return employees
        // Filter for long-term employees only
        .Where(e => e.YearsOfService >= minimumTenure)
        // Group by department to calculate metrics
        .GroupBy(e => e.Department)
        // Calculate aggregate metrics for each department
        .Select(dept => new DepartmentMetrics
        {
            DepartmentName = dept.Key,
            AverageSalary = dept.Average(e => e.Salary),
            Headcount = dept.Count(),
            RetentionRate = CalculateRetention(dept)
        })
        // Sort by performance (average salary)
        .OrderByDescending(m => m.AverageSalary);
}
```

### 10. Use Appropriate Comparison Methods

```csharp
// Case-insensitive string comparison
var filtered = people
    .Where(p => p.Name.Equals("john", StringComparison.OrdinalIgnoreCase));

// Contains with case-insensitive
var searched = people
    .Where(p => p.Name.Contains("john", StringComparison.OrdinalIgnoreCase));

// StartsWith / EndsWith
var prefixed = people
    .Where(p => p.Name.StartsWith("J", StringComparison.Ordinal));
```

---

## Summary

LINQ is a powerful and expressive feature of C# that enables:
- **Declarative querying** of data from various sources
- **Type-safe operations** with compile-time checking
- **Composable queries** that can be built incrementally
- **Lazy evaluation** that improves performance
- **Readable code** that clearly expresses intent

Key takeaways:
1. Understand deferred vs immediate execution
2. Filter early and project late for better performance
3. Use appropriate syntax (query vs method) for readability
4. Avoid multiple enumeration of the same query
5. Consider performance implications of your queries
6. Use meaningful names and break complex queries into steps
7. Leverage the full power of lambda expressions
8. Remember LINQ is not just for collections - it works with databases, XML, and more

This guide covers the fundamentals and advanced patterns of LINQ. Practice these concepts regularly to become proficient in writing efficient, maintainable LINQ queries.
