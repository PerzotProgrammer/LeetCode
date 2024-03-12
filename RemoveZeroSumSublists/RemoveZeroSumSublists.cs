namespace RemoveZeroSumSublists;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: head = [1,2,-3,3,1]
        // Output: [3,1]
        // Note: The answer [1,2,1] would also be accepted.
        //     Example 2:
        //
        // Input: head = [1,2,3,-3,4]
        // Output: [1,2,4]
        // Example 3:
        //
        // Input: head = [1,2,3,-3,-2]
        // Output: [1]

        Solution solution = new();

        ListNode a12 = new(1, null);
        ListNode a3 = new(3, a12);
        ListNode an3 = new(-3, a3);
        ListNode a2 = new(2, an3);
        ListNode a11 = new(1, a2);

        ListNode b4 = new(4, null);
        ListNode bn3 = new(-3, b4);
        ListNode b3 = new(3, bn3);
        ListNode b2 = new(2, b3);
        ListNode b1 = new(1, b2);

        ListNode cn2 = new(-2, null);
        ListNode cn3 = new(-3, cn2);
        ListNode c3 = new(3, cn3);
        ListNode c2 = new(2, c3);
        ListNode c1 = new(1, c2);
        
        PrintList(solution.RemoveZeroSumSublists(a11));
        PrintList(solution.RemoveZeroSumSublists(b1));
        PrintList(solution.RemoveZeroSumSublists(c1));
    }

    public ListNode RemoveZeroSumSublists(ListNode head)
    {
        ListNode front = new ListNode(0, head);
        ListNode start = front;

        while (start != null)
        {
            int prefixSum = 0;
            ListNode end = start.next;

            while (end != null)
            {
                prefixSum += end.val;
                if (prefixSum == 0)
                {
                    start.next = end.next;
                }

                end = end.next;
            }

            start = start.next;
        }

        return front.next;
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