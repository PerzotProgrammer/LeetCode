namespace ReverseList;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: head = [1,2,3,4,5]
        // Output: [5,4,3,2,1]
        // Example 2:
        //
        //
        // Input: head = [1,2]
        // Output: [2,1]
        // Example 3:
        //
        // Input: head = []
        // Output: []

        Solution solution = new();

        ListNode a5 = new(5, null);
        ListNode a4 = new(4, a5);
        ListNode a3 = new(3, a4);
        ListNode a2 = new(2, a3);
        ListNode a1 = new(1, a2);

        ListNode b2 = new(2, null);
        ListNode b1 = new(1, b2);
        
        PrintList(solution.ReverseList(a1));
        PrintList(solution.ReverseList(b1));
    }

    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null) return head;

        ListNode reversedList = ReverseList(head.next);

        head.next.next = head;
        head.next = null;

        return reversedList;
    }

    static void PrintList(ListNode listNode)
    {
        ListNode curr = listNode;
        while (true)
        {
            try
            {
                Console.Write($"{curr.val}, ");
                curr = curr.next;
            }
            catch (NullReferenceException)
            {
                break;
            }
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