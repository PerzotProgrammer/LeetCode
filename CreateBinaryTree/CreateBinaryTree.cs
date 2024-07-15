namespace CreateBinaryTree;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: descriptions = [[20,15,1],[20,17,0],[50,20,1],[50,80,0],[80,19,1]]
        // Output: [50,20,80,15,17,19]
        // Explanation: The root node is the node with value 50 since it has no parent.
        // The resulting binary tree is shown in the diagram.

        // Example 2:
        //
        // Input: descriptions = [[1,2,1],[2,3,0],[3,4,1]]
        // Output: [1,2,null,null,3,4]
        // Explanation: The root node is the node with value 1 since it has no parent.
        // The resulting binary tree is shown in the diagram.


        // SPRAWDZONE W LEETCODE
    }

    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        Dictionary<int, TreeNode> nodeMap = new();
        Dictionary<int, int> childToParentMap = new();

        foreach (int[] description in descriptions)
        {
            int parent = description[0];
            int child = description[1];
            int isLeft = description[2];

            if (!nodeMap.ContainsKey(parent)) nodeMap[parent] = new(parent);

            TreeNode parentNode = nodeMap[parent];

            if (!nodeMap.ContainsKey(child)) nodeMap[child] = new(child);

            TreeNode childNode = nodeMap[child];

            if (isLeft == 1) parentNode.left = childNode;
            else parentNode.right = childNode;

            childToParentMap[child] = parent;
        }

        foreach (int[] description in descriptions)
        {
            int parent = description[0];
            if (!childToParentMap.ContainsKey(parent)) return nodeMap[parent];
        }

        return null;
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