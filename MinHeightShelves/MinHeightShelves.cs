namespace MinHeightShelves;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: books = [[1,1],[2,3],[2,3],[1,1],[1,1],[1,1],[1,2]], shelfWidth = 4
        // Output: 6
        // Explanation:
        // The sum of the heights of the 3 shelves is 1 + 3 + 2 = 6.
        // Notice that book number 2 does not have to be on the first shelf.
        //     
        // Example 2:
        //
        // Input: books = [[1,3],[2,4],[3,2]], shelfWidth = 6
        // Output: 4


        Solution solution = new();

        Console.WriteLine(solution.MinHeightShelves([[1, 1], [2, 3], [2, 3], [1, 1], [1, 1], [1, 1], [1, 2]], 4));
        Console.WriteLine(solution.MinHeightShelves([[1, 3], [2, 4], [3, 2]], 6));
    }

    public int MinHeightShelves(int[][] books, int shelfWidth)
    {
        int[] minHeightIfPlacingInFreshShelf = new int[books.Length];

        return FillShelves(0);

        int FillShelves(int index)
        {
            if (index == books.Length) return 0;
            if (minHeightIfPlacingInFreshShelf[index] != 0)
                return minHeightIfPlacingInFreshShelf[index];

            int spaceLeftInCurrentShelf = shelfWidth, maxHeightOfCurShelf = 0, minHtOfShelf = int.MaxValue;
            for (int i = index; i < books.Length; i++)
            {
                int curBookThickness = books[i][0];
                int curBookHt = books[i][1];

                spaceLeftInCurrentShelf -= curBookThickness;
                if (spaceLeftInCurrentShelf >= 0)
                {
                    maxHeightOfCurShelf = Math.Max(maxHeightOfCurShelf, curBookHt);
                    minHtOfShelf = Math.Min(minHtOfShelf, maxHeightOfCurShelf + FillShelves(i + 1));
                }
            }

            return minHeightIfPlacingInFreshShelf[index] = minHtOfShelf;
        }
    }
}