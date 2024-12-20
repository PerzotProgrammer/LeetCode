namespace ReverseOddLevels;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: root = [2,3,5,8,13,21,34]
        // Output: [2,5,3,8,13,21,34]
        // Explanation: 
        // The tree has only one odd level.
        // The nodes at level 1 are 3, 5 respectively, which are reversed and become 5, 3.

        // Example 2:
        //
        // Input: root = [7,13,11]
        // Output: [7,11,13]
        // Explanation: 
        // The nodes at level 1 are 13, 11, which are reversed and become 11, 13.

        // Example 3:
        //
        // Input: root = [0,1,2,0,0,0,0,1,1,1,1,2,2,2,2]
        // Output: [0,2,1,0,0,0,0,2,2,2,2,1,1,1,1]
        // Explanation: 
        // The odd levels have non-zero values.
        // The nodes at level 1 were 1, 2, and are 2, 1 after the reversal.
        // The nodes at level 3 were 1, 1, 1, 1, 2, 2, 2, 2, and are 2, 2, 2, 2, 1, 1, 1, 1 after the reversal.


        Solution solution = new();

        TreeNode a34 = new(34, null, null);
        TreeNode a21 = new(21, null, null);
        TreeNode a13 = new(13, null, null);
        TreeNode a8 = new(8, null, null);
        TreeNode a5 = new(5, a21, a34);
        TreeNode a3 = new(3, a8, a13);
        TreeNode a2 = new(2, a3, a5);

        TreeNode b11 = new(11, null, null);
        TreeNode b13 = new(13, null, null);
        TreeNode b7 = new(7, b13, b11);

        PrintTree(solution.ReverseOddLevels(a2));
        PrintTree(solution.ReverseOddLevels(b7));
    }

    public TreeNode ReverseOddLevels(TreeNode root)
    {
        if (root == null) return null!;

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        int level = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            List<TreeNode> currentLevelNodes = new();

            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                currentLevelNodes.Add(node);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            if (level % 2 == 1)
            {
                int left = 0;
                int right = currentLevelNodes.Count - 1;
                while (left < right)
                {
                    (currentLevelNodes[left].val, currentLevelNodes[right].val) =
                        (currentLevelNodes[right].val, currentLevelNodes[left].val);
                    left++;
                    right--;
                }
            }

            level++;
        }

        return root;
    }

    static void PrintTree(TreeNode root)
    {
        if (root == null) return;

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int size = queue.Count;

            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                Console.Write($"{node.val}, ");

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }

        Console.WriteLine();
    }
}

// Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}