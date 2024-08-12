namespace KthLargest;

class KthLargest
{
    static void Main()
    {
        // example 1:
        //
        // Input
        // ["KthLargest", "add", "add", "add", "add", "add"]
        // [[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
        // Output
        // [null, 4, 5, 5, 8, 8]
        //
        // Explanation
        // KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
        // kthLargest.add(3);   // return 4
        // kthLargest.add(5);   // return 5
        // kthLargest.add(10);  // return 5
        // kthLargest.add(9);   // return 8
        // kthLargest.add(4);   // return 8

        KthLargest kthLargest = new(3, [4, 5, 8, 2]);
        int a = kthLargest.Add(3);
        int b = kthLargest.Add(5);
        int c = kthLargest.Add(10);
        int d = kthLargest.Add(9);
        int e = kthLargest.Add(4);

        Console.WriteLine($"{a}, {b}, {c}, {d}, {e}");
    }

    private List<int> NumsList;
    private int K;

    public KthLargest(int k, int[] nums)
    {
        K = k;
        NumsList = new(nums);
        NumsList.Sort();
    }

    public int Add(int val)
    {
        int index = NumsList.BinarySearch(val);
        if (index < 0) index = ~index;
        NumsList.Insert(index, val);

        return NumsList[^K];
    }
}