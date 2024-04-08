namespace CountStudents;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: students = [1,1,0,0], sandwiches = [0,1,0,1]
        // Output: 0 
        // Explanation:
        // - Front student leaves the top sandwich and returns to the end of the line making students = [1,0,0,1].
        // - Front student leaves the top sandwich and returns to the end of the line making students = [0,0,1,1].
        // - Front student takes the top sandwich and leaves the line making students = [0,1,1] and sandwiches = [1,0,1].
        // - Front student leaves the top sandwich and returns to the end of the line making students = [1,1,0].
        // - Front student takes the top sandwich and leaves the line making students = [1,0] and sandwiches = [0,1].
        // - Front student leaves the top sandwich and returns to the end of the line making students = [0,1].
        // - Front student takes the top sandwich and leaves the line making students = [1] and sandwiches = [1].
        // - Front student takes the top sandwich and leaves the line making students = [] and sandwiches = [].
        // Hence all students are able to eat.

        // Example 2:
        //
        // Input: students = [1,1,1,0,0,1], sandwiches = [1,0,0,0,1,1]
        // Output: 3

        Solution solution = new();

        Console.WriteLine(solution.CountStudents([1, 1, 0, 0], [0, 1, 0, 1]));
        Console.WriteLine(solution.CountStudents([1, 1, 1, 0, 0, 1], [1, 0, 0, 0, 1, 1]));
    }

    public int CountStudents(int[] students, int[] sandwiches)
    {
        Queue<int> studentQueue = new();
        Stack<int> sandwichStack = new();

        for (int i = 0; i < students.Length; i++)
        {
            sandwichStack.Push(sandwiches[students.Length - i - 1]);
            studentQueue.Enqueue(students[i]);
        }

        int lastServed = 0;
        while (studentQueue.Count > 0 && lastServed < studentQueue.Count)
        {
            if (sandwichStack.Peek() == studentQueue.Peek())
            {
                sandwichStack.Pop();
                studentQueue.Dequeue();
                lastServed = 0;
            }
            else
            {
                studentQueue.Enqueue(studentQueue.Dequeue());
                lastServed++;
            }
        }

        return studentQueue.Count;
    }
}