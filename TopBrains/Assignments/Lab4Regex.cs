// using System;
// using System.Text.RegularExpressions;

// public static class PatternLibrary
// {
//     // Email pattern
//     public static readonly Regex Email =
//         new Regex(
//             @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
//             RegexOptions.Compiled
//         );

//     // US phone number
//     public static readonly Regex UsPhone =
//         new Regex(
//             @"^\d{3}-\d{3}-\d{4}$",
//             RegexOptions.Compiled
//         );

//     // Hex color
//     public static readonly Regex HexColor =
//         new Regex(
//             @"^#[0-9A-Fa-f]{6}$",
//             RegexOptions.Compiled
//         );


//     public static bool IsValidEmail(string input)
//     {
//         return Email.IsMatch(input);
//     }

//     public static bool IsValidPhone(string input)
//     {
//         return UsPhone.IsMatch(input);
//     }

//     public static bool IsValidHexColor(string input)
//     {
//         return HexColor.IsMatch(input);
//     }
// }


// class Program
// {
//     static void Main()
//     {
//         // ---------------------------------------
//         // 1. IgnoreCase
//         // ---------------------------------------

//         string pattern = @"^hello$";

//         bool withoutIgnoreCase =
//             Regex.IsMatch("HELLO", pattern);

//         bool withIgnoreCase =
//             Regex.IsMatch(
//                 "HELLO",
//                 pattern,
//                 RegexOptions.IgnoreCase
//             );

//         Console.WriteLine(
//             $"IgnoreCase off: {withoutIgnoreCase}, " +
//             $"IgnoreCase on: {withIgnoreCase}"
//         );


//         // ---------------------------------------
//         // 2. Multiline
//         // ---------------------------------------

//         string lines =
//             "apple\nbanana\norange";

//         int withoutMultiline =
//             Regex.Matches(
//                 lines,
//                 @"^",
//                 RegexOptions.None
//             ).Count;

//         int withMultiline =
//             Regex.Matches(
//                 lines,
//                 @"^",
//                 RegexOptions.Multiline
//             ).Count;

//         Console.WriteLine(
//             $"Line-start matches WITHOUT Multiline: " +
//             $"{withoutMultiline}"
//         );

//         Console.WriteLine(
//             $"Line-start matches WITH Multiline: " +
//             $"{withMultiline}"
//         );


//         // ---------------------------------------
//         // 3. PatternLibrary tests
//         // ---------------------------------------

//         Console.WriteLine(
//             $"IsValidEmail(\"a@b.com\"): " +
//             $"{PatternLibrary.IsValidEmail("a@b.com")}, " +

//             $"IsValidEmail(\"not-an-email\"): " +
//             $"{PatternLibrary.IsValidEmail("not-an-email")}"
//         );

//         Console.WriteLine(
//             $"IsValidPhone(\"555-123-4567\"): " +
//             $"{PatternLibrary.IsValidPhone("555-123-4567")}, " +

//             $"IsValidPhone(\"5551234567\"): " +
//             $"{PatternLibrary.IsValidPhone("5551234567")}"
//         );

//         Console.WriteLine(
//             $"IsValidHexColor(\"#1A2B3C\"): " +
//             $"{PatternLibrary.IsValidHexColor("#1A2B3C")}, " +

//             $"IsValidHexColor(\"1A2B3C\"): " +
//             $"{PatternLibrary.IsValidHexColor("1A2B3C")}"
//         );
//     }
// }