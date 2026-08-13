// using System;

// public class Program
// {
//       public static void Main(string[] args)
//     {
//         string[] stack=new string[10];
//         int top=-1;
//         int choice;

//         do
//         {
//             Console.WriteLine("1.Visit Page");
//             Console.WriteLine("2.Back");
//             Console.WriteLine("3.Current Page");
//             Console.WriteLine("4.Display History");
//             Console.WriteLine("5.Clear History");
//             Console.WriteLine("6.Total Pages");
//             Console.WriteLine("7.Exit");
//             Console.WriteLine("Enter Choice:");
//             choice=Convert.ToInt32(Console.ReadLine()); 
//             switch (choice)
//             {
//                 case 1:
//                     if (top == stack.Length - 1)
//                     {
//                         Console.WriteLine("History full");
//                     }
//                     else
//                     {
//                         Console.Write("Enter page no.: ");
//                         top++;
//                         stack[top]=Console.ReadLine();
//                         Console.WriteLine("Page Visited");
//                     }

//                 break;
//                 case 2:
//                     if (top == -1)
//                     {
//                         Console.WriteLine("No history");
//                     }
//                     else
//                     {
//                         Console.WriteLine("Back from: "+stack[top]);
//                         top--;

//                     }
//                 break;

//                 case 3:
//                     if (top == -1)
//                     {
//                         Console.WriteLine("No current page");
//                     }
//                     else
//                     {
//                         Console.WriteLine("Current page: "+stack[top]);
//                     }
//                 break;
//                 case 4:
//                     if (top == -1)
//                     {
//                         Console.WriteLine("No history");
//                     }
//                     else
//                     {
//                         Console.WriteLine("History:");
//                         for(int i = top; i >= 0; i--)
//                         {
//                             Console.WriteLine(stack[i]);
//                         }
//                     }
//                 break;
//                 case 5:
//                     top=-1;
//                     Console.WriteLine("History cleared");
//                 break;
//                 case 6:
//                     Console.WriteLine("Total Pages: "+(top+1));
//                 break;
//                 case 7:
//                 Console.WriteLine("Exit");
//                 break;
//                 default:
//                 Console.WriteLine("Invalid choice");
//                 break;

//             }
//         }while(choice !=7);
//     }
// }