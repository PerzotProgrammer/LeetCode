namespace IsSubPath;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/linked-list-in-binary-tree/solutions/5750552/c-solution-for-linked-list-in-binary-tree-problem/?envType=daily-question&envId=2024-09-07
        // Example 1:
        //
        // Input: head = [4,2,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
        // Output: true
        // Explanation: Nodes in blue form a subpath in the binary Tree.  

        // Example 2:
        //
        // Input: head = [1,4,2,6], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
        // Output: true

        // Example 3:
        //
        // Input: head = [1,4,2,6,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
        // Output: false
        // Explanation: There is no path in the binary tree that contains all the elements of the linked list from head.


        Solution solution = new();

        ListNode al8 = new(8, null);
        ListNode al2 = new(2, al8);
        ListNode al4 = new(4, al2);

        TreeNode a3 = new(3, null, null);
        TreeNode a11 = new(1, null, null);
        TreeNode a8 = new(8, a11, a3);
        TreeNode a6 = new(6, null, null);
        TreeNode a12 = new(1, null, null);
        TreeNode a21 = new(2, a6, a8);
        TreeNode a22 = new(2, a12, null);
        TreeNode a41 = new(4, a21, null);
        TreeNode a42 = new(4, null, a22);
        TreeNode a13 = new(1, a42, a41);

        Console.WriteLine(solution.IsSubPath(al4, a13));
    }

    public bool IsSubPath(ListNode head, TreeNode root)
    {
        if (root == null) return false;

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode currentNode = queue.Dequeue();

            if (currentNode.val == head.val && DfsCheck(currentNode, head)) return true;
            if (currentNode.left != null) queue.Enqueue(currentNode.left);
            if (currentNode.right != null) queue.Enqueue(currentNode.right);
        }

        return false;
    }

    private bool DfsCheck(TreeNode node, ListNode head)
    {
        if (head == null) return true;
        if (node == null || node.val != head.val) return false;
        return DfsCheck(node.left, head.next) || DfsCheck(node.right, head.next);
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