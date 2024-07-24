namespace Algorithms
{
    public class MaxChar
    {
        public static char Execute(string input)
        {
            var charCount = new Dictionary<char, int>();
            var max = 0;
            char maxChar = ' ';
            foreach (var character in input)
            {
                if (charCount.ContainsKey(character))
                    charCount[character]++;
                else
                    charCount[character] = 1;
                if (max < charCount[character])
                {
                    max = charCount[character];
                    maxChar = character;
                }
            }
            return maxChar;
        }
    }
}
