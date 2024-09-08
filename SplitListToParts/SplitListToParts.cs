namespace SplitListToParts;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: head = [1,2,3], k = 5
        // Output: [[1],[2],[3],[],[]]
        // Explanation:
        // The first element output[0] has output[0].val = 1, output[0].next = null.
        //     The last element output[4] is null, but its string representation as a ListNode is [].

        // Example 2:
        //
        // Input: head = [1,2,3,4,5,6,7,8,9,10], k = 3
        // Output: [[1,2,3,4],[5,6,7],[8,9,10]]
        // Explanation:
        // The input has been split into consecutive parts with size difference at most 1, and earlier parts are a larger size than the later parts.


        Solution solution = new();

        ListNode a3 = new(3, null);
        ListNode a2 = new(2, a3);
        ListNode a1 = new(1, a2);

        ListNode b10 = new(10, null);
        ListNode b9 = new(9, b10);
        ListNode b8 = new(8, b9);
        ListNode b7 = new(7, b8);
        ListNode b6 = new(6, b7);
        ListNode b5 = new(5, b6);
        ListNode b4 = new(4, b5);
        ListNode b3 = new(3, b4);
        ListNode b2 = new(2, b3);
        ListNode b1 = new(1, b2);

        PrintList(solution.SplitListToParts(a1, 5));
        PrintList(solution.SplitListToParts(b1, 3));
    }

    public ListNode[] SplitListToParts(ListNode head, int k)
    {
        ListNode[] ans = new ListNode[k];

        int size = 0;
        ListNode current = head;
        while (current != null)
        {
            size++;
            current = current.next;
        }

        int splitSize = size / k;
        int numRemainingParts = size % k;

        current = head;
        for (int i = 0; i < k; i++)
        {
            ListNode newPart = new(0);
            ListNode tail = newPart;

            int currentSize = splitSize;
            if (numRemainingParts > 0)
            {
                numRemainingParts--;
                currentSize++;
            }

            int j = 0;
            while (j < currentSize)
            {
                tail.next = new(current.val);
                tail = tail.next;
                j++;
                current = current.next;
            }

            ans[i] = newPart.next;
        }

        return ans;
    }

    static void PrintList(ListNode[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            ListNode current = arr[i];
            if (current == null) continue;
            while (current.next != null)
            {
                Console.Write($"{current.val}, ");
                current = current.next;
            }

            Console.Write($"{current.val}, ");
            Console.WriteLine();
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