namespace RemoveNthFromEnd;

class Solution
{
    static void Main()
    {
        // Example 1:
        
        // Input: head = [1,2,3,4,5], n = 2
        // Output: [1,2,3,5]
        
        // Example 2:

        // Input: head = [1], n = 1
        // Output: []
        
        // Example 3:

        // Input: head = [1,2], n = 1
        // Output: [1]

        ListNode a5 = new(5, null);
        ListNode a4 = new(4, a5);
        ListNode a3 = new(3, a4);
        ListNode a2 = new(2, a3);
        ListNode a1 = new(1, a2);

        ListNode b1 = new(1, null);

        ListNode c2 = new(2, null);
        ListNode c1 = new(1, c2);

        Solution solution = new();
        
        PrintList(solution.RemoveNthFromEnd(a1, 2));
        PrintList(solution.RemoveNthFromEnd(b1, 1));
        PrintList(solution.RemoveNthFromEnd(c1, 1));
        
    }

    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode dummy = new();
        dummy.next = head;
        
        ListNode fast = dummy;
        ListNode slow = dummy;

        for (int i = 0; i <= n; i++) fast = fast.next;

        while (fast != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        slow.next = slow.next.next;
        return dummy.next;
    }

    static void PrintList(ListNode listNode)
    {
        ListNode curr = listNode;
        while (true)
        {
            Console.Write($"{curr.val}, ");
            if (curr.next == null) break;
            curr = curr.next;
        }
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
