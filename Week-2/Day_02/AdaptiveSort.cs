// using System;

// class AdaptiveSort
// {
//     static void InsertionSort(int[] arr)
//     {
//         for (int i = 1; i < arr.Length; i++)
//         {
//             int key = arr[i];
//             int j = i - 1;

//             while (j >= 0 && arr[j] > key)
//             {
//                 arr[j + 1] = arr[j];
//                 j--;
//             }

//             arr[j + 1] = key;
//         }
//     }

//     static void Sort(int[] arr)
//     {
//         int disorder = 0;

//         for (int i = 1; i < arr.Length; i++)
//         {
//             if (arr[i] < arr[i - 1])
//                 disorder++;
//         }

//         if (disorder < arr.Length / 4)
//             InsertionSort(arr);   
//         else
//             Array.Sort(arr);     
//     }

//     static void Main()
//     {
//         int[] arr = { 1, 2, 4, 3, 5, 6 };
//         Sort(arr);
//         Console.WriteLine(string.Join(" ", arr));
//     }
// }