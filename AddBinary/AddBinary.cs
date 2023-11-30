namespace AddBinary;


class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: a = "11", b = "1"
        // Output: "100"
        // Example 2:
        //
        // Input: a = "1010", b = "1011"
        // Output: "10101"

        string a1 = "11";
        string b1 = "1";

        string a2 = "1010";
        string b2 = "1011";

        Solution solution = new();

        Console.WriteLine(solution.AddBinary(a1, b1));
        Console.WriteLine(solution.AddBinary(a2, b2));

    }

    public string AddBinary(string a, string b)
    {
        bool flag = false;
        string output = "";
        
        // IF wzięty z internetu
        if (a.Length > b.Length) {
            b = new String('0', Math.Abs(a.Length - b.Length)) + b;
        }
        else {
            a = new String('0', Math.Abs(a.Length - b.Length)) + a;
        }

        for (int i = a.Length - 1; i >= 0; i--)
        {
            int sum = 0;
            if (a[i] == '1') sum += 1;
            if (b[i] == '1') sum += 1;
            if (flag) sum += 1;

            char add = sum % 2 == 0 ? '0' : '1';
            
            output = add + output;
            flag = sum >= 2;
        }

        if (flag) return '1' + output;
        return output;
    }
}