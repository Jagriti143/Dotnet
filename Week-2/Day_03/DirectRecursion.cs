using System;

class Program
{
    static void PrintEven(int n)
    {
        if (n > 10)
        {
            return;
        }

        Console.WriteLine(n);

        PrintEven(n + 2);
    }

    static void PrintOdd(int n)
    {
        if (n > 10)
        {
            return;
        }

        Console.WriteLine(n);

        PrintOdd(n + 2);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Even Numbers:");
        PrintEven(2);

        Console.WriteLine();

        Console.WriteLine("Odd Numbers:");
        PrintOdd(1);
    }
}