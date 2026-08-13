using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public static long gridlandMetro(int n, int m, int k, List<List<int>> track)
    {
        long totalCells = (long)n * (long)m;
        Dictionary<int, List<Tuple<int, int>>> rowTracks = new Dictionary<int, List<Tuple<int, int>>>();
        
        foreach (var t in track)
        {
            int row = t[0];
            int c1 = t[1];
            int c2 = t[2];
            
            if (!rowTracks.ContainsKey(row))
            {
                rowTracks[row] = new List<Tuple<int, int>>();
            }
            rowTracks[row].Add(new Tuple<int, int>(c1, c2));
        }
        
        long totalTrackCells = 0;
        
        foreach (var kvp in rowTracks)
        {
            
            var sortedIntervals = kvp.Value.OrderBy(x => x.Item1).ToList();
            
            int currentStart = sortedIntervals[0].Item1;
            int currentEnd = sortedIntervals[0].Item2;
            
            for (int i = 1; i < sortedIntervals.Count; i++)
            {
                int nextStart = sortedIntervals[i].Item1;
                int nextEnd = sortedIntervals[i].Item2;
                
                if (nextStart <= currentEnd)
                {
                    currentEnd = Math.Max(currentEnd, nextEnd);
                }
                else
                {
                  
                    totalTrackCells += (long)(currentEnd - currentStart + 1);
                    currentStart = nextStart;
                    currentEnd = nextEnd;
                }
            }
            
            totalTrackCells += (long)(currentEnd - currentStart + 1);
        }
       
        return totalCells - totalTrackCells;
    }

    static void Main(string[] args)
    {
        
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
        int n = Convert.ToInt32(firstMultipleInput[0]);
        int m = Convert.ToInt32(firstMultipleInput[1]);
        int k = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> track = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            track.Add(Console.ReadLine().TrimEnd().Split(' ').Select(trackTemp => Convert.ToInt32(trackTemp)).ToList());
        }

        long result = gridlandMetro(n, m, k, track);
        Console.WriteLine(result);
    }
}
