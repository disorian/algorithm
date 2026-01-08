namespace Playground.Basics;

record Point(int X, int Y);

public class PatternMatching
{
    public static void Run()
    {
        // TypePattern();
        // PropertyPattern();
        // ListPattern();
        RelationalPattern(85);
    }

    private static void TypePattern()
    {
        object obj = "Hello";
        if (obj is string s)
        {
            Console.WriteLine($"String length is {s.Length}");
        }
    }

    // Property patterns
    private static void PropertyPattern()
    {
        var result = new Point(-5, 10) switch
        {
            { X: 0, Y: 0 } => "Origin",
            { X: > 0, Y: > 0 } => "Q1",
            { X: < 0, Y: > 0 } => "Q2",
            { X: < 0, Y: < 0 } => "Q3",
            { X: > 0, Y: < 0 } => "Q4",
            { X: 0 } => "X-axis",
            { Y: 0 } => "Y-axis",
            _ => "Unknown"
        };

        Console.WriteLine(result);

    }

    public static void ListPattern()
    {
        int[] numbers = [1, 2, 3, 4, 5];
        var results = numbers switch
        {
            [] => "Empty",
            [var x] => $"Single Element {x}",
            [var first, .., var last] => $"First: {first}, Last: {last}",
            _ => "Multi"
        };

        Console.WriteLine(results);
    }

    public static void RelationalPattern(int score)
    {
        var result = score switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };

        Console.WriteLine(result);
    }
}