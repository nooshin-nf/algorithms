using System.Text;

namespace Algorithms
{
    public class ReverseString
    {
        public static string Execute(string input)
        {
            var arr = input.ToCharArray();
            var len = arr.Length;
            for (int i = 0; i < len / 2; i++)
            {
                (arr[len - i - 1], arr[i]) = (arr[i], arr[len - i - 1]);
            }
            return string.Concat(arr);
        }

        public static string Execute_V2(string input)
        {
            var builer = new StringBuilder();
            foreach (var character in input)
            {
                builer = builer.Insert(0, character);
            }
            return builer.ToString();
        }

    }
}
