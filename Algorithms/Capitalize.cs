namespace Algorithms;

// ---Directions
// Write a function that accept a string. The function should
// capitalize first letter of each word in the string 
// then return the capitalized string.
// ---Example
// Capitalize("look, it is working!") --> "Look, It Is Working!"

public class Capitalize
{
    public static string Execute(string input)
    {
        var result = string.Empty;
        var words = input.Split(" ");
        foreach (var word in words)
        {
            var letters = word.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            result = $"{result} {new string(letters)}";
        }
        return result.Trim();
    }

    public static void Print(string input)
    {
        var result = Execute(input);
        Console.WriteLine("Capitalize string:");
        Console.WriteLine(result);
    }
}
