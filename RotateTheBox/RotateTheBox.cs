namespace RotateTheBox;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: box = [["#",".","#"]]
        // Output: [["."],
        // ["#"],
        // ["#"]]

        // Example 2:
        //
        // Input: box = [["#",".","*","."],
        // ["#","#","*","."]]
        // Output: [["#","."],
        // ["#","#"],
        // ["*","*"],
        // [".","."]]

        // Example 3:
        //
        // Input: box = [["#","#","*",".","*","."],
        // ["#","#","#","*",".","."],
        // ["#","#","#",".","#","."]]
        // Output: [[".","#","#"],
        // [".","#","#"],
        // ["#","#","*"],
        // ["#","*","."],
        // ["#",".","*"],
        // ["#",".","."]]


        Solution solution = new();

        PrintMatrix(solution.RotateTheBox([['#', '.', '#']]));
        PrintMatrix(solution.RotateTheBox([['#', '.', '*', '.'], ['#', '#', '*', '.']]));
        PrintMatrix(solution.RotateTheBox([
            ['#', '#', '*', '.', '*', '.'], ['#', '#', '#', '*', '.', '.'], ['#', '#', '#', '.', '#', '.']
        ]));
    }

    public char[][] RotateTheBox(char[][] box)
    {
        foreach (char[] chars in box)
        {
            int emptyIndex = box[0].Length - 1;
            for (int j = box[0].Length - 1; j >= 0; j--)
            {
                if (chars[j] == '*') emptyIndex = j - 1;
                else if (chars[j] == '#')
                {
                    chars[j] = '.';
                    chars[emptyIndex] = '#';
                    emptyIndex--;
                }
            }
        }

        char[][] rotatedBox = new char[box[0].Length][];
        for (int i = 0; i < box[0].Length; i++) rotatedBox[i] = new char[box.Length];

        for (int i = 0; i < box.Length; i++)
        {
            for (int j = 0; j < box[0].Length; j++) rotatedBox[j][box.Length - i - 1] = box[i][j];
        }

        return rotatedBox;
    }

    static void PrintMatrix(char[][] matrix)
    {
        foreach (char[] chars in matrix)
        {
            foreach (char c in chars) Console.Write($"{c}, ");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}