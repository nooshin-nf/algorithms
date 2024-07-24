namespace Algorithms
{
    public class FizzBazz
    {
        public static string[] Execute(int max)
        {
            var result = new string[max];
            for (int i = 1; i <= max; i++)
            {
                if (i % 15 == 0)
                    result[i - 1] = "fizzbuzz";
                else if (i % 3 == 0)
                    result[i - 1] = "fizz";
                else if (i % 5 == 0)
                    result[i - 1] = "buzz";
                else
                    result[i - 1] = i.ToString();
            }
            return result;
        }

    }
}
