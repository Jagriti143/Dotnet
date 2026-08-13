using System;

class Program
{
    static void MethodA(int n)
    {
        if (n <= 0)
        {
            return;
        }

        Console.WriteLine("Method A : " + n);

        MethodB(n - 1);
    }

    static void MethodB(int n)
    {
        if (n <= 0)
        {
            return;
        }

        Console.WriteLine("Method B : " + n);

        MethodA(n - 1);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Indirect Recursion Example");
        MethodA(5);

    }
}