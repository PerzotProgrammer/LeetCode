namespace RemoveNodes;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: head = [5,2,13,3,8]
        // Output: [13,8]
        // Explanation: The nodes that should be removed are 5, 2 and 3.
        // - Node 13 is to the right of node 5.
        // - Node 13 is to the right of node 2.
        // - Node 8 is to the right of node 3.
        //     Example 2:
        //
        // Input: head = [1,1,1,1]
        // Output: [1,1,1,1]
        // Explanation: Every node has value 1, so no nodes are removed.

        Solution solution = new();

        ListNode a5 = new(5);
        ListNode a2 = new(2);
        ListNode a13 = new(13);
        ListNode a3 = new(3);
        ListNode a8 = new(8);

        a5.next = a2;
        a2.next = a13;
        a13.next = a3;
        a3.next = a8;

        ListNode b11 = new(1);
        ListNode b12 = new(1);
        ListNode b13 = new(1);
        ListNode b14 = new(1);

        b11.next = b12;
        b12.next = b13;
        b13.next = b14;
        
        PrintLinkedList(solution.RemoveNodes(a5));
        PrintLinkedList(solution.RemoveNodes(b11));
    }

    public ListNode RemoveNodes(ListNode head)
    {
        Stack<ListNode> stack = new();
        ListNode current = head;

        while (current != null)
        {
            stack.Push(current);
            current = current.next;
        }

        current = stack.Pop();
        int maximum = current.val;
        ListNode resultList = new(maximum);

        while (stack.Count > 0)
        {
            current = stack.Pop();
            if (current.val < maximum) continue;
            ListNode newNode = new(current.val);
            newNode.next = resultList;
            resultList = newNode;
            maximum = current.val;
        }

        return resultList;
    }

    static void PrintLinkedList(ListNode head)
    {
        ListNode? current = head;
        while (current != null)
        {
            Console.Write($"{current.val}, ");
            current = current.next;
        }

        Console.WriteLine();
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