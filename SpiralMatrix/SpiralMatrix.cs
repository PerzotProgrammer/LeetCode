namespace SpiralMatrix;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: m = 3, n = 5, head = [3,0,2,6,8,1,7,9,4,2,5,5,0]
        // Output: [[3,0,2,6,8],[5,0,-1,-1,1],[5,2,4,9,7]]
        // Explanation: The diagram above shows how the values are printed in the matrix.
        // Note that the remaining spaces in the matrix are filled with -1.

        // Example 2:
        //
        // Input: m = 1, n = 4, head = [0,1,2]
        // Output: [[0,1,2,-1]]
        // Explanation: The diagram above shows how the values are printed from left to right in the matrix.
        // The last space in the matrix is set to -1.

        Solution solution = new();

        ListNode a01 = new(0, null);
        ListNode a51 = new(5, a01);
        ListNode a52 = new(5, a51);
        ListNode a21 = new(2, a52);
        ListNode a4 = new(4, a21);
        ListNode a9 = new(9, a4);
        ListNode a7 = new(7, a9);
        ListNode a1 = new(1, a7);
        ListNode a8 = new(8, a1);
        ListNode a6 = new(6, a8);
        ListNode a22 = new(2, a6);
        ListNode a02 = new(0, a22);
        ListNode a3 = new(3, a02);

        ListNode b2 = new(2, null);
        ListNode b1 = new(1, b2);
        ListNode b0 = new(0, b1);

        PrintMatrix(solution.SpiralMatrix(3, 5, a3));
        PrintMatrix(solution.SpiralMatrix(1, 4, b0));
    }

    public int[][] SpiralMatrix(int m, int n, ListNode head)
    {
        int[][] matrix = new int[m][];
        for (int i = 0; i < m; i++)
        {
            matrix[i] = new int[n];
            for (int j = 0; j < n; j++) matrix[i][j] = -1;
        }

        int top = 0;
        int bottom = m - 1;
        int left = 0;
        int right = n - 1;
        ListNode current = head;

        while (top <= bottom && left <= right && current != null)
        {
            for (int i = left; i <= right && current != null; i++)
            {
                matrix[top][i] = current.val;
                current = current.next;
            }

            top++;

            for (int i = top; i <= bottom && current != null; i++)
            {
                matrix[i][right] = current.val;
                current = current.next;
            }

            right--;
            
            for (int i = right; i >= left && current != null; i--)
            {
                matrix[bottom][i] = current.val;
                current = current.next;
            }

            bottom--;

            for (int i = bottom; i >= top && current != null; i--)
            {
                matrix[i][left] = current.val;
                current = current.next;
            }

            left++;
        }

        return matrix;
    }

    static void PrintMatrix(int[][] matrix)
    {
        foreach (int[] ints in matrix)
        {
            foreach (int i in ints) Console.Write($"{i}, ");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}

// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}