namespace DoubleIt;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: head = [1,8,9]
        // Output: [3,7,8]
        // Explanation: The figure above corresponds to the given linked list which represents the number 189. Hence, the returned linked list represents the number 189 * 2 = 378.

        // Example 2:
        //
        // Input: head = [9,9,9]
        // Output: [1,9,9,8]
        // Explanation: The figure above corresponds to the given linked list which represents the number 999. Hence, the returned linked list reprersents the number 999 * 2 = 1998. 


        Solution solution = new();

        ListNode a9 = new(9);
        ListNode a8 = new(8, a9);
        ListNode a1 = new(1, a8);

        ListNode b91 = new(9);
        ListNode b92 = new(9, b91);
        ListNode b93 = new(9, b92);
        
        PrintLinkedList(solution.DoubleIt(a1));
        PrintLinkedList(solution.DoubleIt(b93));
    }

    public ListNode DoubleIt(ListNode head)
    {
        Stack<int> stack = new();
        int val = 0;

        while (head != null)
        {
            stack.Push(head.val);
            head = head.next;
        }

        ListNode newTail = null!;

        while (stack.Count > 0 || val != 0)
        {
            newTail = new ListNode(0, newTail);
            if (stack.Count > 0) val += stack.Pop() * 2;

            newTail.val = val % 10;
            val /= 10;
        }

        return newTail;
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