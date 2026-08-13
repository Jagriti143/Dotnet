// using System;

// class Program
// {
//     static int JumpSearch(int[] arr, int target)
//     {
//         int n = arr.Length;
//         int step = (int)Math.Sqrt(n);
//         int prev = 0;

//         while (prev < n && arr[Math.Min(step, n) - 1] < target)
//         {
//             prev = step;
//             step += (int)Math.Sqrt(n);

//             if (prev >= n)
//                 return -1;
//         }

//         for (int i = prev; i < Math.Min(step, n); i++)
//             if (arr[i] == target)
//                 return i;

//         return -1;
//     }

//     static void Main()
//     {
//         int[] arr = { 10, 20, 30, 40, 50, 60, 70 };
//         int target = 50;

//         int index = JumpSearch(arr, target);

//         Console.WriteLine(index != -1
//             ? $"Found at index {index}"
//             : "Not Found");
//     }
// }