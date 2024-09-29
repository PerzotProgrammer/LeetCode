namespace AllOne;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input
        // ["AllOne", "inc", "inc", "getMaxKey", "getMinKey", "inc", "getMaxKey", "getMinKey"]
        // [[], ["hello"], ["hello"], [], [], ["leet"], [], []]
        // Output
        // [null, null, null, "hello", "hello", null, "hello", "leet"]
        //
        // Explanation
        // AllOne allOne = new AllOne();
        // allOne.inc("hello");
        // allOne.inc("hello");
        // allOne.getMaxKey(); // return "hello"
        // allOne.getMinKey(); // return "hello"
        // allOne.inc("leet");
        // allOne.getMaxKey(); // return "hello"
        // allOne.getMinKey(); // return "leet"


        AllOne allOne = new AllOne();
        allOne.Inc("hello");
        allOne.Inc("hello");
        string a1 = allOne.GetMaxKey();
        string a2 = allOne.GetMaxKey();
        allOne.Inc("leet");
        string a3 = allOne.GetMaxKey();
        string a4 = allOne.GetMinKey();

        Console.WriteLine($"{a1} {a2} {a3} {a4}");
    }
}

public class AllOne
{
    private Dictionary<string, int> CountMap;

    private Dictionary<int, HashSet<string>> Buckets;

    private SortedSet<int> SortedCounts;

    public AllOne()
    {
        CountMap = new();
        Buckets = new();
        SortedCounts = new();
    }

    public void Inc(string key)
    {
        if (!CountMap.TryAdd(key, 1))
        {
            int currentCount = CountMap[key];
            Buckets[currentCount].Remove(key);
            if (Buckets[currentCount].Count == 0)
            {
                Buckets.Remove(currentCount);
                SortedCounts.Remove(currentCount);
            }

            int newCount = currentCount + 1;
            CountMap[key] = newCount;

            if (!Buckets.ContainsKey(newCount))
            {
                Buckets[newCount] = new();
                SortedCounts.Add(newCount);
            }

            Buckets[newCount].Add(key);
        }
        else
        {
            if (!Buckets.ContainsKey(1))
            {
                Buckets[1] = new();
                SortedCounts.Add(1);
            }

            Buckets[1].Add(key);
        }
    }

    public void Dec(string key)
    {
        if (CountMap.ContainsKey(key))
        {
            int currentCount = CountMap[key];
            Buckets[currentCount].Remove(key);
            if (Buckets[currentCount].Count == 0)
            {
                Buckets.Remove(currentCount);
                SortedCounts.Remove(currentCount);
            }

            if (currentCount == 1) CountMap.Remove(key);
            else
            {
                int newCount = currentCount - 1;
                CountMap[key] = newCount;

                if (!Buckets.ContainsKey(newCount))
                {
                    Buckets[newCount] = new HashSet<string>();
                    SortedCounts.Add(newCount);
                }

                Buckets[newCount].Add(key);
            }
        }
    }

    public string GetMaxKey()
    {
        if (SortedCounts.Count == 0) return "";

        int maxCount = SortedCounts.Max;
        return Buckets[maxCount].First();
    }

    public string GetMinKey()
    {
        if (SortedCounts.Count == 0) return "";

        int minCount = SortedCounts.Min;
        return Buckets[minCount].First();
    }
}