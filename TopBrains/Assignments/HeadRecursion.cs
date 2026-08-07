using System;

class Program
{
    static void SumDigitsReversed(int n)
    {
        if (n == 0)
            return;

        SumDigitsReversed(n / 10);
        Console.Write(n % 10);
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        SumDigitsReversed(n);
    }
}
