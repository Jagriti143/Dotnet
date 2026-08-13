// using System;

// class Program
// {
//     static int LinearSearch(int[] arr, int target)
//     {
//         for (int i = 0; i < arr.Length; i++)
//             if (arr[i] == target)
//                 return i;

//         return -1;
//     }

//     static void Main()
//     {
//         int[] arr = { 10, 20, 30, 40, 50 };
//         int target = 30;

//         int index = LinearSearch(arr, target);

//         Console.WriteLine(index != -1
//             ? $"Found at index {index}"
//             : "Not Found");
//     }
// }