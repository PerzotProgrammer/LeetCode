namespace LeafSimilar;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root1 = [3,5,1,6,2,9,8,null,null,7,4], root2 = [3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]
        // Output: true


        // Example 2:
        //
        // Input: root1 = [1,2,3], root2 = [1,3,2]
        // Output: false

        TreeNode aa6 = new(6, null, null);
        TreeNode aa7 = new(7, null, null);
        TreeNode aa4 = new(4, null, null);
        TreeNode aa9 = new(9, null, null);
        TreeNode aa8 = new(8, null, null);
        TreeNode aa2 = new(2, aa7, aa4);
        TreeNode aa5 = new(5, aa6, aa2);
        TreeNode aa1 = new(1, aa9, aa8);
        TreeNode aa3 = new(3, aa5, aa1);

        TreeNode ab6 = new(6, null, null);
        TreeNode ab7 = new(7, null, null);
        TreeNode ab4 = new(4, null, null);
        TreeNode ab9 = new(9, null, null);
        TreeNode ab8 = new(8, null, null);
        TreeNode ab5 = new(5, ab6, ab7);
        TreeNode ab2 = new(2, ab9, ab8);
        TreeNode ab1 = new(1, ab4, ab2);
        TreeNode ab3 = new(3, ab5, ab1);

        Solution solution = new();

        Console.WriteLine(solution.LeafSimilar(aa3, ab3));
    }


    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        List<TreeNode> list1 = new();
        List<TreeNode> list2 = new();

        DFS(root1, list1);
        DFS(root2, list2);

        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i].val != list2[i].val)
                return false;
        }

        return true;
    }

    private void DFS(TreeNode node, List<TreeNode> leaves)
    {
        if (node == null)
            return;

        if (node.left == null && node.right == null)
        {
            leaves.Add(node);
            return;
        }

        DFS(node.left, leaves);
        DFS(node.right, leaves);
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