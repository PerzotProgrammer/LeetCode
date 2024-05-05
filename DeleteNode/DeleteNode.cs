namespace DeleteNode;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: head = [4,5,1,9], node = 5
        // Output: [4,1,9]
        // Explanation: You are given the second node with value 5, the linked list should become 4 -> 1 -> 9 after calling your function.

        // Example 2:
        //
        // Input: head = [4,5,1,9], node = 1
        // Output: [4,5,9]
        // Explanation: You are given the third node with value 1, the linked list should become 4 -> 5 -> 9 after calling your function.

        Solution solution = new();

        ListNode a4 = new(4);
        ListNode a5 = new(5);
        ListNode a1 = new(1);
        ListNode a9 = new(9);

        a4.next = a5;
        a5.next = a1;
        a1.next = a9;

        ListNode b4 = new(4);
        ListNode b5 = new(5);
        ListNode b1 = new(1);
        ListNode b9 = new(9);

        b4.next = b5;
        b5.next = b1;
        b1.next = b9;

        solution.DeleteNode(a5);
        solution.DeleteNode(b1);
        
        PrintLinkedList(a4);
        PrintLinkedList(b4);
    }

    public void DeleteNode(ListNode node)
    {
        node.val = node.next.val;
        node.next = node.next.next;
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

    public ListNode(int x)
    {
        val = x;
    }
}