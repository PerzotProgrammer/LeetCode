namespace Postorder;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: root = [1,null,3,2,4,null,5,6]
        // Output: [5,6,3,2,4,1]

        // Example 2:
        //
        // Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
        // Output: [2,6,14,11,7,3,12,8,4,13,9,10,5,1]


        // SPRAWDZONE W LEETCODE
    }

    public IList<int> Postorder(Node root)
    {
        IList<int> result = new List<int>();
        if (root == null) return result;

        Stack<Node> stack = new();
        stack.Push(root);

        while (stack.Count > 0)
        {
            Node node = stack.Pop();
            result.Insert(0, node.val);
            foreach (Node child in node.children) stack.Push(child);
        }

        return result;
    }

    static void PrintList(IList<int> list)
    {
        foreach (int i in list) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}

// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> children;

    public Node()
    {
    }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}