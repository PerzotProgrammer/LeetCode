namespace InsertGreatestCommonDivisors;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: head = [18,6,10,3]
        // Output: [18,6,6,2,10,1,3]
        // Explanation: The 1st diagram denotes the initial linked list and the 2nd diagram denotes the linked list after inserting the new nodes (nodes in blue are the inserted nodes).
        // - We insert the greatest common divisor of 18 and 6 = 6 between the 1st and the 2nd nodes.
        // - We insert the greatest common divisor of 6 and 10 = 2 between the 2nd and the 3rd nodes.
        // - We insert the greatest common divisor of 10 and 3 = 1 between the 3rd and the 4th nodes.
        // There are no more adjacent nodes, so we return the linked list.

        // Example 2:
        //
        // Input: head = [7]
        // Output: [7]
        // Explanation: The 1st diagram denotes the initial linked list and the 2nd diagram denotes the linked list after inserting the new nodes.
        // There are no pairs of adjacent nodes, so we return the initial linked list.


        Solution solution = new();

        ListNode a3 = new(3, null);
        ListNode a10 = new(10, a3);
        ListNode a6 = new(6, a10);
        ListNode a18 = new(18, a6);

        ListNode b7 = new(7, null);

        PrintList(solution.InsertGreatestCommonDivisors(a18));
        PrintList(solution.InsertGreatestCommonDivisors(b7));
    }

    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        if (head.next == null) return head;
        ListNode node1 = head;
        ListNode node2 = head.next;

        while (node2 != null)
        {
            int gcdValue = CalculateGcd(node1.val, node2.val);
            ListNode gcdNode = new(gcdValue);

            node1.next = gcdNode;
            gcdNode.next = node2;

            node1 = node2;
            node2 = node2.next;
        }

        return head;
    }

    private int CalculateGcd(int a, int b)
    {
        while (b != 0) (a, b) = (b, a % b);
        return a;
    }

    static void PrintList(ListNode head)
    {
        ListNode current = head;
        while (current.next != null)
        {
            Console.Write($"{current.val}, ");
            current = current.next;
        }

        Console.WriteLine($"{current.val}, ");
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