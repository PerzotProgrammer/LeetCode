namespace TreeQueries;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/height-of-binary-tree-after-subtree-removal-queries/solutions/5970036/c-solution-for-height-of-binary-tree-after-subtree-removal-queries-problem/?envType=daily-question&envId=2024-10-26
        // Example 1:
        //
        // Input: root = [1,3,4,2,null,6,5,null,null,null,null,null,7], queries = [4]
        // Output: [2]
        // Explanation: The diagram above shows the tree after removing the subtree rooted at node with value 4.
        // The height of the tree is 2 (The path 1 -> 3 -> 2).

        // Example 2:
        //
        // Input: root = [5,8,9,2,1,3,7,4,6], queries = [3,2,4,8]
        // Output: [3,2,3,2]
        // Explanation: We have the following queries:
        // - Removing the subtree rooted at node with value 3. The height of the tree becomes 3 (The path 5 -> 8 -> 2 -> 4).
        // - Removing the subtree rooted at node with value 2. The height of the tree becomes 2 (The path 5 -> 8 -> 1).
        // - Removing the subtree rooted at node with value 4. The height of the tree becomes 3 (The path 5 -> 8 -> 2 -> 6).
        // - Removing the subtree rooted at node with value 8. The height of the tree becomes 2 (The path 5 -> 9 -> 3).


        Solution solution = new();

        TreeNode a7 = new(7, null, null);
        TreeNode a6 = new(6, null, null);
        TreeNode a2 = new(2, null, null);
        TreeNode a5 = new(5, null, a7);
        TreeNode a4 = new(4, a6, a5);
        TreeNode a3 = new(3, a2, null);
        TreeNode a1 = new(1, a3, a4);

        TreeNode b6 = new(6, null, null);
        TreeNode b4 = new(4, null, null);
        TreeNode b7 = new(7, null, null);
        TreeNode b3 = new(3, null, null);
        TreeNode b1 = new(1, null, null);
        TreeNode b2 = new(2, b4, b6);
        TreeNode b9 = new(5, b3, b7);
        TreeNode b8 = new(8, b2, b1);
        TreeNode b5 = new(5, b8, b9);
        
        
        PrintArray(solution.TreeQueries(a1, [4]));
        PrintArray(solution.TreeQueries(b5, [3, 2, 4, 8]));
    }

    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        Dictionary<int, int> nodeIndexMap = new Dictionary<int, int>();
        Dictionary<int, int> subtreeSize = new Dictionary<int, int>();

        List<int> nodeDepths = new List<int>();
        List<int> maxDepthFromLeft = new List<int>();
        List<int> maxDepthFromRight = new List<int>();
        Dfs(root, 0, nodeIndexMap, nodeDepths);

        int totalNodes = nodeDepths.Count;

        CalculateSubtreeSize(root, subtreeSize);

        maxDepthFromLeft.Add(nodeDepths[0]);
        maxDepthFromRight.Add(nodeDepths[totalNodes - 1]);

        for (int i = 1; i < totalNodes; i++)
        {
            maxDepthFromLeft.Add(Math.Max(maxDepthFromLeft[i - 1], nodeDepths[i]));
            maxDepthFromRight.Add(Math.Max(maxDepthFromRight[i - 1], nodeDepths[totalNodes - i - 1]));
        }

        maxDepthFromRight.Reverse();

        int[] results = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int queryNode = queries[i];
            int startIndex = nodeIndexMap[queryNode] - 1;
            int endIndex = startIndex + 1 + subtreeSize[queryNode];

            int maxDepth = maxDepthFromLeft[startIndex];
            if (endIndex < totalNodes)
            {
                maxDepth = Math.Max(maxDepth, maxDepthFromRight[endIndex]);
            }

            results[i] = maxDepth;
        }

        return results;
    }

    private void Dfs(TreeNode root, int depth, Dictionary<int, int> nodeIndexMap, List<int> nodeDepths)
    {
        if (root == null) return;

        nodeIndexMap[root.val] = nodeDepths.Count;
        nodeDepths.Add(depth);

        Dfs(root.left, depth + 1, nodeIndexMap, nodeDepths);
        Dfs(root.right, depth + 1, nodeIndexMap, nodeDepths);
    }

    private int CalculateSubtreeSize(TreeNode root, Dictionary<int, int> subtreeSize)
    {
        if (root == null) return 0;

        int leftSize = CalculateSubtreeSize(root.left, subtreeSize);
        int rightSize = CalculateSubtreeSize(root.right, subtreeSize);

        int totalSize = leftSize + rightSize + 1;
        subtreeSize[root.val] = totalSize;

        return totalSize;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
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