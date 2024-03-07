namespace MiddleNode;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: head = [1,2,3,4,5]
        // Output: [3,4,5]
        // Explanation: The middle node of the list is node 3.

        // Example 2:
        //
        // Input: head = [1,2,3,4,5,6]
        // Output: [4,5,6]
        // Explanation: Since the list has two middle nodes with values 3 and 4, we return the second one.

        Solution solution = new();

        ListNode a5 = new(5, null);
        ListNode a4 = new(4, a5);
        ListNode a3 = new(3, a4);
        ListNode a2 = new(2, a3);
        ListNode a1 = new(1, a2);

        ListNode b6 = new(6, null);
        ListNode b5 = new(5, b6);
        ListNode b4 = new(4, b5);
        ListNode b3 = new(3, b4);
        ListNode b2 = new(2, b3);
        ListNode b1 = new(1, b2);

        PrintList(solution.MiddleNode(a1));
        PrintList(solution.MiddleNode(b1));
    }

    public ListNode MiddleNode(ListNode head)
    {
        ListNode? slow = head;
        ListNode? fast = head.next;

        while (fast != null)
        {
            slow = slow.next;
            fast = fast.next?.next;
        }

        return slow;
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