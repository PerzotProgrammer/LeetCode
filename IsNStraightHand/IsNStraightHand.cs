namespace IsNStraightHand;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: hand = [1,2,3,6,2,3,4,7,8], groupSize = 3
        // Output: true
        // Explanation: Alice's hand can be rearranged as [1,2,3],[2,3,4],[6,7,8]

        // Example 2:
        //
        // Input: hand = [1,2,3,4,5], groupSize = 4
        // Output: false
        // Explanation: Alice's hand can not be rearranged into groups of 4.


        Solution solution = new();

        Console.WriteLine(solution.IsNStraightHand([1, 2, 3, 6, 2, 3, 4, 7, 8], 3));
        Console.WriteLine(solution.IsNStraightHand([1, 2, 3, 4, 5], 4));
    }

    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0) return false;

        Array.Sort(hand);
        Dictionary<int, int> cardCount = new();

        foreach (int card in hand)
        {
            cardCount.TryAdd(card, 0);
            cardCount[card]++;
        }

        foreach (int card in hand)
        {
            if (cardCount[card] != 0)
            {
                for (int i = 0; i < groupSize; i++)
                {
                    int currentCard = card + i;
                    if (!cardCount.ContainsKey(currentCard) || cardCount[currentCard] == 0) return false;

                    cardCount[currentCard]--;
                }
            }
        }

        return true;
    }
}