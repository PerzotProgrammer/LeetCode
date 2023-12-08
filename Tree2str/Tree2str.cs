namespace Tree2str;

class Solution
{
    static void Main()
    {
        // Example 1:
        //     
        // Input: root = [1,2,3,4]
        // Output: "1(2(4))(3)"
        // Explanation: Originally, it needs to be "1(2(4)())(3()())", but you need to omit all the unnecessary empty parenthesis pairs. And it will be "1(2(4))(3)"
        //
        //
        // Example 2:
        //
        // Input: root = [1,2,3,null,4]
        // Output: "1(2()(4))(3)"
        // Explanation: Almost the same as the first example, except we cannot omit the first parenthesis pair to break the one-to-one mapping relationship between the input and the output.

        TreeNode tn4a = new(4);
        TreeNode tn3a = new(3);
        TreeNode tn2a = new(2, tn4a);
        TreeNode tn1a = new(1, tn2a, tn3a);

        TreeNode tn4b = new(4);
        TreeNode tn3b = new(3);
        TreeNode tn2b = new(2, null!, tn4b);
        TreeNode tn1b = new(1, tn2b, tn3b);
        
        Solution solution = new();

        Console.WriteLine(solution.Tree2str(tn1a));
        Console.WriteLine(solution.Tree2str(tn1b));
    }
    
    public string Tree2str(TreeNode? root)
    {
        if (root == null) return "";
        
        string output = root.val.ToString();

        if (root.left != null! || root.right != null!)
        {
            output += "(" + Tree2str(root.left) + ")";
        }

        if (root.right != null)
        {
            output += "(" + Tree2str(root.right) + ")";
        }

        return output;
    }
}

// Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null!, TreeNode right = null!)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}