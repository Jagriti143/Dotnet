using System;

class Program
{
    static void Pattern1(int n)
    {
        if (n == 0)
            return;

        Pattern1(n - 1);
        Console.Write(n + " ");
    }

    static void Main()
    {
        Pattern1(5);
    }
}
