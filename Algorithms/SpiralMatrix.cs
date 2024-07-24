namespace Algorithms;

// ---Directions
// Write a function that accept an integer number N. 
// and returns a NxN spiral matrix

public class SpiralMatrix
{
    public static int[,] Execute(int n)
    {
        var matrix = new int[n, n];
        var startRow = 0;
        var startColumn = 0;
        var endRow = n - 1;
        var endColumn = n - 1;
        var counter = 1;
        while (startColumn <= endColumn && startRow <= endRow)
        {
            // go right
            for (int i = startColumn; i <= endColumn; i++)
            {
                matrix[startRow, i] = counter++;
            }
            startRow++;

            // go down
            for (int i = startRow; i <= endRow; i++)
            {
                matrix[i, endColumn] = counter++;
            }
            endColumn--;

            // go left
            for (int i = endColumn; i >= startColumn; i--)
            {
                matrix[endRow, i] = counter++;
            }
            endRow--;

            // go up
            for (int i = endRow; i >= startRow; i--)
            {
                matrix[i, startColumn] = counter++;
            }
            startColumn++;
        }
        return matrix;
    }

    public static void Print(int n)
    {
        var size = n * n;
        var length = size.ToString().Length + 1;
        var result = Execute(n);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var space = new string(' ', length - result[i, j].ToString().Length);
                Console.Write(result[i, j] + space);
            }
            Console.WriteLine();
        }
    }
}
