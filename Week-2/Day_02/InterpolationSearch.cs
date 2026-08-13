// using System;

// class Program
// {
//     static int InterpolationSearch(int[] arr, int target)
//     {
//         int low = 0, high = arr.Length - 1;

//         while (low <= high &&
//                target >= arr[low] &&
//                target <= arr[high])
//         {
//             if (arr[high] == arr[low])
//                 return arr[low] == target ? low : -1;

//             int pos = low + ((target - arr[low]) *
//                       (high - low)) /
//                       (arr[high] - arr[low]);

//             if (arr[pos] == target) return pos;

//             if (arr[pos] < target)
//                 low = pos + 1;
//             else
//                 high = pos - 1;
//         }

//         return -1;
//     }

//     static void Main()
//     {
//         int[] arr = { 10, 20, 30, 40, 50, 60, 70 };
//         int target = 60;

//         int index = InterpolationSearch(arr, target);

//         Console.WriteLine(index != -1
//             ? $"Found at index {index}"
//             : "Not Found");
//     }
// }