namespace IsPalindrome;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: head = [1,2,2,1]
        // Output: true

        // Example 2:
        //
        // Input: head = [1,2]
        // Output: false

        Solution solution = new();

        ListNode a12 = new(1, null);
        ListNode a22 = new(2, a12);
        ListNode a21 = new(2, a22);
        ListNode a11 = new(1, a21);

        ListNode b2 = new(2, null);
        ListNode b1 = new(1, b2);

        Console.WriteLine(solution.IsPalindrome(a11));
        Console.WriteLine(solution.IsPalindrome(b1));
    }

    public bool IsPalindrome(ListNode head)
    {
        List<int> pal = new();
        while (head.next != null)
        {
            pal.Add(head.val);
            head = head.next;
        }

        pal.Add(head.val);

        List<int> palCp = new(pal);
        pal.Reverse();
        
        for (int i = 0; i < pal.Count; i++)
        {
            if (pal[i] != palCp[i]) return false;
        }

        return true;
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