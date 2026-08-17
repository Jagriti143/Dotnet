// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text.RegularExpressions;

// public class LogEntry
// {
//     public string Date { get; init; } = string.Empty;
//     public string Time { get; init; } = string.Empty;
//     public string Level { get; init; } = string.Empty;
//     public string Message { get; init; } = string.Empty;
// }


// class LogParser
// {
//     // ---------------------------------------
//     // Parse Log
//     // ---------------------------------------

//     public static List<LogEntry> ParseLog(string rawLog)
//     {
//         string pattern =
//             @"^(?<date>\d{4}-\d{2}-\d{2})\s+" +
//             @"(?<time>\d{2}:\d{2}:\d{2})\s+" +
//             @"(?<level>INFO|WARN|ERROR)\s+" +
//             @"(?<message>.*)$";

//         MatchCollection matches =
//             Regex.Matches(
//                 rawLog,
//                 pattern,
//                 RegexOptions.Multiline
//             );

//         List<LogEntry> entries = new List<LogEntry>();

//         foreach (Match match in matches)
//         {
//             LogEntry entry = new LogEntry
//             {
//                 Date = match.Groups["date"].Value,
//                 Time = match.Groups["time"].Value,
//                 Level = match.Groups["level"].Value,
//                 Message = match.Groups["message"].Value
//             };

//             entries.Add(entry);
//         }

//         return entries;
//     }


//     // ---------------------------------------
//     // Redact Error Codes
//     // ---------------------------------------

//     public static string RedactErrorCodes(string rawLog)
//     {
//         string pattern =
//             @"^(?<prefix>\d{4}-\d{2}-\d{2}\s+" +
//             @"\d{2}:\d{2}:\d{2}\s+ERROR\b.*?\bcode=)" +
//             @"(?<code>\d+)(?<suffix>.*)$";

//         return Regex.Replace(
//             rawLog,
//             pattern,
//             match =>
//             {
//                 return match.Groups["prefix"].Value +
//                        "###" +
//                        match.Groups["suffix"].Value;
//             },
//             RegexOptions.Multiline
//         );
//     }
// }


// class Program
// {
//     static void Main()
//     {
//         // ---------------------------------------
//         // Sample Log
//         // ---------------------------------------

//         string rawLog =
// @"2026-08-14 09:15:00 INFO Service started
// 2026-08-14 09:16:12 WARN Disk usage high
// 2026-08-14 09:17:45 ERROR Request failed code=404
// 2026-08-14 09:18:03 INFO Request completed
// 2026-08-14 09:19:22 ERROR Upstream error code=500
// 2026-08-14 09:20:00 INFO Shutdown complete";


//         // ---------------------------------------
//         // Parse Log
//         // ---------------------------------------

//         List<LogEntry> entries =
//             LogParser.ParseLog(rawLog);

//         Console.WriteLine(
//             $"Parsed {entries.Count} entries."
//         );


//         // ---------------------------------------
//         // LINQ Summary
//         // ---------------------------------------

//         var summary =
//             entries
//                 .GroupBy(e => e.Level)
//                 .Select(g =>
//                     $"{g.Key}: {g.Count()}");

//         Console.WriteLine(
//             $"Summary: {string.Join(", ", summary)}"
//         );


//         // ---------------------------------------
//         // Print Parsed Entries
//         // ---------------------------------------

//         Console.WriteLine();
//         Console.WriteLine("--- Parsed entries ---");

//         foreach (LogEntry entry in entries)
//         {
//             Console.WriteLine(
//                 $"{entry.Date} {entry.Time} " +
//                 $"{entry.Level} {entry.Message}"
//             );
//         }


//         // ---------------------------------------
//         // Redact Error Codes
//         // ---------------------------------------

//         string redactedLog =
//             LogParser.RedactErrorCodes(rawLog);

//         Console.WriteLine();
//         Console.WriteLine("--- Redacted log ---");
//         Console.WriteLine(redactedLog);
//     }
// }