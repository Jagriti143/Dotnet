// using System;
// using System.Collections.Generic;
// using System.Linq;

// public abstract class NotificationChannel
// {
//     public bool TrySend(string message)
//     {
//         try
//         {
//             return Send(message);
//         }
//         catch
//         {
//             return false;
//         }
//     }

//     protected abstract bool Send(string message);
// }

// public class EmailChannel : NotificationChannel
// {
//     protected override bool Send(string message)
//     {
//         return true;
//     }
// }

// public class SmsChannel : NotificationChannel
// {
//     protected override bool Send(string message)
//     {
//         if (message.Length > 160)
//             throw new ArgumentException("SMS message is too long");

//         return true;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         var channels = new List<NotificationChannel>
//         {
//             new EmailChannel(),
//             new SmsChannel(),
//             new EmailChannel(),
//             new SmsChannel()
//         };

//         string shortMessage = "Hello";
//         string longMessage = new string('A', 161);

//         var messages = new[]
//         {
//             shortMessage,
//             shortMessage,
//             shortMessage,
//             longMessage
//         };

//         var report = channels
//             .Select((channel, index) => new
//             {
//                 ChannelType = channel.GetType().Name,
//                 Success = channel.TrySend(messages[index])
//             })
//             .ToList();

//         foreach (var entry in report)
//         {
//             Console.WriteLine(
//                 $"{entry.ChannelType}: " +
//                 $"{(entry.Success ? "Success" : "Failed")}");
//         }

//         int succeeded = report.Count(x => x.Success);
//         int failed = report.Count(x => !x.Success);

//         Console.WriteLine();
//         Console.WriteLine($"Succeeded: {succeeded}, Failed: {failed}");
//     }
// }