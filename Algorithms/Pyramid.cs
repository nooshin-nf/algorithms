namespace Algorithms;

// ---Directions
// Write a function that accept a positive number N. The function should
// console log ap pyramid shape
// write N levels using the # character.
// ---Example
// Pyramid(1) --> '#'
// Pyramid(2) -->' # '
//               '###'

public class Pyramid
{
    public static string[] Execute(int level)
    {
        var result = new string[level];
        var lenght = (2 * level) - 1;
        for (int row = 1; row <= level; row++)
        {
            var count = (2 * row) - 1;
            var padSize = (lenght - count) / 2;
            result[row - 1] = new string(' ', padSize) +
                new string('#', count) +
                new string(' ', padSize);
            Console.WriteLine(result[row - 1]);
        }
        return result;
    }
}
