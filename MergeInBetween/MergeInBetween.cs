namespace MergeInBetween;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: list1 = [10,1,13,6,9,5], a = 3, b = 4, list2 = [1000000,1000001,1000002]
        // Output: [10,1,13,1000000,1000001,1000002,5]
        // Explanation: We remove the nodes 3 and 4 and put the entire list2 in their place. The blue edges and nodes in the above figure indicate the result.

        // Example 2:
        //
        // Input: list1 = [0,1,2,3,4,5,6], a = 2, b = 5, list2 = [1000000,1000001,1000002,1000003,1000004]
        // Output: [0,1,1000000,1000001,1000002,1000003,1000004,6]
        // Explanation: The blue edges and nodes in the above figure indicate the result.

        Solution solution = new();

        ListNode a5 = new(5, null);
        ListNode a9 = new(9, a5);
        ListNode a6 = new(6, a9);
        ListNode a13 = new(13, a6);
        ListNode a1 = new(1, a13);
        ListNode a10 = new(10, a1);

        ListNode a102 = new(1000000, null);
        ListNode a101 = new(1000001, a102);
        ListNode a100 = new(1000001, a101);

        ListNode b6 = new(6, null);
        ListNode b5 = new(5, b6);
        ListNode b4 = new(4, b5);
        ListNode b3 = new(3, b4);
        ListNode b2 = new(2, b3);
        ListNode b1 = new(1, b2);
        ListNode b0 = new(0, b1);

        ListNode b104 = new(1000004, null);
        ListNode b103 = new(1000003, b104);
        ListNode b102 = new(1000002, b103);
        ListNode b101 = new(1000001, b102);
        ListNode b100 = new(1000000, b101);

        PrintList(solution.MergeInBetween(b0, 2, 5, b100));
        PrintList(solution.MergeInBetween(a10, 3, 4, a100));
    }

    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
    {
        ListNode dummy = new() { next = list1 };
        ListNode prev = dummy;

        for (int i = 0; i < a; i++) prev = prev.next;

        ListNode curr = prev;
        for (int i = a; i <= b; i++) curr = curr.next;

        prev.next = list2;
        while (list2.next != null) list2 = list2.next;

        list2.next = curr.next;
        return dummy.next;
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