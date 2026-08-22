// using System;

// class Program
// {
//     // 1. Custom delegate
//     public delegate void OrderEvent(string orderId);

//     // 2. Handler methods
//     static void LogToConsole(string orderId)
//     {
//         Console.WriteLine($"Console Log: Order {orderId} received.");
//     }

//     static void SendEmailSimulation(string orderId)
//     {
//         Console.WriteLine($"Email Simulation: Confirmation sent for {orderId}.");
//     }

//     static void UpdateInventorySimulation(string orderId)
//     {
//         Console.WriteLine($"Inventory Simulation: Inventory updated for {orderId}.");
//     }

//     static void Main()
//     {
//         Console.WriteLine("===== LAB 3: Multicast Delegates =====");

//         // 3. Add three handlers
//         OrderEvent orderHandler = LogToConsole;
//         orderHandler += SendEmailSimulation;
//         orderHandler += UpdateInventorySimulation;

//         Console.WriteLine("\nCalling all three handlers:");

//         orderHandler("ORD-1001");

//         // 4. Remove one handler
//         orderHandler -= SendEmailSimulation;

//         Console.WriteLine("\nAfter removing SendEmailSimulation:");

//         orderHandler("ORD-1002");

      

//         Console.WriteLine("\n===== Lambda Unsubscribe Pitfall =====");

//         OrderEvent lambdaHandler1 =
//             orderId => Console.WriteLine($"Lambda handler: {orderId}");

//         OrderEvent lambdaHandler2 =
//             orderId => Console.WriteLine($"Lambda handler: {orderId}");

//         OrderEvent lambdaMulticast = lambdaHandler1;

//         lambdaMulticast += lambdaHandler2;

//         Console.WriteLine("\nBoth lambda handlers:");

//         lambdaMulticast("ORD-1003");

//         lambdaMulticast -=
//             orderId => Console.WriteLine($"Lambda handler: {orderId}");

//         Console.WriteLine(
//             "\nAfter attempting to remove using a newly-created lambda:");

//         lambdaMulticast("ORD-1004");

        

//         OrderEvent storedLambda =
//             orderId => Console.WriteLine($"Stored lambda: {orderId}");

//         OrderEvent fixedHandler = storedLambda;

//         fixedHandler +=
//             orderId => Console.WriteLine($"Second lambda: {orderId}");

//         Console.WriteLine("\nBefore removing stored lambda:");

//         fixedHandler("ORD-1005");

       
//         fixedHandler -= storedLambda;

//         Console.WriteLine("\nAfter removing stored lambda:");

//         fixedHandler("ORD-1006");
//     }
// }