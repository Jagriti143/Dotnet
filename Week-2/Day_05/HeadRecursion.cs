using System;

class Program
{
    static void HeadRecursion(int n)
    {
        if (n == 0)
            return;

        HeadRecursion(n - 1);   
        Console.WriteLine(n);   
    }

    static void Main()
    {
        HeadRecursion(5);
    }
}
