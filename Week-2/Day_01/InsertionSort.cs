// using System;

// class Program
// {
//     static void InsertionSort(int[] arr)
//     {
//         int n = arr.Length;

//         for (int i = 1; i < n; i++)
//         {
//             int key = arr[i];
//             int j = i - 1;

//             // Move elements greater than key one position ahead
//             while (j >= 0 && arr[j] > key)
//             {
//                 arr[j + 1] = arr[j];
//                 j--;
//             }

//             arr[j + 1] = key;
//         }
//     }

//     static void Main()
//     {
//         int[] numbers = { 12, 11, 13, 5, 6 };

//         foreach(int num in numbers){
        // Console.Write(num+" ");
        // }
        // Console.WriteLine();

//         InsertionSort(numbers);

//         foreach(int num in numbers){
        // Console.Write(num+" ");
        // }
        // Console.WriteLine();
//     }
// }