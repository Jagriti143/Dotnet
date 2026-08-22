// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("===== LAB 7: Loop Variable Capture =====");

//         List<Action> buggyActions = new List<Action>();

//         for (int i = 0; i < 3; i++)
//         {
//             buggyActions.Add(() =>
//             {
//                 Console.WriteLine($"for loop index: {i}");
//             });
//         }

//         Console.WriteLine("\nBuggy for-loop output:");

//         foreach (Action action in buggyActions)
//         {
//             action();
//         }

       

//         List<Action> fixedActions = new List<Action>();

//         for (int i = 0; i < 3; i++)
//         {
//             int copy = i;

//             fixedActions.Add(() =>
//             {
//                 Console.WriteLine($"for loop index: {copy}");
//             });
//         }

//         Console.WriteLine("\nFixed for-loop output:");

//         foreach (Action action in fixedActions)
//         {
//             action();
//         }

        

//         List<Action> foreachActions = new List<Action>();

//         foreach (int number in new[] { 0, 1, 2 })
//         {
//             foreachActions.Add(() =>
//             {
//                 Console.WriteLine(
//                     $"foreach value: {number}");
//             });
//         }

//         Console.WriteLine("\nforeach output:");

//         foreach (Action action in foreachActions)
//         {
//             action();
//         }

        
//     }
// }