namespace NumTeams;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: rating = [2,5,3,4,1]
        // Output: 3
        // Explanation: We can form three teams given the conditions. (2,3,4), (5,4,1), (5,3,1). 

        // Example 2:
        //
        // Input: rating = [2,1,3]
        // Output: 0
        // Explanation: We can't form any team given the conditions.

        // Example 3:
        //
        // Input: rating = [1,2,3,4]
        // Output: 4


        Solution solution = new();

        Console.WriteLine(solution.NumTeams([2, 5, 3, 4, 1]));
        Console.WriteLine(solution.NumTeams([2, 1, 3]));
        Console.WriteLine(solution.NumTeams([1, 2, 3, 4]));
    }

    public int NumTeams(int[] rating)
    {
        int count = 0;

        for (int j = 0; j < rating.Length; j++)
        {
            int leftLess = 0;
            int leftGreater = 0;
            int rightLess = 0;
            int rightGreater = 0;

            for (int i = 0; i < j; i++)
            {
                if (rating[i] < rating[j]) leftLess++;
                else if (rating[i] > rating[j]) leftGreater++;
            }

            for (int k = j + 1; k < rating.Length; k++)
            {
                if (rating[k] < rating[j]) rightLess++;
                else if (rating[k] > rating[j]) rightGreater++;
            }

            count += leftLess * rightGreater;
            count += leftGreater * rightLess;
        }

        return count;
    }
}