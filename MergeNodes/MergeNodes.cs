namespace MergeNodes;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: head = [0,3,1,0,4,5,2,0]
        // Output: [4,11]
        // Explanation: 
        // The above figure represents the given linked list. The modified list contains
        //     - The sum of the nodes marked in green: 3 + 1 = 4.
        // - The sum of the nodes marked in red: 4 + 5 + 2 = 11.

        // Example 2:
        //
        // Input: head = [0,1,0,3,0,2,2,0]
        // Output: [1,3,4]
        // Explanation: 
        // The above figure represents the given linked list. The modified list contains
        //     - The sum of the nodes marked in green: 1 = 1.
        // - The sum of the nodes marked in red: 3 = 3.
        // - The sum of the nodes marked in yellow: 2 + 2 = 4.


        Solution solution = new();

        ListNode a01 = new ListNode(0, null);
        ListNode a2 = new ListNode(2, a01);
        ListNode a5 = new ListNode(5, a2);
        ListNode a4 = new ListNode(4, a5);
        ListNode a02 = new ListNode(0, a4);
        ListNode a1 = new ListNode(1, a02);
        ListNode a3 = new ListNode(3, a1);
        ListNode a03 = new ListNode(0, a3);
        
        ListNode b01 = new ListNode(0, null);
        ListNode b21 = new ListNode(2, b01);
        ListNode b22 = new ListNode(2, b21);
        ListNode b02 = new ListNode(0, b22);
        ListNode b3 = new ListNode(3, b02);
        ListNode b03 = new ListNode(0, b3);
        ListNode b1 = new ListNode(1, b03);
        ListNode b04 = new ListNode(0, b1);
        
        PrintList(solution.MergeNodes(a03));
        PrintList(solution.MergeNodes(b04));
    }

    public ListNode MergeNodes(ListNode head)
    {
        ListNode currentNode = head;

        while (currentNode != null && currentNode.next != null)
        {
            if (currentNode.next.val != 0)
            {
                currentNode.val += currentNode.next.val;
                currentNode.next = currentNode.next.next;
            }
            else currentNode = currentNode.next;

            if (currentNode.next != null && currentNode.next.val == 0 && currentNode.next.next == null)
            {
                currentNode.next = null!;
            }
        }

        return head;
    }

    static void PrintList(ListNode root)
    {
        if (root == null) return;
        ListNode current = root;
        while (current.next != null)
        {
            Console.Write($"{current.val},");
            current = current.next;
        }

        Console.Write($"{current.val}");
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