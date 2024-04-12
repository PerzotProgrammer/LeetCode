namespace Trap;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
        // Output: 6
        // Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.

        // Example 2:
        //
        // Input: height = [4,2,0,3,2,5]
        // Output: 9

        Solution solution = new();

        Console.WriteLine(solution.Trap([0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]));
        Console.WriteLine(solution.Trap([4, 2, 0, 3, 2, 5]));
    }

    public int Trap(int[] height)
    {
        if (height.Length == 0) return 0;

        int left = 0;
        int right = height.Length - 1;
        int leftMax = 0;
        int rightMax = 0;
        int output = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] >= leftMax) leftMax = height[left];
                else output += leftMax - height[left];
                left++;
            }
            else
            {
                if (height[right] >= rightMax) rightMax = height[right];
                else output += rightMax - height[right];
                right--;
            }
        }

        return output;
    }
}