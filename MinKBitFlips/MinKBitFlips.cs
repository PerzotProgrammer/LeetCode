namespace MinKBitFlips;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [0,1,0], k = 1
        // Output: 2
        // Explanation: Flip nums[0], then flip nums[2].

        // Example 2:
        //
        // Input: nums = [1,1,0], k = 2
        // Output: -1
        // Explanation: No matter how we flip subarrays of size 2, we cannot make the array become [1,1,1].

        // Example 3:
        //
        // Input: nums = [0,0,0,1,0,1,1,0], k = 3
        // Output: 3
        // Explanation: 
        // Flip nums[0],nums[1],nums[2]: nums becomes [1,1,1,1,0,1,1,0]
        // Flip nums[4],nums[5],nums[6]: nums becomes [1,1,1,1,1,0,0,0]
        // Flip nums[5],nums[6],nums[7]: nums becomes [1,1,1,1,1,1,1,1]


        Solution solution = new();

        Console.WriteLine(solution.MinKBitFlips([0, 1, 0], 1));
        Console.WriteLine(solution.MinKBitFlips([1, 1, 0], 2));
        Console.WriteLine(solution.MinKBitFlips([0, 0, 0, 1, 0, 1, 1, 0], 3));
    }

    public int MinKBitFlips(int[] nums, int k)
    {
        Queue<int> endpoints = new();
        int flipCount = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (endpoints.Count > 0 && endpoints.Peek() <= i) endpoints.Dequeue();

            int n = (nums[i] + endpoints.Count) % 2;
            if (n == 0)
            {
                if (i <= nums.Length - k)
                {
                    endpoints.Enqueue(i + k);
                    flipCount++;
                }
                else return -1;
            }
        }

        return flipCount;
    }
}