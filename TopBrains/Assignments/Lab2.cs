// using System;
// using System.Diagnostics;
// using System.Text;

// class Program
// {
//     static string BuildWithString(int count)
//     {
//         string result = "";

//         for (int i = 0; i < count; i++)
//         {
//             result += i.ToString();
//         }

//         return result;
//     }

//     static string BuildWithStringBuilder(int count)
//     {
//         StringBuilder sb = new StringBuilder(count * 5);

//         for (int i = 0; i < count; i++)
//         {
//             sb.Append(i.ToString());
//         }

//         return sb.ToString();
//     }

//     static void RunBenchmark(int count)
//     {
//         // Warm-up
//         BuildWithString(1000);
//         BuildWithStringBuilder(1000);

//         // Test string concatenation
//         Stopwatch stopwatch = Stopwatch.StartNew();

//         string stringResult = BuildWithString(count);

//         stopwatch.Stop();

//         long stringTime = stopwatch.ElapsedMilliseconds;

//         // Test StringBuilder
//         stopwatch.Restart();

//         string stringBuilderResult = BuildWithStringBuilder(count);

//         stopwatch.Stop();

//         long stringBuilderTime = stopwatch.ElapsedMilliseconds;


//         Console.WriteLine(
//             $"String concatenation ({count:N0}): {stringTime} ms"
//         );

//         Console.WriteLine(
//             $"StringBuilder ({count:N0}):        {stringBuilderTime} ms"
//         );

//         if (stringBuilderTime > 0)
//         {
//             double ratio =
//                 (double)stringTime / stringBuilderTime;

//             Console.WriteLine(
//                 $"StringBuilder is roughly {ratio:F2}x faster on this run"
//             );
//         }
//         else
//         {
//             Console.WriteLine(
//                 "StringBuilder completed too quickly to calculate ratio."
//             );
//         }

//         Console.WriteLine(
//             $"Results equal: {stringResult == stringBuilderResult}"
//         );
//     }

//     static void Main()
//     {

//         // Lab requirement: 50,000
//         RunBenchmark(50_000);

//         // Lab requirement: 200,000
//         RunBenchmark(200_000);
//     }
// }