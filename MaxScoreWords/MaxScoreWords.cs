namespace MaxScoreWords;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/maximum-score-words-formed-by-letters/solutions/5200904/c-letters-map-solution/?envType=daily-question&envId=2024-05-24

        // Example 1:
        //
        // Input: words = ["dog","cat","dad","good"], letters = ["a","a","c","d","d","d","g","o","o"], score = [1,0,9,5,0,0,3,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0]
        // Output: 23
        // Explanation:
        // Score  a=1, c=9, d=5, g=3, o=2
        // Given letters, we can form the words "dad" (5+1+5) and "good" (3+2+2+5) with a score of 23.
        // Words "dad" and "dog" only get a score of 21.

        // Example 2:
        //
        // Input: words = ["xxxz","ax","bx","cx"], letters = ["z","a","b","c","x","x","x"], score = [4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,10]
        // Output: 27
        // Explanation:
        // Score  a=4, b=4, c=4, x=5, z=10
        // Given letters, we can form the words "ax" (4+5), "bx" (4+5) and "cx" (4+5) with a score of 27.
        // Word "xxxz" only get a score of 25.

        // Example 3:
        //
        // Input: words = ["leetcode"], letters = ["l","e","t","c","o","d"], score = [0,0,1,1,1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0]
        // Output: 0
        // Explanation:
        // Letter "e" can only be used once.


        Solution solution = new();


        Console.WriteLine(solution.MaxScoreWords(["dog", "cat", "dad", "good"],
            ['a', 'a', 'c', 'd', 'd', 'd', 'g', 'o', 'o'],
            [1, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]));
        Console.WriteLine(solution.MaxScoreWords(["xxxz", "ax", "bx", "cx"], ['z', 'a', 'b', 'c', 'x', 'x', 'x'],
            [4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 10]));
        Console.WriteLine(solution.MaxScoreWords(["leetcode"], ['l', 'e', 't', 'c', 'o', 'd'],
            [0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0]));
    }

    private int MaxScore;

    public int MaxScoreWords(string[] words, char[] letters, int[] score)
    {
        int[] lettersMap = new int[26];
        foreach (char symbol in letters) lettersMap[symbol - 'a']++;

        List<int[]> wordsMap = new();
        foreach (string word in words)
        {
            int[] temp = new int[26];
            foreach (char symbol in word) temp[symbol - 'a']++;

            wordsMap.Add(temp);
        }

        FindMaxScore(wordsMap, lettersMap, score, 0, 0);
        int output = MaxScore;
        MaxScore = 0;
        return output;
    }

    private void FindMaxScore(List<int[]> wordsMap, int[] letterMap, int[] score, int start, int scoreSum)
    {
        for (int i = start; i < wordsMap.Count; i++)
        {
            int[] wordMap = wordsMap[i];
            if (IsPossibleToAdd(wordMap, letterMap))
            {
                for (int j = 0; j < 26; j++)
                {
                    if (wordMap[j] != 0)
                    {
                        letterMap[j] -= wordMap[j];
                        scoreSum += score[j] * wordMap[j];
                        if (scoreSum > MaxScore) MaxScore = scoreSum;
                    }
                }

                FindMaxScore(wordsMap, letterMap, score, i + 1, scoreSum);
                for (int j = 0; j < 26; j++)
                {
                    if (wordMap[j] != 0)
                    {
                        letterMap[j] += wordMap[j];
                        scoreSum -= score[j] * wordMap[j];
                    }
                }
            }
        }
    }

    private bool IsPossibleToAdd(int[] wordMap, int[] letterMap)
    {
        for (int i = 0; i < 26; i++)
        {
            if (wordMap[i] > letterMap[i]) return false;
        }

        return true;
    }
}