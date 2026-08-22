// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("===== LAB 5: Anonymous Methods + Closures =====");


//         Action<int> squareAnonymous = delegate (int number)
//         {
//             Console.WriteLine($"Anonymous method square: {number * number}");
//         };

//         squareAnonymous(5);
//         squareAnonymous(8);



//         int total = 0;

//         Action addAnonymous = delegate
//         {
//             total++;
//         };

//         for (int i = 0; i < 5; i++)
//         {
//             addAnonymous();
//         }

//         Console.WriteLine($"Total after anonymous method: {total}");


//         Action<int> squareLambda =
//             number => Console.WriteLine(
//                 $"Lambda square: {number * number}");

//         squareLambda(5);
//         squareLambda(8);

//         int lambdaTotal = 0;

//         Action addLambda = () =>
//         {
//             lambdaTotal++;
//         };

//         for (int i = 0; i < 5; i++)
//         {
//             addLambda();
//         }

//         Console.WriteLine(
//             $"Total after lambda: {lambdaTotal}");

//     }
// }