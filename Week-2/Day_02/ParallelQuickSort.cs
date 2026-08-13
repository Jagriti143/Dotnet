// using System;
// using System.Threading.Tasks;

// class Program
// {
//     static void ParallelQuickSort(int[] arr, int left, int right)
//     {
//         if (left >= right)
//             return;

//         int pivot = Partition(arr, left, right);

//         Parallel.Invoke(
//             () => ParallelQuickSort(arr, left, pivot - 1),
//             () => ParallelQuickSort(arr, pivot + 1, right)
//         );
//     }

//     static int Partition(int[] arr, int left, int right)
//     {
//         int pivot = arr[right];
//         int i = left - 1;

//         for (int j = left; j < right; j++)
//         {
//             if (arr[j] <= pivot)
//             {
//                 i++;
//                 (arr[i], arr[j]) = (arr[j], arr[i]);
//             }
//         }

//         (arr[i + 1], arr[right]) = (arr[right], arr[i + 1]);
//         return i + 1;
//     }

//     static void Main()
//     {
//         int[] arr = { 10, 7, 8, 9, 1, 5 };

//         ParallelQuickSort(arr, 0, arr.Length - 1);

//         Console.WriteLine(string.Join(", ", arr));
//     }
// }