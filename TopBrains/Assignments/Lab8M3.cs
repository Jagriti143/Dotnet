// using System;
// using System.Collections.Generic;

// class Program
// {
//     // Generic callback-driven method
//     static void ProcessBatch<T>(
//         List<T> items,
//         Action<T> onSuccess,
//         Action<T, string> onFailure,
//         Func<T, bool> validator)
//     {
//         foreach (T item in items)
//         {
//             if (validator(item))
//             {
//                 onSuccess(item);
//             }
//             else
//             {
//                 onFailure(item, "Validation failed.");
//             }
//         }
//     }

//     static void Main()
//     {
//         Console.WriteLine(
//             "===== LAB 8: Delegates as Callback Parameters =====");



//         List<int> numbers = new List<int>
//         {
//             10,
//             -5,
//             20,
//             -10,
//             30
//         };

//         Console.WriteLine("\nProcessing integers:");

//         ProcessBatch(
//             numbers,

//             // onSuccess
//             number =>
//             {
//                 Console.WriteLine(
//                     $"SUCCESS: {number} is valid.");
//             },

//             // onFailure
//             (number, reason) =>
//             {
//                 Console.WriteLine(
//                     $"FAILURE: {number} - {reason}");
//             },

//             // validator
//             number => number >= 0
//         );


//         List<string> names = new List<string>
//         {
//             "Alice",
//             "",
//             "Bob",
//             "   ",
//             "Charlie"
//         };

//         Console.WriteLine("\nProcessing strings:");

//         ProcessBatch(
//             names,

//             // onSuccess
//             name =>
//             {
//                 Console.WriteLine(
//                     $"SUCCESS: '{name}' is valid.");
//             },

//             // onFailure
//             (name, reason) =>
//             {
//                 Console.WriteLine(
//                     $"FAILURE: Empty/whitespace string - {reason}");
//             },

//             // validator
//             name => !string.IsNullOrWhiteSpace(name)
//         );
//     }
// }