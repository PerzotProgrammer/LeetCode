namespace LargestGoodInteger;


class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: num = "6777133339"
        // Output: "777"
        // Explanation: There are two distinct good integers: "777" and "333".
        // "777" is the largest, so we return "777".
        //     Example 2:
        //
        // Input: num = "2300019"
        // Output: "000"
        // Explanation: "000" is the only good integer.
        //     Example 3:
        //
        // Input: num = "42352338"
        // Output: ""
        // Explanation: No substring of length 3 consists of only one unique digit. Therefore, there are no good integers.

        string n1 = "6777133339";
        string n2 = "2300019";
        string n3 = "42352338";
        string n4 = "222";
        string n5 = "232220002";
        
        Solution solution = new();

        Console.WriteLine(solution.LargestGoodInteger(n1));
        Console.WriteLine(solution.LargestGoodInteger(n2));
        Console.WriteLine(solution.LargestGoodInteger(n3));
        Console.WriteLine(solution.LargestGoodInteger(n4));
        Console.WriteLine(solution.LargestGoodInteger(n5));
    }

    public string LargestGoodInteger(string num)
    {
        string strOut = "0";
        bool flag = false;
        for (int i = 0; i <= num.Length - 3; i++)
        {
            string temp = num.Substring(i, 3);
            if (Convert.ToInt32(temp) > Convert.ToInt32(strOut) && temp[0] == temp[1] && temp[1] == temp[2]) strOut = temp;
            if (temp == "000") flag = true;
        }
    
        if (strOut == "0" && flag) return "000";
        if (strOut == "0") return "";
        return strOut;
    }
}