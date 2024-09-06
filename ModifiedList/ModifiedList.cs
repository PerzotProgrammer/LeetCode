namespace ModifiedList;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        // Input: nums = [1,2,3], head = [1,2,3,4,5]
        // Output: [4,5]
        // Explanation:
        // Remove the nodes with values 1, 2, and 3.
        //
        // Example 2:
        // Input: nums = [1], head = [1,2,1,2,1,2]
        // Output: [2,2,2]
        // Explanation:
        // Remove the nodes with value 1.
        //
        // Example 3:
        // Input: nums = [5], head = [1,2,3,4]
        // Output: [1,2,3,4]
        // Explanation:
        // No node has value 5.

        Solution solution = new();

        ListNode a5 = new(5, null);
        ListNode a4 = new(4, a5);
        ListNode a3 = new(3, a4);
        ListNode a2 = new(2, a3);
        ListNode a1 = new(1, a2);

        ListNode c4 = new(4, null);
        ListNode c3 = new(3, c4);
        ListNode c2 = new(2, c3);
        ListNode c1 = new(1, c2);

        PrintListNode(solution.ModifiedList([1, 2, 3], a1));
        PrintListNode(solution.ModifiedList([5], c1));
    }

    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        HashSet<int> valuesToRemove = new();
        foreach (int num in nums)
        {
            valuesToRemove.Add(num);
        }

        while (head != null && valuesToRemove.Contains(head.val)) head = head.next;

        if (head == null) return null;

        ListNode current = head;
        while (current.next != null)
        {
            if (valuesToRemove.Contains(current.next.val)) current.next = current.next.next;
            else current = current.next;
        }

        return head;
    }

    static void PrintListNode(ListNode node)
    {
        ListNode current = node;
        Console.Write($"{current.val}, ");
        if (current.next != null) PrintListNode(current.next);
        else Console.WriteLine();
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