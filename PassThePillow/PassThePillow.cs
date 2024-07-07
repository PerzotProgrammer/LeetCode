namespace PassThePillow;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 4, time = 5
        // Output: 2
        // Explanation: People pass the pillow in the following way: 1 -> 2 -> 3 -> 4 -> 3 -> 2.
        // After five seconds, the 2nd person is holding the pillow.

        // Example 2:
        //
        // Input: n = 3, time = 2
        // Output: 3
        // Explanation: People pass the pillow in the following way: 1 -> 2 -> 3.
        // After two seconds, the 3rd person is holding the pillow.


        Solution solution = new();

        Console.WriteLine(solution.PassThePillow(4, 5));
        Console.WriteLine(solution.PassThePillow(3, 2));
    }

    public int PassThePillow(int n, int time)
    {
        int position = 1;
        bool forward = true;

        for (int t = 0; t < time; t++)
        {
            if (forward)
            {
                if (position == n)
                {
                    forward = false;
                    position--;
                }
                else position++;
            }
            else
            {
                if (position == 1)
                {
                    forward = true;
                    position++;
                }
                else position--;
            }
        }

        return position;
    }
}