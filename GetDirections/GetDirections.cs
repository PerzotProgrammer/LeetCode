namespace GetDirections;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/step-by-step-directions-from-a-binary-tree-node-to-another/solutions/5485155/c-solution-for-step-by-step-directions-from-a-binary-tree-node-to-another-problem/?envType=daily-question&envId=2024-07-16
        // Example 1:
        //
        // Input: root = [5,1,2,3,null,6,4], startValue = 3, destValue = 6
        // Output: "UURL"
        // Explanation: The shortest path is: 3 → 1 → 5 → 2 → 6.

        // Example 2:
        //
        // Input: root = [2,1], startValue = 2, destValue = 1
        // Output: "L"
        // Explanation: The shortest path is: 2 → 1.


        Solution solution = new();

        TreeNode a4 = new(4, null, null);
        TreeNode a6 = new(6, null, null);
        TreeNode a2 = new(2, a6, a4);
        TreeNode a3 = new(3, null, null);
        TreeNode a1 = new(1, a3, null);
        TreeNode a5 = new(5, a1, a2);

        TreeNode b1 = new(1, null, null);
        TreeNode b2 = new(2, b1, null);

        Console.WriteLine(solution.GetDirections(a5, 3, 6));
        Console.WriteLine(solution.GetDirections(b2, 2, 1));
    }

    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        TreeNode lca = FindLCA(root, startValue, destValue);

        List<char> pathToStart = new();
        List<char> pathToDest = new();
        FindPath(lca, startValue, pathToStart);
        FindPath(lca, destValue, pathToDest);

        string result = new string('U', pathToStart.Count);
        result += string.Concat(pathToDest);

        return result;
    }

    private TreeNode FindLCA(TreeNode root, int p, int q)
    {
        if (root == null || root.val == p || root.val == q) return root;

        TreeNode left = FindLCA(root.left, p, q);
        TreeNode right = FindLCA(root.right, p, q);

        if (left != null && right != null) return root;

        return (left ?? right)!;
    }

    private bool FindPath(TreeNode root, int value, List<char> path)
    {
        if (root == null) return false;
        if (root.val == value) return true;

        path.Add('L');
        if (FindPath(root.left, value, path)) return true;

        path.RemoveAt(path.Count - 1);
        path.Add('R');

        if (FindPath(root.right, value, path)) return true;

        path.RemoveAt(path.Count - 1);

        return false;
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