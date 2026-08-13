using System;

class Program
{
    static void TailRecursion(int n)
    {
        if (n == 0)
            return;

        Console.WriteLine(n);   
        TailRecursion(n - 1);   
    }

    static void Main()
    {
        TailRecursion(5);
    }
}