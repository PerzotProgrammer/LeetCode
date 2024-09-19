namespace DiffWaysToCompute;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: expression = "2-1-1"
        // Output: [0,2]
        // Explanation:
        // ((2-1)-1) = 0 
        // (2-(1-1)) = 2

        // Example 2:
        //
        // Input: expression = "2*3-4*5"
        // Output: [-34,-14,-10,-10,10]
        // Explanation:
        // (2*(3-(4*5))) = -34 
        // ((2*3)-(4*5)) = -14 
        // ((2*(3-4))*5) = -10 
        // (2*((3-4)*5)) = -10 
        // (((2*3)-4)*5) = 10


        Solution solution = new();

        PrintList(solution.DiffWaysToCompute("2-1-1"));
        PrintList(solution.DiffWaysToCompute("2*3-4*5"));
    }

    public List<int> DiffWaysToCompute(String expression)
    {
        List<int> results = new();

        if (expression.Length == 0) return results;

        if (expression.Length == 1)
        {
            results.Add(int.Parse(expression));
            return results;
        }

        if (expression.Length == 2 && char.IsDigit(expression[0]))
        {
            results.Add(int.Parse(expression));
            return results;
        }

        for (int i = 0; i < expression.Length; i++)
        {
            char currentChar = expression[i];
            if (char.IsDigit(currentChar)) continue;


            List<int> leftResults = DiffWaysToCompute(expression.Substring(0, i));
            List<int> rightResults = DiffWaysToCompute(expression.Substring(i + 1));

            foreach (int leftValue in leftResults)
            {
                foreach (int rightValue in rightResults)
                {
                    int computedResult = 0;

                    switch (currentChar)
                    {
                        case '+':
                            computedResult = leftValue + rightValue;
                            break;
                        case '-':
                            computedResult = leftValue - rightValue;
                            break;
                        case '*':
                            computedResult = leftValue * rightValue;
                            break;
                    }

                    results.Add(computedResult);
                }
            }
        }

        return results;
    }

    static void PrintList(List<int> list)
    {
        foreach (int i in list) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}