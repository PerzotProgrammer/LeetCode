namespace MyQueue;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input
        //         ["MyQueue", "push", "push", "peek", "pop", "empty"]
        //     [[], [1], [2], [], [], []]
        // Output
        //     [null, null, null, 1, 1, false]
        //
        // Explanation
        // MyQueue myQueue = new MyQueue();
        // myQueue.push(1); // queue is: [1]
        // myQueue.push(2); // queue is: [1, 2] (leftmost is front of the queue)
        // myQueue.peek(); // return 1
        // myQueue.pop(); // return 1, queue is [2]
        // myQueue.empty(); // return false

        MyQueue myQueue = new();
        myQueue.Push(1);
        myQueue.Push(2);
        int ch1 = myQueue.Peek();
        int ch2 = myQueue.Pop();
        bool ch3 = myQueue.Empty();

        Console.WriteLine($"{ch1} {ch2} {ch3}");
    }
}

public class MyQueue
{
    private Stack<int> stack1;
    private Stack<int> stack2;

    public MyQueue()
    {
        stack1 = new();
        stack2 = new();
    }

    public void Push(int x)
    {
        stack1.Push(x);
    }

    public int Pop()
    {
        CheckSecStack();
        return stack2.Pop();
    }

    public int Peek()
    {
        CheckSecStack();
        return stack2.Peek();
    }

    public bool Empty()
    {
        return stack1.Count == 0 && stack2.Count == 0;
    }

    private void CheckSecStack()
    {
        if (stack2.Count == 0)
        {
            while (stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
        }
    }
}

// 
// Your MyQueue object will be instantiated and called as such:
// MyQueue obj = new MyQueue();
// obj.Push(x);
// int param_2 = obj.Pop();
// int param_3 = obj.Peek();
// bool param_4 = obj.Empty();
// 