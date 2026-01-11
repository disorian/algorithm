namespace Playground.Basics;

public class PersonClass
{
    public required string Name { get; set; }
    public int Age { get; set; }
}

public record Person(string Name, int Age);

public record Employee
{
    public required string Name { get; init; }
    public int Age { get; init; }
    public decimal Salary { get; set; }
};

public class CsRecord
{
    public static void Run()
    {
        var person = new Person("Alice", 30);
        var employee = new Employee { Name = "Alice", Age = 30, Salary = 75000 };
        var newPerson = person with { Name = "Ben" };

        Console.WriteLine(person);
        Console.WriteLine(employee);
        Console.WriteLine(newPerson);
    }

}