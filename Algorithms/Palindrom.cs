namespace Algorithms
{
    public class Palindrom
    {
        public static bool Execute(string input)
        {
            return input == ReverseString.Execute_V2(input);
        }
        public static bool Execute_V2(string input)
        {
            var len = input.Length;
            for (int i = 0; i < len / 2; i++)
            {
                if (input[i] != input[len - i - 1])
                    return false;
            }
            return true;
        }

    }
}
