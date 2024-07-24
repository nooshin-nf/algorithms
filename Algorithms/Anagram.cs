using System.Text.RegularExpressions;

namespace Algorithms
{
    public class Anagram
    {
        public static bool Execute(string input1, string input2)
        {
            Regex regex = new Regex(@"[^\w]");
            var state1 = CharCount(regex.Replace(input1, "")
                .ToLower().ToCharArray());
            var state2 = CharCount(regex.Replace(input2, "")
                .ToLower().ToCharArray());

            if (state1.Count != state2.Count)
                return false;

            foreach (var pair in state1)
            {
                if (!state2.ContainsKey(pair.Key)
                    || state2[pair.Key] != pair.Value)
                    return false;
            }
            return true;
        }
        static Dictionary<char, int> CharCount(char[] input)
        {
            var result = new Dictionary<char, int>();
            foreach (var character in input)
            {
                if (result.ContainsKey(character))
                    result[character]++;
                else
                    result[character] = 1;
            }
            return result;
        }
    }
}
