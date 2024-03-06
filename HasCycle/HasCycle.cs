namespace HasCycle;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: head = [3,2,0,-4], pos = 1
        // Output: true
        // Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).
        
        // Example 2:
        //
        // Input: head = [1,2], pos = 0
        // Output: true
        // Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.
        
        // Example 3:
        //
        // Input: head = [1], pos = -1
        // Output: false
        // Explanation: There is no cycle in the linked list.

        Solution solution = new();

        ListNode a4 = new(-4);
        ListNode a0 = new(0);
        ListNode a2 = new(2);
        ListNode a3 = new(3);

        a3.next = a2;
        a2.next = a0;
        a0.next = a4;
        a4.next = a2;

        ListNode b2 = new(2);
        ListNode b1 = new(1);

        b1.next = b2;
        b2.next = b1;

        ListNode c1 = new(1);
        
        Console.WriteLine(solution.HasCycle(a3));
        Console.WriteLine(solution.HasCycle(b1));
        Console.WriteLine(solution.HasCycle(c1));
    }

    public bool HasCycle(ListNode head)
    {
        List<ListNode> visited = new();

        while (head != null)
        {
            if (visited.Contains(head)) return true;
            visited.Add(head);
            head = head.next;
        }

        return false;
    }
}

// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}