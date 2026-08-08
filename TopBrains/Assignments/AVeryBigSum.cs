using System;
using System.Collections.Generic;

class Result
{
    public static long aVeryBigSum(List<long> ar)
    {
        long sum = 0;

        foreach (long num in ar)
        {
            sum += num;
        }

        return sum;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        List<long> ar = new List<long>(
            Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse)
        );

        long result = Result.aVeryBigSum(ar);

        Console.WriteLine(result);
    }
}