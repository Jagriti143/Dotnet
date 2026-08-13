// using System;
// using System.Globalization;
// using System.Text;

// static class StringToolkit
// {
//     // 1. Reverse a string
//     public static string Reverse(string input)
//     {
//         if (input == null)
//         {
//             return "";
//         }

//         StringBuilder result = new StringBuilder();

//         for (int i = input.Length - 1; i >= 0; i--)
//         {
//             result.Append(input[i]);
//         }

//         return result.ToString();
//     }

//     // 2. Count a particular character
//     public static int CountChar(string text, char searchChar)
//     {
//         if (string.IsNullOrEmpty(text))
//         {
//             return 0;
//         }

//         int count = 0;

//         foreach (char c in text)
//         {
//             if (c == searchChar)
//             {
//                 count++;
//             }
//         }

//         return count;
//     }

//     // 3. Remove duplicate characters
//     public static string RemoveDuplicates(string input)
//     {
//         if (string.IsNullOrEmpty(input))
//         {
//             return "";
//         }

//         StringBuilder result = new StringBuilder();

//         foreach (char c in input)
//         {
//             if (!result.ToString().Contains(c.ToString()))
//             {
//                 result.Append(c);
//             }
//         }

//         return result.ToString();
//     }

//     // 4. Check palindrome
   
//     public static bool IsPalindrome(string input)
//     {
//         if (string.IsNullOrEmpty(input))
//         {
//             return true;
//         }

//         StringBuilder cleaned = new StringBuilder();

//         foreach (char c in input)
//         {
//             if (c != ' ')
//             {
//                 cleaned.Append(char.ToLower(c));
//             }
//         }

//         string text = cleaned.ToString();

//         int left = 0;
//         int right = text.Length - 1;

//         while (left < right)
//         {
//             if (text[left] != text[right])
//             {
//                 return false;
//             }

//             left++;
//             right--;
//         }

//         return true;
//     }

//     // 5. Convert to title case
//     public static string ToTitleCase(string input)
//     {
//         if (string.IsNullOrWhiteSpace(input))
//         {
//             return "";
//         }

//         TextInfo textInfo =
//             CultureInfo.CurrentCulture.TextInfo;

//         return textInfo.ToTitleCase(
//             input.ToLower()
//         );
//     }

//     // 6. Extract only numbers
//     public static string ExtractNumbers(string input)
//     {
//         if (string.IsNullOrEmpty(input))
//         {
//             return "";
//         }

//         StringBuilder result = new StringBuilder();

//         foreach (char c in input)
//         {
//             if (char.IsDigit(c))
//             {
//                 result.Append(c);
//             }
//         }

//         return result.ToString();
//     }
// }


// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("===== STRING MANIPULATION TOOLKIT =====");
//         Console.WriteLine();

//         // Reverse
//         string reversed = StringToolkit.Reverse("Hello");

//         Console.WriteLine(
//             $"Reverse(\"Hello\") -> \"{reversed}\""
//         );

//         // Count character
//         int count = StringToolkit.CountChar(
//             "banana",
//             'a'
//         );

//         Console.WriteLine(
//             $"CountChar(\"banana\", 'a') -> {count}"
//         );

//         // Remove duplicates
//         string unique = StringToolkit.RemoveDuplicates(
//             "mississippi"
//         );

//         Console.WriteLine(
//             $"RemoveDuplicates(\"mississippi\") -> \"{unique}\""
//         );

//         // Palindrome
//         bool palindrome = StringToolkit.IsPalindrome(
//             "race car"
//         );

//         Console.WriteLine(
//             $"IsPalindrome(\"race car\") -> {palindrome}"
//         );

//         // Title case
//         string title = StringToolkit.ToTitleCase(
//             "hello training team"
//         );

//         Console.WriteLine(
//             $"ToTitleCase(\"hello training team\") -> \"{title}\""
//         );

//         // Extract numbers
//         string numbers = StringToolkit.ExtractNumbers(
//             "Order #4521,qty 3"
//         );

//         Console.WriteLine(
//             $"ExtractNumbers(\"Order #4521, qty 3\") -> \"{numbers}\""
//         );
//     }
// }