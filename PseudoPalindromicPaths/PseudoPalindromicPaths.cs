namespace PseudoPalindromicPaths;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root = [2,3,1,3,1,null,1]
        // Output: 2 
        // Explanation: The figure above represents the given binary tree. There are three paths going from the root node to leaf nodes: the red path [2,3,3], the green path [2,1,1], and the path [2,3,1]. Among these paths only red path and green path are pseudo-palindromic paths since the red path [2,3,3] can be rearranged in [3,2,3] (palindrome) and the green path [2,1,1] can be rearranged in [1,2,1] (palindrome).
        
        // Example 2:
        //
        // Input: root = [2,1,1,1,3,null,null,null,null,null,1]
        // Output: 1 
        // Explanation: The figure above represents the given binary tree. There are three paths going from the root node to leaf nodes: the green path [2,1,1], the path [2,1,3,1], and the path [2,1]. Among these paths only the green path is pseudo-palindromic since [2,1,1] can be rearranged in [1,2,1] (palindrome).

        // Example 3:
        //
        // Input: root = [9]
        // Output: 1

        
        // Nie chciało mi się dawać tutaj rozwiązania, ale działa (zrobione za pomocą editoriala)

        
    }

    private int count;
    
    public int PseudoPalindromicPaths(TreeNode root)
    {
        count = 0;
        preorder(root, 0);
        return count;
    }

    public void preorder(TreeNode node, int path)
    {
        if (node != null)
        {
            path ^= 1 << node.val;
            if (node.left == null && node.right == null)
            {
                if ((path & (path - 1)) == 0)
                {
                    count++;
                }
            }

            preorder(node.left, path);
            preorder(node.right, path);
        }
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