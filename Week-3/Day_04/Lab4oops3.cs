// using System;

// public static class StringUtils
// {
//     public static bool IsPalindrome(string s)
//     {
//         if (string.IsNullOrEmpty(s))
//         {
//             return true;
//         }

//         int left = 0;
//         int right = s.Length - 1;

//         while (left < right)
//         {
//             if (s[left] != s[right])
//             {
//                 return false;
//             }

//             left++;
//             right--;
//         }

//         return true;
//     }

//     public static string Reverse(string s)
//     {
//         char[] characters = s.ToCharArray();

//         Array.Reverse(characters);

//         return new string(characters);
//     }

//     public static int WordCount(string s)
//     {
//         if (string.IsNullOrWhiteSpace(s))
//         {
//             return 0;
//         }

//         return s.Split(
//             ' ',
//             StringSplitOptions.RemoveEmptyEntries
//         ).Length;
//     }
// }

// public class TrackedWidget
// {
//     public Guid InstanceId { get; }

//     public static int LiveCount { get; private set; }

//     private bool _disposed;

//     public TrackedWidget()
//     {
//         InstanceId = Guid.NewGuid();

//         LiveCount++;
//     }

//     public void Dispose()
//     {
//         if (!_disposed)
//         {
//             LiveCount--;
//             _disposed = true;
//         }
//     }

//     public void PrintInfo()
//     {
//         Console.WriteLine(
//             $"Widget {InstanceId}: LiveCount={LiveCount}"
//         );
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine(
//             $"IsPalindrome(\"racecar\") -> " +
//             $"{StringUtils.IsPalindrome("racecar")}"
//         );

//         Console.WriteLine(
//             $"Reverse(\"Hello\") -> " +
//             $"{StringUtils.Reverse("Hello")}"
//         );

//         Console.WriteLine(
//             $"WordCount(\"the quick brown fox\") -> " +
//             $"{StringUtils.WordCount("the quick brown fox")}"
//         );

//         // This would NOT compile:
//         // StringUtils utils = new StringUtils();

//         TrackedWidget widget1 = new TrackedWidget();
//         TrackedWidget widget2 = new TrackedWidget();
//         TrackedWidget widget3 = new TrackedWidget();

//         Console.WriteLine(
//             $"LiveCount after creating 3 widgets: " +
//             $"{TrackedWidget.LiveCount}"
//         );

//         widget1.PrintInfo();
//         widget2.PrintInfo();
//         widget3.PrintInfo();

//         widget1.Dispose();
//         widget2.Dispose();

//         Console.WriteLine(
//             $"LiveCount after disposing 2: " +
//             $"{TrackedWidget.LiveCount}"
//         );
//     }
// }