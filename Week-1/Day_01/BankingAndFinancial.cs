// using System;
// public class Transaction
// {
//     public string Id{get;set;}
//     public double Amt{get;set;}
//     public string Timestamp{get;set;}
//     public string MerchantName{get;set;}
//     public Transaction(string id,double amt,string time, string name)
//     {
//         this.Id=id;
//         this.Amt=amt;
//         this.Timestamp=time;
//         this.MerchantName=name;
//     }
 

// }
// public class Program
// {
//     public static void LargeTransactions(Transaction[] transactions, double limitamt)
//     {
//         foreach(Transaction i in transactions)
//         {
//             if (i.Amt > limitamt)
//             {
//                 Console.WriteLine($"Account Id {i.Id} - {i.Amt}");
//             }
//         }
//     }
//     public static void SearchByAccountId(Transaction[] transactions, string id)
//     {
//         bool found=false;
//         foreach(Transaction t in transactions)
//         {
//             if (t.Id == id)
//             {
//                 Console.WriteLine($"Accound Id {t.Id} - {t.Amt}");
//                 found=true;
//             }
//         }
//         if (!found)
//             {
//                 Console.WriteLine("Account not found.");
//             }
//     }


//     public static void FindDuplicates(Transaction[] transactions)
//     {
//         for(int i = 0; i < transactions.Length; i++)
//         {
//             for(int j=i+1; j< transactions.Length; j++)
//             {
//                 if(transactions[i].Id==transactions[j].Id && transactions[i].Amt==transactions[j].Amt
//                 && transactions[i].Timestamp==transactions[j].Timestamp && transactions[i].MerchantName
//                 == transactions[j].MerchantName)
//                 {
//                     Console.WriteLine($"Duplicates are {transactions[i].Id}");
//                 }
//             }
//         }
//     }
//     public static void Main(string[] args)
//     {
//         Transaction[] transactions =
//         {
//             new Transaction("A101", 5000, "2026-07-01 10:00", "Amazon"),
//             new Transaction("A102", 25000, "2026-07-01 10:15", "Apple"),
//             new Transaction("A101", 5000, "2026-07-01 10:00", "Amazon"),
//             new Transaction("A103", 75000, "2026-07-01 11:00", "Tesla")
//         };


//         Console.WriteLine("Large Transactions:");
//         LargeTransactions(transactions,20000);

//         Console.WriteLine("Searching Account");
//         SearchByAccountId(transactions,"A101");

//         Console.WriteLine("Finding Duplicates");
//         FindDuplicates(transactions);
        

        
//     }
// }