namespace MyCalendar;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input
        // ["MyCalendar", "book", "book", "book"]
        // [[], [10, 20], [15, 25], [20, 30]]
        // Output
        // [null, true, false, true]
        //
        // Explanation
        // MyCalendar myCalendar = new MyCalendar();
        // myCalendar.book(10, 20); // return True
        // myCalendar.book(15, 25); // return False, It can not be booked because time 15 is already booked by another event.
        // myCalendar.book(20, 30); // return True, The event can be booked, as the first event takes every time less than 20, but not including 20.

        MyCalendar cal1 = new MyCalendar();
        bool a1 = cal1.Book(10, 20);
        bool a2 = cal1.Book(15, 25);
        bool a3 = cal1.Book(20, 30);

        Console.WriteLine($"{a1} {a2} {a3}");
    }
}

class MyCalendar
{
    private List<int[]> Calendar = new();

    public bool Book(int start, int end)
    {
        foreach (int[] eventSpan in Calendar)
        {
            if (eventSpan[0] < end && start < eventSpan[1]) return false;
        }

        Calendar.Add([start, end]);
        return true;
    }
}