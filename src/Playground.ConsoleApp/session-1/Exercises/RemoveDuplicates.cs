namespace Playground.Basics;

public static class RemoveDuplicates
{
    public static (int, int[]) RemoveDuplicatesFromArray(int[] numbers)
    {
        if (numbers.Length <= 1)
            return (numbers.Length, numbers);

        int writeIndex = 1;

        for (int readIndex = 1; readIndex < numbers.Length; readIndex++)
        {
            if (numbers[readIndex] != numbers[readIndex - 1])
                numbers[writeIndex++] = numbers[readIndex];
        }

        return (writeIndex, numbers);
    }
}
