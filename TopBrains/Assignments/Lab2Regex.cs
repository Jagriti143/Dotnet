// using System;
// using System.Linq;
// using System.Text.RegularExpressions;

// class Program
// {
//     static void Main()
//     {
//         // ---------------------------------------
//         // 1. Extract Order Numbers
//         // ---------------------------------------

//         string text =
//             "Order #4521 was shipped. order #99 is pending. ORDER #12345 was cancelled.";

//         string orderPattern = @"\border\s+#(\d+)";

//         MatchCollection matches =
//             Regex.Matches(
//                 text,
//                 orderPattern,
//                 RegexOptions.IgnoreCase
//             );

//         Console.Write("Order numbers found: ");

//         for (int i = 0; i < matches.Count; i++)
//         {
//             Console.Write(matches[i].Groups[1].Value);

//             if (i < matches.Count - 1)
//                 Console.Write(", ");
//         }

//         Console.WriteLine();


//         // ---------------------------------------
//         // 2. Mask Credit Card
//         // ---------------------------------------

//         string cardText =
//             "Card on file: 4111-1111-1111-1234";

//         string cardPattern =
//             @"\b(\d{4})[- ](\d{4})[- ](\d{4})[- ](\d{4})\b";

//         string maskedCard = Regex.Replace(
//             cardText,
//             cardPattern,
//             "XXXX-XXXX-XXXX-$4"
//         );

//         Console.WriteLine($"Masked card: {maskedCard}");


//         // ---------------------------------------
//         // 3. Reformat Name
//         // ---------------------------------------

//         string names = "Smith, John";

//         string namePattern =
//             @"^\s*([^,]+),\s*(.+?)\s*$";

//         string reformattedName =
//             Regex.Replace(names, namePattern, "$2 $1");

//         Console.WriteLine(
//             $"Reformatted name: {reformattedName}"
//         );


//         // ---------------------------------------
//         // 4. Split Tags
//         // ---------------------------------------

//         string tags =
//             "red, blue;green , yellow";

//         string[] cleanTags = Regex
//             .Split(tags, @"[,;]")
//             .Select(tag => tag.Trim())
//             .Where(tag => tag.Length > 0)
//             .ToArray();

//         Console.WriteLine(
//             $"Tags: [{string.Join(", ", cleanTags)}]"
//         );
//     }
// }