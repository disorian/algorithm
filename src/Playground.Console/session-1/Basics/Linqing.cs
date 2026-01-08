namespace Playground.Basics;

public class Linqing
{
    public static void Run()
    {
        int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        var evenNumbers = from n in numbers
                          where n % 2 == 0
                          select n;

        var evenNumbersMethod = numbers.Where(n => n % 2 == 0);

        var doubled = numbers.Select(n => n * 2);

        var ordered = numbers.OrderBy(n => n);
        var grouped = numbers.GroupBy(n => n % 3 == 0);

        var pairs = numbers.SelectMany((x, i) => numbers.Skip(i + 1).Select(y => (x, y)));

        int limit = 20;
        var factorial = Enumerable.Range(1, limit).Aggregate(1, (acc, n) => acc * n);

        Console.WriteLine($"{limit}! = {factorial}");

        bool hasEven = numbers.Any(n => n % 2 == 0);
        bool allPossitive = numbers.All(n => n > 0);
        var firstFive = numbers.Take(5);
        var skipFirstThree = numbers.Skip(3);

        int[] duplicates = [1, 2, 2, 3, 3, 3, 4];
        var unique = duplicates.Distinct();

        Console.WriteLine(numbers.Sum());
        Console.WriteLine(numbers.Max());
        foreach (var n in doubled)
        {
            Console.WriteLine(n);
        }
    }
}