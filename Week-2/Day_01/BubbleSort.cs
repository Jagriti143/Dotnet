// using System;

// class Program
// {
//     static void BubbleSort(int[] arr)
//     {
//         int n = arr.Length;

//         for (int i = 0; i < n - 1; i++)
//         {
//             bool swapped = false;

//             for (int j = 0; j < n - i - 1; j++)
//             {
//                 if (arr[j] > arr[j + 1])
//                 {
//                     // Swap
//                     int temp = arr[j];
//                     arr[j] = arr[j + 1];
//                     arr[j + 1] = temp;

//                     swapped = true;
//                 }
//             }
//             if (!swapped)
//                 break;
//         }
//     }

//     static void Main()
//     {
//         int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

//         Console.WriteLine("Before:");
//         Console.WriteLine(string.Join(", ", numbers));

//         BubbleSort(numbers);

//         Console.WriteLine("After:");
//         Console.WriteLine(string.Join(", ", numbers));
//     }
// }