namespace MostBookedIII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 2, meetings = [[0,10],[1,5],[2,7],[3,4]]
        // Output: 0
        // Explanation:
        // - At time 0, both rooms are not being used. The first meeting starts in room 0.
        // - At time 1, only room 1 is not being used. The second meeting starts in room 1.
        // - At time 2, both rooms are being used. The third meeting is delayed.
        // - At time 3, both rooms are being used. The fourth meeting is delayed.
        // - At time 5, the meeting in room 1 finishes. The third meeting starts in room 1 for the time period [5,10).
        // - At time 10, the meetings in both rooms finish. The fourth meeting starts in room 0 for the time period [10,11).
        // Both rooms 0 and 1 held 2 meetings, so we return 0. 

        // Example 2:
        //
        // Input: n = 3, meetings = [[1,20],[2,10],[3,5],[4,9],[6,8]]
        // Output: 1
        // Explanation:
        // - At time 1, all three rooms are not being used. The first meeting starts in room 0.
        // - At time 2, rooms 1 and 2 are not being used. The second meeting starts in room 1.
        // - At time 3, only room 2 is not being used. The third meeting starts in room 2.
        // - At time 4, all three rooms are being used. The fourth meeting is delayed.
        // - At time 5, the meeting in room 2 finishes. The fourth meeting starts in room 2 for the time period [5,10).
        // - At time 6, all three rooms are being used. The fifth meeting is delayed.
        // - At time 10, the meetings in rooms 1 and 2 finish. The fifth meeting starts in room 1 for the time period [10,12).
        // Room 0 held 1 meeting while rooms 1 and 2 each held 2 meetings, so we return 1. 

        Solution solution = new();

        Console.WriteLine(solution.MostBooked(2, [[0, 10], [1, 5], [2, 7], [3, 4]]));
        Console.WriteLine(solution.MostBooked(3, [[1, 20], [2, 10], [3, 5], [4, 9], [6, 8]]));
    }

    public int MostBooked(int n, int[][] meetings)
    {
        long[] roomAvailabilityTime = new long[n];
        int[] meetingCount = new int[n];

        Array.Sort(meetings, (a, b) => a[0] - b[0]);

        for (int i = 0; i < meetings.Length; i++)
        {
            int start = meetings[i][0];
            int end = meetings[i][1];
            long minRoomAvailabilityTime = long.MaxValue;
            int minAvailableTimeRoom = 0;
            bool foundUnusedRoom = false;

            for (int j = 0; j < n; j++)
            {
                if (roomAvailabilityTime[j] <= start)
                {
                    foundUnusedRoom = true;
                    meetingCount[j]++;
                    roomAvailabilityTime[j] = end;
                    break;
                }

                if (minRoomAvailabilityTime > roomAvailabilityTime[j])
                {
                    minRoomAvailabilityTime = roomAvailabilityTime[j];
                    minAvailableTimeRoom = j;
                }
            }

            if (!foundUnusedRoom)
            {
                roomAvailabilityTime[minAvailableTimeRoom] += end - start;
                meetingCount[minAvailableTimeRoom]++;
            }
        }

        int maxMeetingCount = 0;
        int maxMeetingCountRoom = 0;
        for (int i = 0; i < n; i++)
        {
            if (meetingCount[i] > maxMeetingCount)
            {
                maxMeetingCount = meetingCount[i];
                maxMeetingCountRoom = i;
            }
        }

        return maxMeetingCountRoom;
    }
}