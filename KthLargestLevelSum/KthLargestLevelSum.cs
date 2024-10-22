namespace KthLargestLevelSum;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: root = [5,8,9,2,1,3,7,4,6], k = 2
        // Output: 13
        // Explanation: The level sums are the following:
        // - Level 1: 5.
        // - Level 2: 8 + 9 = 17.
        // - Level 3: 2 + 1 + 3 + 7 = 13.
        // - Level 4: 4 + 6 = 10.
        // The 2nd largest level sum is 13.

        // Example 2:
        //
        // Input: root = [1,2,null,3], k = 1
        // Output: 3
        // Explanation: The largest level sum is 3.


        TreeNode a6 = new(6, null, null);
        TreeNode a4 = new(4, null, null);
        TreeNode a7 = new(7, null, null);
        TreeNode a3 = new(3, null, null);
        TreeNode a1 = new(1, null, null);
        TreeNode a2 = new(2, a4, a6);
        TreeNode a9 = new(9, a3, a7);
        TreeNode a8 = new(8, a2, a1);
        TreeNode a5 = new(5, a8, a9);

        TreeNode b3 = new(3, null, null);
        TreeNode b2 = new(2, b3, null);
        TreeNode b1 = new(1, b2, null);

        Solution solution = new();

        Console.WriteLine(solution.KthLargestLevelSum(a5, 2));
        Console.WriteLine(solution.KthLargestLevelSum(b1, 1));
    }

    public long KthLargestLevelSum(TreeNode root, int k)
    {
        if (root == null) return -1;

        PriorityQueue<long, long> minHeap = new();
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            long levelSum = 0;

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode currentNode = queue.Dequeue();
                levelSum += currentNode.val;

                if (currentNode.left != null) queue.Enqueue(currentNode.left);
                if (currentNode.right != null) queue.Enqueue(currentNode.right);
            }

            if (minHeap.Count < k) minHeap.Enqueue(levelSum, levelSum);
            else if (levelSum > minHeap.Peek())
            {
                minHeap.Dequeue();
                minHeap.Enqueue(levelSum, levelSum);
            }
        }

        return minHeap.Count == k ? minHeap.Peek() : -1;
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