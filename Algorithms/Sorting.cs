namespace Algorithms
{
    // different sorting algorithm
    public class Sorting
    {
        public int MyProperty { get; set; }
        public static int[] BubbleSort(int[] list)
        {
            for (int j = list.Length; j > 1; j--)
            {
                bool isSorted = true;
                for (int i = 1; i < j; i++)
                {
                    if (list[i - 1] > list[i])
                    {
                        (list[i - 1], list[i]) = (list[i], list[i - 1]);
                        isSorted = false;
                    }
                }
                if (isSorted)
                    return list;
            }
            return list;
        }

        public static int[] SelectionSort(int[] list)
        {
            for (int j = 0; j < list.Length; j++)
            {
                int minIndex = j;
                for (int i = j; i < list.Length; i++)
                {
                    if (list[i] < list[minIndex])
                        minIndex = i;
                }
                (list[j], list[minIndex]) = (list[minIndex], list[j]);
            }
            return list;
        }

        public static int[] InsertionSort(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                var current = list[i];
                var j = i - 1;
                while (j >= 0 && list[j] > current)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = current;
            }
            return list;
        }

        public static int[] MergeSort(int[] list)
        {
            if (list.Length < 2)
                return list;

            var middle = list.Length / 2;
            var left = list[0..middle];
            var right = list[middle..list.Length];

            MergeSort(left);
            MergeSort(right);

            Merge(left, right, list);

            return list;
        }

        private static int[] Merge(int[] left, int[] right, int[] result)
        {
            int i = 0;
            int j = 0;
            int K = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                    result[K++] = left[i++];
                else
                    result[K++] = right[j++];
            }
            while (i < left.Length)
            {
                result[K++] = left[i++];
            }
            while (j < right.Length)
            {
                result[K++] = right[j++];
            }
            return result;
        }

        public static int[] QuickSort(int[] list, int start, int end)
        {
            if (start >= end)
                return list;

            var boundary = Partitioning(list, start, end);

            QuickSort(list, start, boundary - 1);
            QuickSort(list, boundary + 1, end);

            return list;
        }

        private static int Partitioning(int[] list, int start, int end)
        {
            var pivot = list[end];
            var boundary = start - 1;
            for (int i = start; i <= end; i++)
            {
                if (list[i] <= pivot)
                {
                    boundary++;
                    (list[i], list[boundary]) = (list[boundary], list[i]);
                }
            }
            return boundary;
        }


        public static int[] BucketSort(int[] list)
        {
            return list;
        }
        public static int[] CountingSort(int[] list)
        {
            return list;
        }
    }
}
