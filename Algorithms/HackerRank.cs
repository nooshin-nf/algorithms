using Algorithms.Models;
using System.Text.RegularExpressions;

namespace Algorithms
{
    // simple hackerrank algorithms 
    public class HackerRank
    {

        // Maximum Subarray
        public static List<int> MaxSubarray(List<int> arr)
        {
            var arrSize = arr.Count;
            var negativeIdxs = arr.Select((value, idx) => new { value, idx })
                .Where(x => x.value < 0).Select(x => x.idx).ToList();

            var negativeArrSize = negativeIdxs.Count;

            var subsequence = 0;
            var subarray = 0;

            if (arrSize == 0)
                return [0, 0];

            // all posetive
            if (negativeArrSize == 0)
                return [arr.Sum(), arr.Sum()];

            // all negative
            if (negativeArrSize == arrSize)
                return [arr.Max(), arr.Max()];

            var simpleArray = new List<int>();
            var startIdx = 0;
            var endIdx = 0;
            for (int i = 0; i < negativeArrSize; i++)
            {
                endIdx = negativeIdxs[i];
                var leftSum = arr.Skip(startIdx).Take(endIdx - startIdx).Sum();
                simpleArray.AddRange([leftSum, arr[endIdx]]);
                startIdx = endIdx + 1;
                if (i == negativeArrSize - 1 && arrSize - 1 > endIdx)
                {
                    var rightSum = arr.Skip(endIdx + 1).Take(arrSize - endIdx - 1).Sum();
                    simpleArray.Add(rightSum);
                }
            }

            subarray = simpleArray[0];
            var temp = simpleArray[0];
            for (int i = 1; i < simpleArray.Count; i++)
            {
                temp += simpleArray[i];
                if (temp > 0)
                {
                    if (temp > subarray)
                        subarray = temp;
                }
                else
                    temp = 0;
            }
            subsequence = arr.Where(x => x > 0).Sum();
            return [subarray, subsequence];
        }

        // EqualStacks
        public static int EqualStacks(List<int> h1, List<int> h2, List<int> h3)
        {
            while (true)
            {
                var sum1 = h1.Sum();
                var sum2 = h2.Sum();
                var sum3 = h3.Sum();

                if (sum1 == sum2 && sum1 == sum3)
                    return sum1;

                if (sum1 > sum2 && sum1 > sum3)
                    h1.RemoveAt(0);
                else if (sum2 > sum3)
                    h2.RemoveAt(0);
                else
                    h3.RemoveAt(0);
            }
        }

        // Climbing the Leaderboard
        public static List<int> ClimbingLeaderboard(List<int> ranked, List<int> player)
        {
            // Step 1: Remove duplicates and sort in descending order
            int[] uniqueScores = ranked.Distinct().OrderByDescending(x => x).ToArray();

            int m = player.Count;
            List<int> result = [];

            // Step 2: Binary search for each of Alice's scores
            for (int i = 0; i < m; i++)
            {
                int score = player[i];
                int low = 0, high = uniqueScores.Length - 1;

                while (low <= high)
                {
                    int mid = low + (high - low) / 2;

                    if (uniqueScores[mid] == score)
                    {
                        result.Add(mid + 1); // Found the score, return the rank (1-based)
                        break;
                    }
                    else if (uniqueScores[mid] < score)
                    {
                        high = mid - 1; // Search in the left half
                    }
                    else
                    {
                        low = mid + 1; // Search in the right half
                    }
                }

                if (low > high)
                {
                    result.Add(low + 1); // The position where the score would fit (1-based rank)
                }
            }

            return result;
        }

        // Sherlock and the Valid String
        public static string IsValid(string s)
        {
            var letters = s.Distinct().ToList();
            var charFrequency = new Dictionary<int, int>();
            foreach (var character in letters)
            {
                var count = s.Count(x => x == character);
                if (charFrequency.ContainsKey(count))
                    charFrequency[count]++;
                else
                    charFrequency[count] = 1;
            }

            if (charFrequency.Count == 1)
                return "YES";
            else if (charFrequency.Count > 2)
                return "NO";

            var freq1 = charFrequency.First().Key;
            var freq2 = charFrequency.Last().Key;

            var count1 = charFrequency.First().Value;
            var count2 = charFrequency.Last().Value;

            if (((count1 == 1 && freq1 == 1) || (count2 == 1 && freq2 == 1))
                || (count1 == 1 && freq1 - freq2 == 1) || (count2 == 1 && freq2 - freq1 == 1))
                return "YES";
            return "NO";
        }

        // New year chaos
        public static void MinimumBribes(List<int> q)
        {
            int n = q.Count;
            int bribes = 0;

            for (int i = n - 1; i >= 0; i--)
            {
                // Check if the current position is too far ahead from the original position
                var s = q[i] - (i + 1);
                if (q[i] - (i + 1) > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }

                // Check how many times the person has been bribed
                for (int j = Math.Max(0, q[i] - 2); j < i; j++)
                {
                    if (q[j] > q[i])
                    {
                        bribes++;
                    }
                }
            }

            Console.WriteLine(bribes);
        }

        // Merge two sorted linked lists
        public static SinglyLinkedListNode MergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            var node1 = head1;
            var node2 = head2;

            SinglyLinkedListNode merged;
            if (node1.Data <= node2.Data)
            {
                merged = new SinglyLinkedListNode(node1.Data);
                node1 = node1.Next;
            }
            else
            {
                merged = new SinglyLinkedListNode(node2.Data);
                node2 = node2.Next;
            }
            var current = merged;

            while (node1 != null || node2 != null)
            {
                if (node1 != null && node2 != null)
                {
                    if (node1.Data <= node2.Data)
                    {
                        current.Next = new SinglyLinkedListNode(node1.Data);
                        node1 = node1.Next;
                    }
                    else
                    {
                        current.Next = new SinglyLinkedListNode(node2.Data);
                        node2 = node2.Next;
                    }
                }
                else if (node1 != null)
                {
                    current.Next = new SinglyLinkedListNode(node1.Data);
                    node1 = node1.Next;
                }
                else
                {
                    current.Next = new SinglyLinkedListNode(node2.Data);
                    node2 = node2.Next;
                }
                current = current.Next;
            }
            return merged;
        }

        // The Bomberman Game
        public static List<string> BomberMan(int n, List<string> grid)
        {
            var bombGrid = grid.Select(x => x.ToList()).ToList();
            var filledGrid = Enumerable.Range(0, grid.Count).Select(x =>
                Enumerable.Range(0, grid[0].Length).Select(y => 'O').ToList()).ToList();

            // first second
            if (n == 0 || n == 1)
                return grid;

            // second second
            else if (n % 2 == 0)
            {
                return Enumerable.Range(0, grid.Count)
                    .Select(x => new string('O', grid[0].Length)).ToList();
            }
            else
            {
                var turn = 0;
                if (n % 4 == 3)
                    turn = 1;
                else if (n % 4 == 1)
                    turn = 2;
                while (turn > 0)
                {
                    // find bombs
                    var bombs = new Dictionary<int, List<int>>();
                    for (int i = 0; i < bombGrid.Count; i++)
                    {
                        var idx = bombGrid[i].Select((value, idx) => new { value, idx })
                            .Where(x => x.value == 'O').Select(x => x.idx).ToList();
                        if (idx.Any())
                            bombs.Add(i, idx);
                    }

                    // third second
                    var explotionGrid = Enumerable.Range(0, grid.Count).Select(x =>
                    Enumerable.Range(0, grid[0].Length).Select(y => 'O').ToList()).ToList();

                    foreach (var bomb in bombs)
                    {
                        var i = bomb.Key;
                        foreach (var j in bomb.Value)
                        {
                            if (bombGrid[i][j] == 'O')
                            {
                                explotionGrid[i][j] = '.';
                                if (j > 0)
                                    explotionGrid[i][j - 1] = '.';
                                if (j < bombGrid[i].Count - 1)
                                    explotionGrid[i][j + 1] = '.';
                                if (i > 0)
                                    explotionGrid[i - 1][j] = '.';
                                if (i < bombGrid.Count - 1)
                                    explotionGrid[i + 1][j] = '.';
                            }
                        }
                    }
                    bombGrid = new List<List<char>>(explotionGrid);
                    turn--;
                }
                var result = new List<string>();
                bombGrid.ForEach(x => result.Add(string.Concat(x)));
                return result;
            }
        }

        // Sum vs XOR
        public static long SumXor(long n)
        {
            // Count the number of zero bits in the binary representation of n
            long zeroBitsCount = 0;
            while (n > 0)
            {
                if ((n & 1) == 0)
                {
                    zeroBitsCount++;
                }
                n >>= 1; // Right-shift n by 1 to process the next bit
            }

            // The number of valid x values is 2^zeroBitsCount
            return (long)Math.Pow(2, zeroBitsCount);
        }

        // Recursive Digit Sum
        public static int SuperDigit(string n, int k)
        {
            int sum = 0;
            long total = n.Select(x => int.Parse(x.ToString())).Sum();
            total *= k;

            if (total < 10)
                return (int)total;

            n = total.ToString();
            while (n.Length > 1)
            {
                sum = n.Select(x => int.Parse(x.ToString())).Sum();
                n = sum.ToString();
            }
            return sum;
        }

        // Dynamic Array
        public static List<int> DynamicArray(int n, List<List<int>> queries)
        {
            var lastAnswer = 0;
            var answers = new List<int>();
            var arr = Enumerable.Range(0, n)
                .Select(x => new List<int> { }).ToList();
            foreach (var q in queries)
            {
                var idx = (q[1] ^ lastAnswer) % n;
                // query type 1
                if (q[0] == 1)
                    arr[idx].Add(q[2]);

                // query type 2
                else if (q[0] == 2)
                {
                    lastAnswer = arr[idx][q[2] % arr[idx].Count];
                    answers.Add(lastAnswer);
                }
            }
            return answers;
        }

        // Sherlock and Array
        public static string BalancedSums(List<int> arr)
        {
            var left = 0;
            var right = arr.Sum();
            if (left == right)
                return "YES";
            for (int i = 0; i < arr.Count; i++)
            {
                if (i > 0)
                    left += arr[i - 1];
                right -= arr[i];
                if (left == right)
                    return "YES";
            }
            return "NO";
        }

        // Counter Game
        public static string CounterGame(long n)
        {
            var turn = 0;
            while (n > 1)
            {
                if ((n & (n - 1)) == 0)
                {
                    turn += Convert.ToInt32(Math.Log2(n));
                    break;
                }
                n -= Convert.ToInt64(Math.Pow(2, Convert.ToInt32(Math.Floor(Math.Log2(n)))));
                turn++;
            }

            if (turn % 2 == 0)
                return "Richard";
            return "Louise";
        }

        // Grid Challenge
        public static string GridChallenge(List<string> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                grid[i] = string.Concat(grid[i].Order());
            }

            for (int col = 0; col < grid[0].Length; col++)
            {
                var reversed = string.Empty;
                for (int row = 0; row < grid.Count; row++)
                {
                    reversed += grid[row][col];
                }
                var orderdReversed = string.Concat(reversed.Order());
                if (reversed != orderdReversed)
                    return "NO";
            }
            return "YES";
        }

        // Insert Node At Position in LinkedList
        public static SinglyLinkedListNode InsertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
        {
            var currentNode = llist;
            var index = 0;
            while (currentNode.Next != null)
            {
                if (position == index + 1)
                {
                    var node = new SinglyLinkedListNode(data) { Next = currentNode.Next };
                    currentNode.Next = node;
                    break;
                }
                index++;
                currentNode = currentNode.Next;
            }
            return llist;
        }

        // Reverse a doubly linked list
        public static DoublyLinkedListNode Reverse(DoublyLinkedListNode llist)
        {
            DoublyLinkedListNode node = llist;
            DoublyLinkedListNode reversed = new(node.Data);
            while (node.Next != null)
            {
                var prev = reversed;
                reversed = new DoublyLinkedListNode(node.Next.Data) { Next = prev };
                reversed.Next.Prev = reversed;
                node = node.Next;
            }
            return reversed;
        }

        // Balanced Brackets use of stack
        public static string IsBalanced(string s)
        {
            Dictionary<char, char> brackets = new() { { '{', '}' }, { '(', ')' }, { '[', ']' } };
            Stack<char> stack = new();
            foreach (var c in s)
            {
                if (brackets.ContainsKey(c))
                    stack.Push(c);
                else if (brackets.ContainsValue(c))
                {
                    stack.TryPop(out char pop);
                    var key = brackets.FirstOrDefault(x => x.Value == c).Key;
                    if (pop != key)
                        return "NO";
                }
            }
            if (stack.Count > 0)
                return "NO";
            return "YES";
        }

        // Balanced Brackets
        public static string IsBalanced_2(string s)
        {
            Dictionary<string, string> brackets = new() { { "{", "}" }, { "(", ")" }, { "[", "]" } };
            Dictionary<char, List<int>> places = [];
            foreach (var c in s)
            {
                var i = s.IndexOf(c);
                if (places.ContainsKey(c))
                    places[c].Add(i);
                else
                    places[c] = [i];
            }

            foreach (var sign in brackets)
            {
                var open = places[char.Parse(sign.Key)];
                var close = places[char.Parse(sign.Value)];
                if (open.Count != close.Count)
                    return "NO";
                for (int i = 0; i < open.Count; i++)
                {
                    if (open[i] > close[i] ||
                        (open[i] - close[i] - 1) % 2 != 0)
                        return "NO";
                }
            }
            return "YES";
        }

        // Icecream Parlor
        public static List<int> IcecreamParlor(int m, List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] > m)
                    continue;
                var remainder = m - arr[i];
                var j = arr.Select((value, index) => new { value, index })
                    .FirstOrDefault(x => x.index != i && x.value == remainder)?.index ?? 0;
                if (j > 0)
                    return [i + 1, j + 1];
            }
            return [];
        }

        // Waiter
        public static List<int> Waiter(List<int> number, int q)
        {
            var primes = new List<int>();
            var num = 2;
            while (primes.Count < q)
            {
                var flag = false;
                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                        flag = true;
                }
                if (!flag)
                    primes.Add(num);
                num++;
            }

            var answers = new List<int>();
            for (int i = 1; i <= q; i++)
            {
                var prime = primes[i - 1];
                var A = new List<int>();
                var B = new List<int>();
                while (number.Count != 0)
                {
                    var plate = number[number.Count - 1];
                    if (plate % prime == 0)
                        B.Add(plate);
                    else
                        A.Add(plate);
                    number.RemoveAt(number.Count - 1);
                }
                number = A;
                B.Reverse();
                answers.AddRange(B);
            }
            if (number.Count != 0)
            {
                number.Reverse();
                answers.AddRange(number);
            }
            return answers;
        }

        // Reverse a linked list
        public static SinglyLinkedListNode ReverseWithExtraList(SinglyLinkedListNode llist)
        {
            SinglyLinkedListNode node = llist;
            var reversed = new SinglyLinkedListNode(node.Data);
            while (node.Next != null)
            {
                var current = new SinglyLinkedListNode(node.Next.Data);
                current.Next = reversed;
                reversed = current;
                node = node.Next;
            }
            return reversed;
        }

        // Reverse a linked list
        public static SinglyLinkedListNode Reverse(SinglyLinkedListNode llist)
        {
            if (llist is null || llist.Next is null)
                return llist;
            var current = llist.Next;
            var prev = llist;
            prev.Next = null;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        // Find Kth Node
        public static SinglyLinkedListNode FindKthNode(SinglyLinkedListNode llist, int k)
        {
            if (llist is null || llist.Next is null)
                return k == 1 ? llist : null;

            var prev = llist;
            var next = llist;
            for (int i = 0; i < k; i++)
            {
                next = next.Next;
            }
            while (next.Next != null)
            {
                next = next.Next;
                prev = prev.Next;
            }
            return prev;
        }

        // Caesar Cipher 
        public static string CaesarCipher(string s, int k)
        {
            var alphabets = "abcdefghijklmnopqrstuvwxyz";
            var result = "";
            foreach (char c in s)
            {
                if (char.IsLetter(c))
                {
                    var index = alphabets.IndexOf(char.ToLower(c));
                    char cipher = alphabets[(index + k) % 26];
                    if (char.IsUpper(c))
                        cipher = char.ToUpper(cipher);
                    result += cipher;
                }
                else
                    result += c;
            }
            return result;
        }

        // Tower Breakers
        public static int TowerBreakers(int n, int m)
        {
            if (m == 1 || n % 2 == 0)
                return 2;
            return 1;
        }

        //  
        public static int PageCount(int n, int p)
        {
            if (n % 2 == 0) n += 1;
            var mid = n / 2;
            var pointer = 0;
            var turn = 0;
            if (p > mid)
            {
                // open from last page
                pointer = n;
                while (pointer >= mid)
                {
                    if (p >= pointer - 1 && p <= pointer)
                        return turn;
                    turn++;
                    pointer -= 2;
                }
            }
            else
            {
                // open from first page
                while (pointer <= mid)
                {
                    if (p >= pointer && p <= pointer + 1)
                        return turn;
                    turn++;
                    pointer += 2;
                }
            }
            return turn;
        }

        // Zig Zag Sequence
        public static void FindZigZagSequence(List<int> a, int n)
        {
            var sorted = a.Order().ToList();
            var mid = ((n + 1) / 2) - 1;
            var end = n - 1;
            while (mid < end)
            {
                (sorted[end], sorted[mid]) = (sorted[mid], sorted[end]);
                mid++;
                end--;
            }
        }

        // Sales by Match
        public static int SockMerchant(int n, List<int> ar)
        {
            var pairs = 0;
            var distinct = ar.Distinct().ToList();
            foreach (var item in distinct)
            {
                pairs += ar.Count(x => x == item) / 2;
            }
            return pairs;
        }

        // Max Min
        public static int MaxMin(int k, List<int> arr)
        {

            var ordered = arr.Order().ToArray();
            int? min = null;
            for (int start = 0, end = k - 1; end < ordered.Length && end - start == k - 1; start++, end++)
            {
                var result = ordered[end] - ordered[start];
                if (!min.HasValue || min > result)
                    min = result;
            }
            return min.Value;
        }

        // Subarray Division 1
        public static int Birthday(List<int> s, int d, int m)
        {
            var size = s.Count;
            var count = 0;
            for (int i = 0; i < size; i++)
            {
                if (size - i < m)
                    break;
                if (s.GetRange(i, m).Sum() == d)
                    count++;
            }
            return count;
        }

        // Permuting Two Arrays
        public static string TwoArrays(int k, List<int> A, List<int> B)
        {
            var A2 = A.Order().ToArray();
            var B2 = B.OrderDescending().ToArray();
            for (int i = 0; i < A.Count; i++)
            {
                if (A2[i] + B2[i] < k)
                    return "NO";
            }
            return "YES";
        }

        // Pangrams
        public static string Pangrams(string s)
        {
            var result = Regex.Matches(s.ToLower(), @"[a-z]");
            var count = result.Select(x => x.Value).Distinct().Count();
            if (count == 26)
                return "pangram";
            return "not pangram";
        }

        // Counting Sort 1
        public static List<int> CountingSort(List<int> arr)
        {
            var sorted = new List<int>();
            var result = new int[100];
            foreach (var item in arr)
            {
                result[item]++;
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0)
                    continue;
                sorted.AddRange(Enumerable.Repeat(i, result[i]).ToList());
            }
            return [.. result];
        }

        // Diagonal Difference
        public static int DiagonalDifference(List<List<int>> arr)
        {
            var n = arr.Count;
            var mainDiagonal = arr.Select((x, y) => x[y]).Sum();
            var secondDiagonal = arr.Select((x, y) => x[n - y - 1]).Sum();
            return Math.Abs(mainDiagonal - secondDiagonal);
        }

        // Flipping Bits
        public static long FlippingBits(long n)
        {
            string binary = Convert.ToString(n, 2).PadLeft(32, '0');
            var binaryArray = binary.ToCharArray();
            var strResult = "";
            foreach (char c in binaryArray)
            {
                strResult += c == '0' ? "1" : "0";
            }
            return Convert.ToInt64(strResult, 2);
        }

        // Sparse Arrays
        public static List<int> MatchingStrings(List<string> strings, List<string> queries)
        {
            var result = new List<int>();
            foreach (var query in queries)
            {
                result.Add(strings.Count(x => x == query));
            }
            return result;
        }

        // Lonely Integer
        public static int Lonelyinteger(List<int> a)
        {
            var counts = new Dictionary<int, int>();
            var distinct = a.Distinct();
            foreach (var item in distinct)
            {
                counts[item] = a.Count(x => x == item);
            }
            return counts.First(x => x.Value == 1).Key; ;
        }

        // Time Conversion
        public static string TimeConversion(string s)
        {
            DateTime time = DateTime.Parse(s);
            return time.ToString("HH:mm:ss");
        }

        //Plus Minus
        public static void PlusMinus(List<int> arr)
        {
            var size = arr.Count;
            var negatives = arr.Count(x => x < 0);
            var positives = arr.Count(x => x > 0);
            var zeros = arr.Count(x => x == 0);

            var counts = new List<int> { positives, negatives, zeros }.OrderDescending();

            foreach (var item in counts)
            {
                Console.WriteLine((item / (decimal)size).ToString("N6"));
            }
        }

        // Mini-Max Sum
        public static void MiniMaxSum(List<int> arr)
        {
            arr = arr.OrderBy(x => x).ToList();
            var min = arr.Take(4);
            var max = arr.TakeLast(4).ToList();
            long minSum = 0;
            long maxSum = 0;
            foreach (var item in max)
            {
                maxSum += item;
            }
            foreach (var item in min)
            {
                minSum += item;
            }
            Console.WriteLine($"{minSum} {maxSum}");
        }
    }
}
