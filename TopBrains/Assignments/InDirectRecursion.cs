using System;

class Program
{
   
    static bool IsPositiveChain(int n)
    {
        
        if (n == 0)
            return true;

       
        if (n > 0)
            return IsNegativeChain(n - 1);

        return false;
    }

    
    static bool IsNegativeChain(int n)
    {
        
        if (n == 0)
            return true;

        if (n < 0)
            return IsPositiveChain(n + 1);

        return false;
    }

    static void Main()
    {
        Console.WriteLine(IsPositiveChain(4));   
        Console.WriteLine(IsNegativeChain(-3));  
        Console.WriteLine(IsPositiveChain(-2));  
        Console.WriteLine(IsNegativeChain(5));  
    }
}