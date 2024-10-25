namespace RemoveSubfolders;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: folder = ["/a","/a/b","/c/d","/c/d/e","/c/f"]
        // Output: ["/a","/c/d","/c/f"]
        // Explanation: Folders "/a/b" is a subfolder of "/a" and "/c/d/e" is inside of folder "/c/d" in our filesystem.

        // Example 2:
        //
        // Input: folder = ["/a","/a/b/c","/a/b/d"]
        // Output: ["/a"]
        // Explanation: Folders "/a/b/c" and "/a/b/d" will be removed because they are subfolders of "/a".

        // Example 3:
        //
        // Input: folder = ["/a/b/c","/a/b/ca","/a/b/d"]
        // Output: ["/a/b/c","/a/b/ca","/a/b/d"]


        Solution solution = new();

        PrintList(solution.RemoveSubfolders(["/a", "/a/b", "/c/d", "/c/d/e", "/c/f"]));
        PrintList(solution.RemoveSubfolders(["/a", "/a/b/c", "/a/b/d"]));
        PrintList(solution.RemoveSubfolders(["/a/b/c", "/a/b/ca", "/a/b/d"]));
    }

    public IList<string> RemoveSubfolders(string[] folder)
    {
        Array.Sort(folder);
        List<string> result = new();

        string prev = "";
        foreach (string path in folder)
        {
            if (prev == "" || !path.StartsWith(prev + "/"))
            {
                result.Add(path);
                prev = path;
            }
        }

        return result;
    }

    static void PrintList(IList<string> list)
    {
        foreach (string s in list) Console.Write($"{s}, ");
        Console.WriteLine();
    }
}