// using System;

// class TimSort
// {
//     const int RUN = 32;

//     static void InsertionSort(int[] arr, int left, int right)
//     {
//         for (int i = left + 1; i <= right; i++)
//         {
//             int temp = arr[i];
//             int j = i - 1;

//             while (j >= left && arr[j] > temp)
//             {
//                 arr[j + 1] = arr[j];
//                 j--;
//             }

//             arr[j + 1] = temp;
//         }
//     }

//     static void Merge(int[] arr, int l, int m, int r)
//     {
//         int[] left = new int[m - l + 1];
//         int[] right = new int[r - m];

//         Array.Copy(arr, l, left, 0, left.Length);
//         Array.Copy(arr, m + 1, right, 0, right.Length);

//         int i = 0, j = 0, k = l;

//         while (i < left.Length && j < right.Length)
//             arr[k++] = (left[i] <= right[j]) ? left[i++] : right[j++];

//         while (i < left.Length) arr[k++] = left[i++];
//         while (j < right.Length) arr[k++] = right[j++];
//     }

//     static void Sort(int[] arr)
//     {
//         int n = arr.Length;

//         for (int i = 0; i < n; i += RUN)
//             InsertionSort(arr, i, Math.Min(i + RUN - 1, n - 1));

//         for (int size = RUN; size < n; size *= 2)
//         {
//             for (int left = 0; left < n; left += 2 * size)
//             {
//                 int mid = Math.Min(left + size - 1, n - 1);
//                 int right = Math.Min(left + 2 * size - 1, n - 1);

//                 if (mid < right)
//                     Merge(arr, left, mid, right);
//             }
//         }
//     }

//     static void Main()
//     {
//         int[] arr = { 5, 21, 7, 23, 19 };
//         Sort(arr);
//         Console.WriteLine(string.Join(" ", arr));
//     }
// }