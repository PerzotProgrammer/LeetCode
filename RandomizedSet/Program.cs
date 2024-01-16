namespace RandomizedSet;

class Program
{
    static void Main()
    {
        // Example 1:
        //
        // Input
        // ["RandomizedSet", "insert", "remove", "insert", "getRandom", "remove", "insert", "getRandom"]
        // [[], [1], [2], [2], [], [1], [2], []]
        // Output
        // [null, true, false, true, 2, true, false, 2]
        //
        // Explanation
        RandomizedSet randomizedSet = new RandomizedSet();
        bool s1 = randomizedSet.Insert(1); // Inserts 1 to the set. Returns true as 1 was inserted successfully.
        bool s2 = randomizedSet.Remove(2); // Returns false as 2 does not exist in the set.
        bool s3 =randomizedSet.Insert(2); // Inserts 2 to the set, returns true. Set now contains [1,2].
        int r1 = randomizedSet.GetRandom(); // getRandom() should return either 1 or 2 randomly.
        bool s4 = randomizedSet.Remove(1); // Removes 1 from the set, returns true. Set now contains [2].
        bool s5 = randomizedSet.Insert(2); // 2 was already in the set, so return false.
        int r2 = randomizedSet.GetRandom(); // Since 2 is the only number in the set, getRandom() will always return 2.

        Console.WriteLine($"{s1},{s2},{s3},{r1},{s4},{s5},{r2}");
    }
}

public class RandomizedSet {
    private List<int> nums;
    private Dictionary<int, int> indexMap;
    private Random rand;
    public RandomizedSet() {
        nums = new List<int>();
        indexMap = new Dictionary<int, int>();
        rand = new Random();
    }
    
    public bool Insert(int val) {
        if (indexMap.ContainsKey(val)) {
            return false;
        }

        nums.Add(val);
        indexMap[val] = nums.Count - 1;
        return true;
    }
    
    public bool Remove(int val) {
        if (!indexMap.ContainsKey(val)) {
            return false;
        }

        int lastElement = nums[nums.Count - 1];
        int valIndex = indexMap[val];

        nums[valIndex] = lastElement;
        indexMap[lastElement] = valIndex;

        nums.RemoveAt(nums.Count - 1);
        indexMap.Remove(val);

        return true;
    }
    
    public int GetRandom() {
        int randomIndex = rand.Next(nums.Count);
        return nums[randomIndex];
    }
}


// Your RandomizedSet object will be instantiated and called as such:
// RandomizedSet obj = new RandomizedSet();
// bool param_1 = obj.Insert(val);
// bool param_2 = obj.Remove(val);
// int param_3 = obj.GetRandom();
