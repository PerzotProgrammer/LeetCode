namespace MyCircularDeque;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input
        // ["MyCircularDeque", "insertLast", "insertLast", "insertFront", "insertFront", "getRear", "isFull", "deleteLast", "insertFront", "getFront"]
        // [[3], [1], [2], [3], [4], [], [], [], [4], []]
        // Output
        // [null, true, true, true, false, 2, true, true, true, 4]
        //
        // Explanation
        // MyCircularDeque myCircularDeque = new MyCircularDeque(3);
        // myCircularDeque.insertLast(1);  // return True
        // myCircularDeque.insertLast(2);  // return True
        // myCircularDeque.insertFront(3); // return True
        // myCircularDeque.insertFront(4); // return False, the queue is full.
        // myCircularDeque.getRear();      // return 2
        // myCircularDeque.isFull();       // return True
        // myCircularDeque.deleteLast();   // return True
        // myCircularDeque.insertFront(4); // return True
        // myCircularDeque.getFront();     // return 4


        MyCircularDeque myCircularDeque = new MyCircularDeque(3);
        
        bool a1 = myCircularDeque.InsertLast(1);
        bool a2 = myCircularDeque.InsertLast(2);
        bool a3 = myCircularDeque.InsertFront(3);
        bool a4 = myCircularDeque.InsertFront(4);
        int a5 = myCircularDeque.GetRear();
        bool a6 = myCircularDeque.IsFull();
        bool a7 = myCircularDeque.DeleteLast();
        bool a8 = myCircularDeque.InsertFront(4);
        int a9 = myCircularDeque.GetFront();

        Console.WriteLine($"{a1} {a2} {a3} {a4} {a5} {a6} {a7} {a8} {a9}");
    }
}

public class MyCircularDeque
{
    private int[] Deque;
    private int Front;
    private int Rear;
    private int Size;
    private int Capacity;

    public MyCircularDeque(int k)
    {
        Capacity = k;
        Deque = new int[k];
        Front = 0;
        Rear = 0;
        Size = 0;
    }

    public bool InsertFront(int value)
    {
        if (IsFull()) return false;

        Front = (Front - 1 + Capacity) % Capacity;
        Deque[Front] = value;
        Size++;
        return true;
    }

    public bool InsertLast(int value)
    {
        if (IsFull()) return false;

        Deque[Rear] = value;
        Rear = (Rear + 1) % Capacity;
        Size++;
        return true;
    }

    public bool DeleteFront()
    {
        if (IsEmpty()) return false;

        Front = (Front + 1) % Capacity;
        Size--;
        return true;
    }

    public bool DeleteLast()
    {
        if (IsEmpty()) return false;

        Rear = (Rear - 1 + Capacity) % Capacity;
        Size--;
        return true;
    }

    public int GetFront()
    {
        if (IsEmpty()) return -1;

        return Deque[Front];
    }

    public int GetRear()
    {
        if (IsEmpty()) return -1;

        return Deque[(Rear - 1 + Capacity) % Capacity];
    }

    public bool IsEmpty()
    {
        return Size == 0;
    }

    public bool IsFull()
    {
        return Size == Capacity;
    }
}