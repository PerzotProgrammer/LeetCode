namespace Exist;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/word-search/solutions/4965365/c-solution-for-word-search-problem/?envType=daily-question&envId=2024-04-03

        // Example 1:
        //
        // Input: board = [['A','B','C','E'],['S','F','C','S'],['A','D','E','E']], word = 'ABCCED'
        // Output: true

        // Example 2:
        //
        // Input: board = [['A','B','C','E'],['S','F','C','S'],['A','D','E','E']], word = 'SEE'
        // Output: true

        // Example 3:
        //
        // Input: board = [['A','B','C','E'],['S','F','C','S'],['A','D','E','E']], word = 'ABCB'
        // Output: false

        Solution solution = new();

        Console.WriteLine(solution.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "ABCCED"));
        Console.WriteLine(solution.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "SEE"));
        Console.WriteLine(solution.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "ABCB"));
    }

    public bool Exist(char[][] board, string word)
    {
        if (board == null || board.Length == 0 || string.IsNullOrEmpty(word)) return false;

        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[0].Length; col++)
            {
                if (DFS(board, word, row, col, 0)) return true;
            }
        }

        return false;
    }

    private bool DFS(char[][] board, string word, int row, int col, int index)
    {
        if (index == word.Length) return true;

        if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length ||
            board[row][col] != word[index]) return false;

        char temp = board[row][col];
        board[row][col] = '#';

        bool found = DFS(board, word, row + 1, col, index + 1) ||
                     DFS(board, word, row - 1, col, index + 1) ||
                     DFS(board, word, row, col + 1, index + 1) ||
                     DFS(board, word, row, col - 1, index + 1);

        board[row][col] = temp;
        return found;
    }
}