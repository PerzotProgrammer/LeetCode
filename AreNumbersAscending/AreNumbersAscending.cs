namespace AreNumbersAscending;

class Solution
{
    static void Main()
    {
        
        // Niezabardzo z tymi wymaganiami :/
        
        string s1 = "mam 266 jaja i 666 dzieci i 3566 kur 666666";

        Solution solution = new();

        Console.WriteLine(solution.AreNumbersAscending(s1));

    }

    public bool AreNumbersAscending(string s)
    {

        int thisNum;
        int prevNum = 0;
        string temp = "";
        bool checkFlag = false;
        for (int i = 0; i < s.Length; i++)
        {
            while (char.IsDigit(s[i]))
            {
                temp += s[i];
                checkFlag = true;
                i++;
                if (i == s.Length) break;
            }
            
            if (checkFlag)
            {
                thisNum = int.Parse(temp);
                if (prevNum >= thisNum) return false;
                prevNum = thisNum;
                temp = "";
                checkFlag = false;
            }
        }
        return true;
    }
}