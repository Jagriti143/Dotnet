// using System;

// class Program
// {
//     static int BinarySearch(int[] arr, int target)
//     {
//         int left = 0, right = arr.Length - 1;

//         while (left <= right)
//         {
//             int mid = (left + right) / 2;

//             if (arr[mid] == target) return mid;
//             if (arr[mid] < target) left = mid + 1;
//             else right = mid - 1;
//         }

//         return -1;
//     }

//     static void Main()
//     {
//         int[] arr = { 10, 20, 30, 40, 50 };
//         int target = 40;

//         int index = BinarySearch(arr, target);

//         Console.WriteLine(index != -1
//             ? $"Found at index {index}"
//             : "Not Found");
//     }
// }