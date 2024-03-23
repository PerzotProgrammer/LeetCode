namespace ReorderList;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: head = [1,2,3,4]
        // Output: [1,4,2,3]

        // Example 2:
        //
        // Input: head = [1,2,3,4,5]
        // Output: [1,5,2,4,3]

        Solution solution = new();

        ListNode a4 = new(4, null);
        ListNode a3 = new(3, a4);
        ListNode a2 = new(2, a3);
        ListNode a1 = new(1, a2);

        ListNode b5 = new(5, null);
        ListNode b4 = new(4, b5);
        ListNode b3 = new(3, b4);
        ListNode b2 = new(2, b3);
        ListNode b1 = new(1, b2);
        
        solution.ReorderList(a1);
        solution.ReorderList(b1);
        
        PrintList(a1);
        PrintList(b1);
    }

    public void ReorderList(ListNode head)
    {
        ListNode slow = head, fast = head.next;

        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        ListNode right = slow.next, left = head;

        slow.next = null;

        ListNode prev = null, curr = right;
        while (curr != null)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        right = prev;

        while (right != null)
        {
            ListNode leftTemp = left.next, rightTemp = right.next;
            left.next = right;
            right.next = leftTemp;

            left = leftTemp;
            right = rightTemp;
        }
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