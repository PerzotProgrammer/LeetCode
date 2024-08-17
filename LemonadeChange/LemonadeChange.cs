namespace LemonadeChange;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: bills = [5,5,5,10,20]
        // Output: true
        // Explanation: 
        // From the first 3 customers, we collect three $5 bills in order.
        // From the fourth customer, we collect a $10 bill and give back a $5.
        // From the fifth customer, we give a $10 bill and a $5 bill.
        // Since all customers got correct change, we output true.

        // Example 2:
        //
        // Input: bills = [5,5,10,10,20]
        // Output: false
        // Explanation: 
        // From the first two customers in order, we collect two $5 bills.
        // For the next two customers in order, we collect a $10 bill and give back a $5 bill.
        // For the last customer, we can not give the change of $15 back because we only have two $10 bills.
        // Since not every customer received the correct change, the answer is false.}


        Solution solution = new();

        Console.WriteLine(solution.LemonadeChange([5, 5, 5, 10, 20]));
        Console.WriteLine(solution.LemonadeChange([5, 5, 10, 10, 20]));
    }

    public bool LemonadeChange(int[] bills)
    {
        Dictionary<int, int> billCount = new()
        {
            { 5, 0 },
            { 10, 0 }
        };

        foreach (int bill in bills)
        {
            if (bill == 5) billCount[5]++;
            else if (bill == 10)
            {
                if (billCount[5] > 0)
                {
                    billCount[5]--;
                    billCount[10]++;
                }
                else return false;
            }
            else if (bill == 20)
            {
                if (billCount[10] > 0 && billCount[5] > 0)
                {
                    billCount[10]--;
                    billCount[5]--;
                }
                else if (billCount[5] >= 3) billCount[5] -= 3;
                else return false;
            }
        }

        return true;
    }
}