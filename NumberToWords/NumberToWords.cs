namespace NumberToWords;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: num = 123
        // Output: "One Hundred Twenty Three"

        // Example 2:
        //
        // Input: num = 12345
        // Output: "Twelve Thousand Three Hundred Forty Five"

        // Example 3:
        //
        // Input: num = 1234567
        // Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"


        Solution solution = new();

        Console.WriteLine(solution.NumberToWords(123));
        Console.WriteLine(solution.NumberToWords(12345));
        Console.WriteLine(solution.NumberToWords(1234567));
    }

    public string NumberToWords(int num)
    {
        if (num == 0) return "Zero";

        string[] ones =
        {
            "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve",
            "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };
        string[] tens =
        {
            "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };
        string[] thousands = { "", "Thousand", "Million", "Billion" };

        string output = "";
        int groupIndex = 0;

        while (num > 0)
        {
            if (num % 1000 != 0)
            {
                string groupOutput = "";
                int part = num % 1000;

                if (part >= 100)
                {
                    groupOutput += $"{ones[part / 100]} Hundred ";
                    part %= 100;
                }

                if (part >= 20)
                {
                    groupOutput += $"{tens[part / 10]} ";
                    part %= 10;
                }

                if (part > 0)
                {
                    groupOutput += $"{ones[part]} ";
                }

                groupOutput += $"{thousands[groupIndex]} ";
                output = groupOutput + output;
            }

            num /= 1000;
            groupIndex++;
        }

        return output.Trim();
    }
}