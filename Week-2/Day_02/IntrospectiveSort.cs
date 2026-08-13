// using System;

// class IntroSort
// {
//     static void InsertionSort(int[] arr, int left, int right)
//     {
//         for (int i = left + 1; i <= right; i++)
//         {
//             int key = arr[i];
//             int j = i - 1;

//             while (j >= left && arr[j] > key)
//             {
//                 arr[j + 1] = arr[j];
//                 j--;
//             }

//             arr[j + 1] = key;
//         }
//     }

//     static int Partition(int[] arr, int low, int high)
//     {
//         int pivot = arr[high];
//         int i = low - 1;

//         for (int j = low; j < high; j++)
//         {
//             if (arr[j] <= pivot)
//             {
//                 i++;
//                 (arr[i], arr[j]) = (arr[j], arr[i]);
//             }
//         }

//         (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
//         return i + 1;
//     }

//     static void IntroSortUtil(int[] arr, int low, int high, int depthLimit)
//     {
//         if (high - low < 16)
//         {
//             InsertionSort(arr, low, high);
//             return;
//         }

//         if (depthLimit == 0)
//         {
//             Array.Sort(arr, low, high - low + 1);
//             return;
//         }

//         int pivot = Partition(arr, low, high);

//         IntroSortUtil(arr, low, pivot - 1, depthLimit - 1);
//         IntroSortUtil(arr, pivot + 1, high, depthLimit - 1);
//     }

//     static void Sort(int[] arr)
//     {
//         int depthLimit = 2 * (int)Math.Log2(arr.Length);
//         IntroSortUtil(arr, 0, arr.Length - 1, depthLimit);
//     }

//     static void Main()
//     {
//         int[] arr = { 9, 4, 7, 3, 1, 5 };
//         Sort(arr);
//         Console.WriteLine(string.Join(" ", arr));
//     }
// }