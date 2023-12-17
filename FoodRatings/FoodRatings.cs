namespace FoodRatings;


// Kod napisany z pomocą użytkownika ChewyHams.
// W 90 % rozumiem program.
// Nie mówię, że sam napisałem ten kod, więc nie jest on moją własnością.
// Link do oryginalnego wątku: https://leetcode.com/problems/design-a-food-rating-system/solutions/4414494/time-100-c-simple-with-queue-and-iteration/?envType=daily-question&envId=2023-12-17


class FoodRatings
{
    private Dictionary<string, string> map;
    private Dictionary<string, PriorityQueue<(int r, string f, int t), (int r, string f, int t)>> items;
    private Dictionary<string, int> time;

    private int t;
    
    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        map = new();
        items = new();
        time = new();

        int n = foods.Length;
        for (int i = 0; i < n; i++)
        {
            map.Add(foods[i], cuisines[i]);
            time.Add(foods[i], 0);
            if (!items.ContainsKey(cuisines[i]))
            {
                items.Add(cuisines[i], new());
            }
            items[cuisines[i]].Enqueue((-ratings[i], foods[i], 0), (-ratings[i], foods[i], 0));
        }

        t = -1;
    }
    
    public void ChangeRating(string food, int newRating)
    {
        var que = items[map[food]];
        que.Enqueue((-newRating, food, t), (-newRating, food, t));
        time[food] = t;
        t--;
    }
    
    public string HighestRated(string cuisine)
    {
        var que = items[cuisine];
        while (que.Count > 0)
        {
            (int _, string f, int i) = que.Peek();

            if (time[f] != i)
            {
                que.Dequeue();
            }
            else
            {
                return f;
            }
        }

        return "";
    }
}