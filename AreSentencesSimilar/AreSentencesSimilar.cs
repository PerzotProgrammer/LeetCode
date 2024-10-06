namespace AreSentencesSimilar;

public class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: sentence1 = "My name is Haley", sentence2 = "My Haley"
        // Output: true
        // Explanation:
        // sentence2 can be turned to sentence1 by inserting "name is" between "My" and "Haley".

        // Example 2:
        //
        // Input: sentence1 = "of", sentence2 = "A lot of words"
        // Output: false
        // Explanation:
        // No single sentence can be inserted inside one of the sentences to make it equal to the other.

        // Example 3:
        //
        // Input: sentence1 = "Eating right now", sentence2 = "Eating"
        // Output: true
        // Explanation:
        // sentence2 can be turned to sentence1 by inserting "right now" at the end of the sentence.

        Solution solution = new();

        Console.WriteLine(solution.AreSentencesSimilar("My name is Haley", "My Haley"));
        Console.WriteLine(solution.AreSentencesSimilar("of", "A lot of words"));
        Console.WriteLine(solution.AreSentencesSimilar("Eating right now", "Eating"));
    }

    public bool AreSentencesSimilar(string sentence1, string sentence2)
    {
        string[] words1 = sentence1.Split(' ');
        string[] words2 = sentence2.Split(' ');

        int i = 0;
        int j = 0;
        int n1 = words1.Length;
        int n2 = words2.Length;

        while (i < n1 && i < n2 && words1[i] == words2[i]) i++;
        while (j < n1 - i && j < n2 - i && words1[n1 - 1 - j] == words2[n2 - 1 - j]) j++;
        return i + j == Math.Min(n1, n2);
    }
}