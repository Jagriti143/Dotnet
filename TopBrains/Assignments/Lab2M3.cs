// using System;
// using System.Collections.Generic;

// class Program
// {
//     // 1. Custom delegate
//     public delegate double Discount(double price);

//     // 2. Methods matching the delegate signature
//     static double NoDiscount(double price)
//     {
//         return price;
//     }

//     static double TenPercentOff(double price)
//     {
//         return price * 0.90;
//     }

//     static double HalfOff(double price)
//     {
//         return price * 0.50;
//     }

//     // 3. Method accepting a delegate
//     static double ApplyDiscount(double price, Discount discount)
//     {
//         return discount(price);
//     }

//     static void Main()
//     {
//         Console.WriteLine("===== LAB 2: Declaring and Using Delegates =====");

//         double price = 1000;

//         // 4. Direct delegate usage
//         Discount noDiscount = NoDiscount;
//         Discount tenPercent = TenPercentOff;
//         Discount halfOff = HalfOff;

//         Console.WriteLine($"Original price: {price}");

//         Console.WriteLine(
//             $"No discount: {ApplyDiscount(price, noDiscount):F2}");

//         Console.WriteLine(
//             $"10% discount: {ApplyDiscount(price, tenPercent):F2}");

//         Console.WriteLine(
//             $"50% discount: {ApplyDiscount(price, halfOff):F2}");

//         // 5. Store delegates in a List
//         List<Discount> discounts = new List<Discount>
//         {
//             NoDiscount,
//             TenPercentOff,
//             HalfOff
//         };

//         Console.WriteLine("\nApplying discounts from delegate list:");

//         foreach (Discount discount in discounts)
//         {
//             double result = discount(price);
//             Console.WriteLine($"Result: {result:F2}");
//         }
//     }
// }