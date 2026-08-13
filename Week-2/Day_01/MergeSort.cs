// using System;

// class Program
// {
//     static void MergeSort(int[] arr, int left, int right)
//     {
//         if (left < right)
//         {
//             int mid = (left + right) / 2;

//             MergeSort(arr, left, mid);
//             MergeSort(arr, mid + 1, right);

//             Merge(arr, left, mid, right);
//         }
//     }

//     static void Merge(int[] arr, int left, int mid, int right)
//     {
//         int[] temp = new int[right - left + 1];

//         int i = left;
//         int j = mid + 1;
//         int k = 0;

//         while (i <= mid && j <= right)
//         {
//             if (arr[i] <= arr[j])
//                 temp[k++] = arr[i++];
//             else
//                 temp[k++] = arr[j++];
//         }

//         while (i <= mid)
//             temp[k++] = arr[i++];

//         while (j <= right)
//             temp[k++] = arr[j++];

//         for (i = left, k = 0; i <= right; i++, k++)
//             arr[i] = temp[k];
//     }

//     static void Main()
//     {
//         int[] arr = { 38, 27, 43, 3, 9, 82, 10 };

//         MergeSort(arr, 0, arr.Length - 1);

//         Console.WriteLine("Sorted Array:");
//         foreach (int num in arr)
//         {
//             Console.Write(num + " ");
//         }
//     }
// }