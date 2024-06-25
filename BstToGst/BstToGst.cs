namespace BstToGst;

class Solution
{

    static void Main()
    {
        // Example 1:
        //
        // Input: root = [4,1,6,0,2,5,7,null,null,null,3,null,null,null,8]
        // Output: [30,36,21,36,35,26,15,null,null,null,33,null,null,null,8]
        
        // Example 2:
        //
        // Input: root = [0,null,1]
        // Output: [1,null,1]
        
        
        // SPRAWDZONE W LEETCODE
    }
    
    private TreeNode BstToGst(TreeNode root)
    {
        int sum = 0;
        TransformTree(root, ref sum);
        return root;
    }

    public void TransformTree(TreeNode node, ref int sum)
    {
        if (node == null) return;
        TransformTree(node.right, ref sum);
        sum += node.val;
        node.val = sum;
        TransformTree(node.left, ref sum);
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