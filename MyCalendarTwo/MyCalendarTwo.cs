namespace MyCalendarTwo;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input
        // ["MyCalendarTwo", "book", "book", "book", "book", "book", "book"]
        // [[], [10, 20], [50, 60], [10, 40], [5, 15], [5, 10], [25, 55]]
        // Output
        // [null, true, true, true, false, true, true]
        //
        // Explanation
        // MyCalendarTwo myCalendarTwo = new MyCalendarTwo();
        // myCalendarTwo.book(10, 20); // return True, The event can be booked. 
        // myCalendarTwo.book(50, 60); // return True, The event can be booked. 
        // myCalendarTwo.book(10, 40); // return True, The event can be double booked. 
        // myCalendarTwo.book(5, 15);  // return False, The event cannot be booked, because it would result in a triple booking.
        // myCalendarTwo.book(5, 10); // return True, The event can be booked, as it does not use time 10 which is already double booked.
        // myCalendarTwo.book(25, 55); // return True, The event can be booked, as the time in [25, 40) will be double booked with the third event, the time [40, 50) will be single booked, and the time [50, 55) will be double booked with the second event.

        MyCalendarTwo cal1 = new();
        
        bool a1 = cal1.Book(10, 20);
        bool a2 = cal1.Book(50, 60);
        bool a3 = cal1.Book(10, 40);
        bool a4 = cal1.Book(5, 15);
        bool a5 = cal1.Book(5, 10);
        bool a6 = cal1.Book(25, 55);

        Console.WriteLine($"{a1} {a2} {a3} {a4} {a5} {a6}");
    }
}

class MyCalendarTwo
{
    private SortedDictionary<int, int> Timeline;

    public MyCalendarTwo()
    {
        Timeline = new();
    }

    public bool Book(int start, int end)
    {
        Timeline.TryAdd(start, 0);
        Timeline[start]++;


        Timeline.TryAdd(end, 0);
        Timeline[end]--;


        int activeEvents = 0;
        foreach (int key in Timeline.Keys)
        {
            activeEvents += Timeline[key];
            if (activeEvents >= 3)
            {
                Timeline[start]--;
                if (Timeline[start] == 0) Timeline.Remove(start);

                Timeline[end]++;
                if (Timeline[end] == 0) Timeline.Remove(end);

                return false;
            }
        }

        return true;
    }
}