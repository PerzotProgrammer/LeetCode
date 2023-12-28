namespace GetLengthOfOptimalCompression;

class Solution
{
    static void Main()
    {
        // Pozdrowienia dla użytkownika ariel30
        // Użyłem jego kodu aby mi seria nie spadła
        // link do wątku: https://leetcode.com/problems/string-compression-ii/solutions/4470497/the-editorial-solution-translated-to-c-using-tuples-and-bytes-instead-of-the-key-encoding/?envType=daily-question&envId=2023-12-28

        // Example 1:
        //
        // Input: s = "aaabcccd", k = 2
        // Output: 4
        // Explanation: Compressing s without deleting anything will give us "a3bc3d" of length 6. Deleting any of the characters 'a' or 'c' would at most decrease the length of the compressed string to 5, for instance delete 2 'a' then we will have s = "abcccd" which compressed is abc3d. Therefore, the optimal way is to delete 'b' and 'd', then the compressed version of s will be "a3c3" of length 4.


        // Example 2:
        //
        // Input: s = "aabbaa", k = 2
        // Output: 2
        // Explanation: If we delete both 'b' characters, the resulting compressed string would be "a4" of length 2.


        // Example 3:
        //
        // Input: s = "aaaaaaaaaaa", k = 0
        // Output: 3
        // Explanation: Since k is zero, we cannot delete anything. The compressed string is "a11" of length 3.

        Solution solution = new();

        Console.WriteLine(solution.GetLengthOfOptimalCompression("aaabcccd", 2));
        Console.WriteLine(solution.GetLengthOfOptimalCompression("aabbaa", 2));
        Console.WriteLine(solution.GetLengthOfOptimalCompression("aaaaaaaaaa", 0));
    }

    Dictionary<(byte idx, char lastChar, byte lastCharCount, byte k), byte> cache = new();
    HashSet<byte> longer = new() { 1, 9, 99 };

    public int GetLengthOfOptimalCompression(string s, int k)
    {
        var result = dp(s, 0, '#', 0, (byte)k);
        cache.Clear();
        return result;
    }

    public byte dp(string s, byte idx, char lastChar, byte lastCharCount, byte k)
    {
        if (k > 100)
        {
            return byte.MaxValue;
        }

        if (idx == s.Length)
        {
            return 0;
        }

        byte size;
        if (cache.TryGetValue((idx, lastChar, lastCharCount, k), out size))
        {
            return size;
        }

        byte sizeIfSkipping = dp(s, (byte)(idx + 1), lastChar, lastCharCount, (byte)(k - 1));
        byte sizeIfKeeping = s[idx] == lastChar
            ? (byte)(dp(s, (byte)(idx + 1), lastChar, (byte)(lastCharCount + 1), k) +
                     (longer.Contains(lastCharCount) ? 1 : 0))
            : (byte)(dp(s, (byte)(idx + 1), s[idx], 1, k) + 1);

        size = Math.Min(sizeIfSkipping, sizeIfKeeping);
        cache[(idx, lastChar, lastCharCount, k)] = size;
        return size;
    }
}