namespace Algorithms;

// ---Directions
// Print out the n-th entry in Fibonacci series. 
// [0,1,1,2,3,5,8,13,21,...]
// O(n) linear runtime
public class Fibonacci
{
    private static Dictionary<int, int> Memoized { get; set; } = [];
    private const int Max = 46;
    private const int Min = 0;
    public static int[] Fib(int n)
    {
        if (n < Min || n > Max)
            throw new ArgumentOutOfRangeException($"The number must be in the range of {Min} to {Max}");
        var fib = new int[n + 1];
        fib[0] = 0;
        fib[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            fib[i] = fib[i - 2] + fib[i - 1];
        }
        return fib;
    }

    // Recursive
    public static int RecursiveFib(int n)
    {
        if (n < Min || n > Max)
            throw new ArgumentOutOfRangeException($"The number must be in the range of {Min} to {Max}");
        if (Memoized.ContainsKey(n))
            return Memoized[n];
        if (n < 2)
            Memoized[n] = n;
        else
            Memoized[n] = RecursiveFib(n - 2) + RecursiveFib(n - 1);
        return Memoized[n];
    }
}
