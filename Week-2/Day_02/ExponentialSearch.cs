// using System;

// class Program
// {
//     static int ExponentialSearch(int[] arr, int key)
//     {
//         if (arr[0] == key)
//             return 0;

//         int i = 1;

//         while (i < arr.Length && arr[i] <= key)
//             i = i * 2;

//         return BinarySearch(arr, i / 2, Math.Min(i, arr.Length - 1), key);
//     }

//     static int BinarySearch(int[] arr, int left, int right, int key)
//     {
//         while (left <= right)
//         {
//             int mid = (left + right) / 2;

//             if (arr[mid] == key)
//                 return mid;
//             else if (arr[mid] < key)
//                 left = mid + 1;
//             else
//                 right = mid - 1;
//         }

//         return -1;
//     }

//     static void Main()
//     {
//         int[] arr = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
//         int key = 14;

//         int result = ExponentialSearch(arr, key);

//         if (result != -1)
//             Console.WriteLine("Element found at index " + result);
//         else
//             Console.WriteLine("Element not found");
//     }
// }