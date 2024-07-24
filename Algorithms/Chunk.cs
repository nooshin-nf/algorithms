namespace Algorithms
{
    public class Chunk
    {
        public static int[][] Execute(int[] array, int size)
        {
            var chuckCount = Math.Ceiling(array.Length / (decimal)size);
            var chunked = new int[Convert.ToInt32(chuckCount)][];
            for (int i = 0; i < chuckCount; i++)
            {
                var chuckSize = (i + 1) * size < array.Length ? size : array.Length - i * size;
                chunked[i] = new int[chuckSize];
                Array.Copy(array, i * size, chunked[i], 0, chuckSize);
            }
            return chunked;
        }

    }
}
