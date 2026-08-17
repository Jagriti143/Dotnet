// using System;
// using System.Globalization;
// using System.Text.RegularExpressions;

// class Program
// {
//     static void Main()
//     {
//         // ---------------------------------------
//         // 1. Named Groups
//         // ---------------------------------------

//         string logLine =
//             "2026-08-14 09:15:32 ERROR Connection timed out";

//         string logPattern =
//             @"^(?<date>\d{4}-\d{2}-\d{2})\s+" +
//             @"(?<time>\d{2}:\d{2}:\d{2})\s+" +
//             @"(?<level>\w+)\s+" +
//             @"(?<message>.*)$";

//         Match logMatch =
//             Regex.Match(logLine, logPattern);

//         Console.WriteLine(
//             $"date={logMatch.Groups["date"].Value}, " +
//             $"time={logMatch.Groups["time"].Value}, " +
//             $"level={logMatch.Groups["level"].Value}, " +
//             $"message={logMatch.Groups["message"].Value}"
//         );


//         // ---------------------------------------
//         // 2. Key = Value pairs
//         // ---------------------------------------

//         string kvText =
//             "name=Alice;age=30;city=NYC";

//         string kvPattern =
//             @"(?<key>[^=;]+)=(?<value>[^;]+)";

//         MatchCollection pairs =
//             Regex.Matches(kvText, kvPattern);

//         foreach (Match pair in pairs)
//         {
//             Console.WriteLine(
//                 $"{pair.Groups["key"].Value}=" +
//                 $"{pair.Groups["value"].Value}"
//             );
//         }


//         // ---------------------------------------
//         // 3. Format Numbers
//         // ---------------------------------------

//         string numbers =
//             "Revenue: 1234567, Costs: 89000";

//         string numberPattern = @"\b\d+\b";

//         string formattedNumbers =
//             Regex.Replace(
//                 numbers,
//                 numberPattern,
//                 match =>
//                 {
//                     long number =
//                         long.Parse(match.Value);

//                     return number.ToString(
//                         "N0",
//                         CultureInfo.InvariantCulture
//                     );
//                 }
//             );

//         Console.WriteLine(formattedNumbers);


//         // ---------------------------------------
//         // 4. ALL CAPS -> Title Case
//         // ---------------------------------------

//         string shouting =
//             "THIS IS URGENT please respond";

//         string capsPattern =
//             @"\b[A-Z]{2,}\b";

//         string converted =
//             Regex.Replace(
//                 shouting,
//                 capsPattern,
//                 match =>
//                 {
//                     string word =
//                         match.Value.ToLowerInvariant();

//                     return char.ToUpper(word[0]) +
//                            word.Substring(1);
//                 }
//             );

//         Console.WriteLine(converted);
//     }
// }