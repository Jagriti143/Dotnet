// using System;
// using System.Xml.Serialization;
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         string[] queue=new string[10];
//         int front=-1;
//         int rear=-1;
//         int choice;
//         do
//         {
//             Console.WriteLine("1. Register Patient");
//             Console.WriteLine("2. Call Next Patient");
//             Console.WriteLine("3. View Next Patient");
//             Console.WriteLine("4. Display Waiting Patients");
//             Console.WriteLine("5. Search Patient");
//             Console.WriteLine("6. Count Waiting Patients");
//             Console.WriteLine("7. Exit");
//             Console.WriteLine("Enter Choice :");
//             choice=Convert.ToInt32(Console.ReadLine());
//             switch(choice){
//                 case 1:
//                 if(rear==queue.Length-1){
//                     Console.WriteLine("Queue is full");
//                 }else{
//                     Console.WriteLine("Enter patient name: ");
//                     if(front==-1)
//                     front=0;
//                     rear++;
//                     queue[rear]=Console.ReadLine();
//                     Console.WriteLine("Patient registered");
//                 }
//                 break;
//                 case 2:
//                 if(front==-1 || front>rear){
//                     Console.WriteLine("No patients");
//                 }else{
//                     Console.WriteLine("Calling: "+queue[front]);
//                     front++;
//                     if(front>rear){
//                         front=-1;
//                         rear=-1;
//                     }
//                 }
//                 break;
//                 case 3:
//                 if(front==-1){
//                     Console.WriteLine("No patients");
//                 }else{
//                     Console.WriteLine("Next patient: "+queue[front]);
//                 }
//                 break;
//                 case 4:
//                 if(front==-1){
//                     Console.WriteLine("No waiting patients");
//                 }else{
//                     Console.WriteLine("Waiting patients: ");
//                     for(int i=front;i<=rear;i++){
//                         Console.WriteLine(queue[i]);
//                     }
//                 }
//                 break;
//                 case 5:
//                 Console.WriteLine("Enter patient name to search: ");
//                 string search=Console.ReadLine();
//                 bool found=false;
//                 for(int i=front;i<=rear;i++){
//                     if(queue[i]==search){
//                         found=true;
//                         break;
//                     }
//                 }
//                 if(found){
//                     Console.WriteLine("Patient found");
//                 }else{
//                     Console.WriteLine("Patient not found");
//                 }
//                 break;
//                 case 6:
//                 if(front==-1){
//                     Console.WriteLine("No patients");
//                 }else{
//                     Console.WriteLine("Total Waiting patients: "+(rear-front +1));
//                 }
//                 break;
//                 case 7:
//                 Console.WriteLine("Thank you");
//                 break;
//                 default:
//                 Console.WriteLine("Invalid choice");
//                 break;
//             }

            
//         }while(choice!=7);
//     }
// }