using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    /*
     * Complete the 'truckTour' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY petrolpumps as parameter.
     */
    public static int truckTour(List<List<int>> petrolpumps)
    {
        int startingPump = 0;
        int currentPetrol = 0;

        for (int i = 0; i < petrolpumps.Count; i++)
        {
            int petrolReceived = petrolpumps[i][0];
            int distanceToNext = petrolpumps[i][1];

            currentPetrol += petrolReceived - distanceToNext;

            if (currentPetrol < 0)
            {
                startingPump = i + 1;
                currentPetrol = 0;
            }
        }

        return startingPump;
    }
}


class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> petrolpumps = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            petrolpumps.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(petrolpumpsTemp => Convert.ToInt32(petrolpumpsTemp)).ToList());
        }

        int result = Result.truckTour(petrolpumps);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
