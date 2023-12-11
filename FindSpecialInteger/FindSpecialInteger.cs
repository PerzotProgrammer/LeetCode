namespace FindSpecialInteger;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: arr = [1,2,2,6,6,6,6,7,10]
        // Output: 6
        
        // Example 2:
        //
        // Input: arr = [1,1]
        // Output: 1

        int[] a1 = { 1, 2, 2, 6, 6, 6, 6, 7, 10 };
        int[] a2 = { 1, 1 };
        int[] a3 = { 1, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 12, 12, 12 };

        Solution solution = new();

        Console.WriteLine(solution.FindSpecialInteger(a1));
        Console.WriteLine(solution.FindSpecialInteger(a2));
        Console.WriteLine(solution.FindSpecialInteger(a3));
    }

    public int FindSpecialInteger(int[] arr)
    {
        if (arr.Length == 1) return arr[0];

        int occurences = 0;
        int specialInt = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            int currOccurences = 0;
            
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                {
                    currOccurences++;
                }    
            }

            if (currOccurences > occurences)
            {
                occurences = currOccurences;
                specialInt = arr[i];
            }
        }

        return specialInt;
    }
}