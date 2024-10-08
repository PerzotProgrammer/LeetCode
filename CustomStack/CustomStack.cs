﻿namespace CustomStack;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input
        // ["CustomStack","push","push","pop","push","push","push","increment","increment","pop","pop","pop","pop"]
        // [[3],[1],[2],[],[2],[3],[4],[5,100],[2,100],[],[],[],[]]
        // Output
        // [null,null,null,2,null,null,null,null,null,103,202,201,-1]

        // Explanation
        // CustomStack stk = new CustomStack(3); // Stack is Empty []
        // stk.push(1);                          // stack becomes [1]
        // stk.push(2);                          // stack becomes [1, 2]
        // stk.pop();                            // return 2 --> Return top of the stack 2, stack becomes [1]
        // stk.push(2);                          // stack becomes [1, 2]
        // stk.push(3);                          // stack becomes [1, 2, 3]
        // stk.push(4);                          // stack still [1, 2, 3], Do not add another elements as size is 4
        // stk.increment(5, 100);                // stack becomes [101, 102, 103]
        // stk.increment(2, 100);                // stack becomes [201, 202, 103]
        // stk.pop();                            // return 103 --> Return top of the stack 103, stack becomes [201, 202]
        // stk.pop();                            // return 202 --> Return top of the stack 202, stack becomes [201]
        // stk.pop();                            // return 201 --> Return top of the stack 201, stack becomes []
        // stk.pop();                            // return -1 --> Stack is empty return -1.


        CustomStack stk = new CustomStack(3);
        stk.Push(1);
        stk.Push(2);
        int a1 = stk.Pop();
        stk.Push(2);
        stk.Push(3);
        stk.Push(4);
        stk.Increment(5, 100);
        stk.Increment(2, 100);
        int a2 = stk.Pop();
        int a3 = stk.Pop();
        int a4 = stk.Pop();
        int a5 = stk.Pop();

        Console.WriteLine($"{a1} {a2} {a3} {a4} {a5}");
    }
}

class CustomStack
{
    private int[] StackArray;
    private int TopIndex;

    public CustomStack(int maxSize)
    {
        StackArray = new int[maxSize];
        TopIndex = -1;
    }

    public void Push(int value)
    {
        if (TopIndex < StackArray.Length - 1) StackArray[++TopIndex] = value;
    }

    public int Pop()
    {
        if (TopIndex >= 0) return StackArray[TopIndex--];

        return -1;
    }

    public void Increment(int maxRange, int value)
    {
        int limit = Math.Min(maxRange, TopIndex + 1);
        for (int i = 0; i < limit; i++) StackArray[i] += value;
    }
}