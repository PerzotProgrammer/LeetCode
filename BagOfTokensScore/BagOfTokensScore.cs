namespace BagOfTokensScore;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: tokens = [100], power = 50
        //
        // Output: 0
        //
        // Explanation: Since your score is 0 initially, you cannot play the token face-down. You also cannot play it face-up since your power (50) is less than tokens[0] (100).
        //

        // Example 2:
        //
        // Input: tokens = [200,100], power = 150
        //
        // Output: 1
        //
        // Explanation: Play token1 (100) face-up, reducing your power to 50 and increasing your score to 1.
        //
        // There is no need to play token0, since you cannot play it face-up to add to your score. The maximum score achievable is 1.
        //

        // Example 3:
        //
        // Input: tokens = [100,200,300,400], power = 200
        //
        // Output: 2
        //
        // Explanation: Play the tokens in this order to get a score of 2:
        //
        // Play token0 (100) face-up, reducing power to 100 and increasing score to 1.
        // Play token3 (400) face-down, increasing power to 500 and reducing score to 0.
        // Play token1 (200) face-up, reducing power to 300 and increasing score to 1.
        // Play token2 (300) face-up, reducing power to 0 and increasing score to 2.
        // The maximum score achievable is 2.

        Solution solution = new();

        Console.WriteLine(solution.BagOfTokensScore([100], 50));
        Console.WriteLine(solution.BagOfTokensScore([200, 100], 150));
        Console.WriteLine(solution.BagOfTokensScore([100, 200, 300, 400], 200));
    }

    public int BagOfTokensScore(int[] tokens, int power)
    {
        Array.Sort(tokens);
        int maxScore = 0;
        int currScore = 0;
        int left = 0;
        int right = tokens.Length - 1;

        while (left <= right)
        {
            if (power >= tokens[left])
            {
                power -= tokens[left];
                left++;
                currScore++;
                maxScore = Math.Max(maxScore, currScore);
            }
            else if (currScore > 0)
            {
                power += tokens[right];
                right--;
                currScore--;
            }
            else break;
        }

        return maxScore;
    }
}