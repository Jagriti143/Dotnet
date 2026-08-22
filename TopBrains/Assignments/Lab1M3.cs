// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("===== LAB 1: var vs Explicit Types vs dynamic =====");

//         // 1. Same value declared using var, explicit type, and dynamic
//         var count = 10;
//         int countExplicit = 10;
//         dynamic countDynamic = 10;

//         Console.WriteLine($"var value: {count}");
//         Console.WriteLine($"var type: {count.GetType()}");

//         Console.WriteLine($"Explicit value: {countExplicit}");
//         Console.WriteLine($"Explicit type: {countExplicit.GetType()}");

//         Console.WriteLine($"dynamic value: {countDynamic}");
//         Console.WriteLine($"dynamic type: {countDynamic.GetType()}");

//         // 2. dynamic can change its runtime type
//         countDynamic = "now text";

//         Console.WriteLine($"\nDynamic value after changing type: {countDynamic}");
//         Console.WriteLine($"Dynamic runtime type: {countDynamic.GetType()}");

//         try
//         {
//             // This compiles because countDynamic is dynamic,
//             // but fails at runtime because string + int is invalid.
//             var result = countDynamic + 5;

//             Console.WriteLine($"Result: {result}");
//         }
//         catch (RuntimeBinderException ex)
//         {
//             Console.WriteLine("\nRuntime exception caught:");
//             Console.WriteLine(ex.Message);
//         }

//         // 3. Anonymous type
//         var point = new { X = 3, Y = 7 };

//         Console.WriteLine("\nAnonymous type:");
//         Console.WriteLine($"X = {point.X}");
//         Console.WriteLine($"Y = {point.Y}");

        
//     }
// }
