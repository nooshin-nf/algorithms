namespace Algorithms
{
    public class CanBeIncreasing
    {
        public static bool Execute(int[] nums)
        {
            var firstRemoved = false;
            int idx = 1;
            while (idx < nums.Length)
            {
                if (nums[idx - 1] >= nums[idx])
                    if (firstRemoved)
                        return false;
                    else
                    {
                        firstRemoved = true;
                        if (idx > 1 && nums[idx] < nums[idx - 2])
                            nums[idx] = nums[idx - 1];

                    }
                idx++;
            }
            return true;
        }
    }
}
