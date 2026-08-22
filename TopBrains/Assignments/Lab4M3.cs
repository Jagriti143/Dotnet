// using System;
// using System.Collections.Generic;

// class Program
// {
//     // 4. Generic Repeat method
//     static void Repeat(int times, Action action)
//     {
//         for (int i = 0; i < times; i++)
//         {
//             action();
//         }
//     }

//     // Prime number check
//     static bool IsPrime(int number)
//     {
//         if (number < 2)
//         {
//             return false;
//         }

//         for (int i = 2; i * i <= number; i++)
//         {
//             if (number % i == 0)
//             {
//                 return false;
//             }
//         }

//         return true;
//     }

//     static void Main()
//     {
//         Console.WriteLine("===== LAB 4: Func, Action, Predicate =====");

//         // 1. Func for addition
//         Func<int, int, int> addition =
//             (a, b) => a + b;

//         // Func for multiplication
//         Func<int, int, int> multiplication =
//             (a, b) => a * b;

//         Console.WriteLine($"Addition: {addition(10, 5)}");
//         Console.WriteLine($"Multiplication: {multiplication(10, 5)}");

//         // 2. Action<string> with timestamp
//         Action<string> logMessage =
//             message =>
//                 Console.WriteLine(
//                     $"[{DateTime.Now:HH:mm:ss}] {message}");

//         logMessage("Application started.");
//         logMessage("Processing data...");

//         // 3. Predicate<int>
//         Predicate<int> isPrime = IsPrime;

//         List<int> numbers = new List<int>();

//         for (int i = 1; i <= 50; i++)
//         {
//             numbers.Add(i);
//         }

//         List<int> primes = numbers.FindAll(isPrime);

//         Console.WriteLine("\nPrime numbers from 1 to 50:");

//         foreach (int prime in primes)
//         {
//             Console.Write($"{prime} ");
//         }

//         Console.WriteLine();

//         // 4. Repeat with Action
//         Console.WriteLine("\nRepeat demonstration:");

//         Repeat(5, () =>
//         {
//             Console.WriteLine("Tick");
//         });
//     }
// }