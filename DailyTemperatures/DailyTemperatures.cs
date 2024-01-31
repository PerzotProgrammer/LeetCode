namespace DailyTemperatures;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: temperatures = [73,74,75,71,69,72,76,73]
        // Output: [1,1,4,2,1,1,0,0]

        // Example 2:
        //
        // Input: temperatures = [30,40,50,60]
        // Output: [1,1,1,0]

        // Example 3:
        //
        // Input: temperatures = [30,60,90]
        // Output: [1,1,0]

        Solution solution = new();

        int[] a1 = solution.DailyTemperatures([73, 74, 75, 71, 69, 72, 76, 73]);
        int[] a2 = solution.DailyTemperatures([30, 40, 50, 60]);
        int[] a3 = solution.DailyTemperatures([30, 60, 90]);

        PrintArray(a1);
        PrintArray(a2);
        PrintArray(a3);
    }

    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] output = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; i++)
        {
            int currentTemp = temperatures[i];
            int currentDays = 0;
            bool flag = false;
            for (int j = i + 1; j < temperatures.Length; j++)
            {
                currentDays++;
                if (currentTemp < temperatures[j])
                {
                    flag = true;
                    break;
                }
            }

            if (flag) output[i] = currentDays;
            else output[i] = 0;
        }

        return output;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}