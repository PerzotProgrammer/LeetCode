namespace NodesBetweenCriticalPoints;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: head = [3,1]
        // Output: [-1,-1]
        // Explanation: There are no critical points in [3,1].
 
        // Example 2:
        //
        // Input: head = [5,3,1,2,5,1,2]
        // Output: [1,3]
        // Explanation: There are three critical points:
        // - [5,3,1,2,5,1,2]: The third node is a local minima because 1 is less than 3 and 2.
        // - [5,3,1,2,5,1,2]: The fifth node is a local maxima because 5 is greater than 2 and 1.
        // - [5,3,1,2,5,1,2]: The sixth node is a local minima because 1 is less than 5 and 2.
        // The minimum distance is between the fifth and the sixth node. minDistance = 6 - 5 = 1.
        // The maximum distance is between the third and the sixth node. maxDistance = 6 - 3 = 3.
        
        // Example 3:
        //
        // Input: head = [1,3,2,2,3,2,2,2,7]
        // Output: [3,3]
        // Explanation: There are two critical points:
        // - [1,3,2,2,3,2,2,2,7]: The second node is a local maxima because 3 is greater than 1 and 2.
        // - [1,3,2,2,3,2,2,2,7]: The fifth node is a local maxima because 3 is greater than 2 and 2.
        // Both the minimum and maximum distances are between the second and the fifth node.
        // Thus, minDistance and maxDistance is 5 - 2 = 3.
        // Note that the last node is not considered a local maxima because it does not have a next node.


        Solution solution = new();

        ListNode a21 = new(2, null);
        ListNode a11 = new(1, a21);
        ListNode a51 = new(5, a11);
        ListNode a22 = new(2, a51);
        ListNode a12 = new(1, a22);
        ListNode a3 = new(3, a12);
        ListNode a52 = new(5, a3);

        ListNode b7 = new(7, null);
        ListNode b21 = new(2, b7);
        ListNode b22 = new(2, b21);
        ListNode b23 = new(2, b22);
        ListNode b31 = new(3, b23);
        ListNode b24 = new(2, b31);
        ListNode b25 = new(2, b24);
        ListNode b32 = new(3, b25);
        ListNode b1 = new(1, b32);
        
        PrintArray(solution.NodesBetweenCriticalPoints(a52));
        PrintArray(solution.NodesBetweenCriticalPoints(b1));
    }
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        if (head == null || head.next == null || head.next.next == null) return [-1, -1];

        List<int> criticalPoints = new();
        ListNode prev = head;
        ListNode curr = head.next;
        ListNode next = curr.next;
        int index = 1;

        while (next != null)
        {
            if ((curr.val > prev.val && curr.val > next.val) || (curr.val < prev.val && curr.val < next.val))
                criticalPoints.Add(index);

            prev = curr;
            curr = next;
            next = next.next;
            index++;
        }

        if (criticalPoints.Count < 2) return [-1, -1];

        int minDistance = int.MaxValue;
        int maxDistance = criticalPoints[^1] - criticalPoints[0];

        for (int i = 1; i < criticalPoints.Count; i++)
        {
            minDistance = Math.Min(minDistance, criticalPoints[i] - criticalPoints[i - 1]);
        }

        return [minDistance, maxDistance];
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
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