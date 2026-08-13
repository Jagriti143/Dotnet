// using System;
// public class Record
// {
//     public int Heartrate{get;set;}
//     public int OxygenLevel{get;set;}
//     public int SystolicBP{get;set;}
//     public int DiastolicBP{get;set;}
//     public string Timestamp{get;set;}
//     public Record(int h,int o,int s,int d, string t)
//     {
//         this.Heartrate=h;
//         this.OxygenLevel=o;
//         this.SystolicBP=s;
//         this.DiastolicBP=d;
//         this.Timestamp=t;

//     }


// }
// public class Program
// {
//     public static void DisplayRecords(Record[] records)
//     {
//         foreach(Record r in records)
//         {
//            Console.Write($"HeartRate: {r.Heartrate} BPM ");
//            Console.Write($"OxygenLevel: {r.OxygenLevel} SpO2% ");
//            Console.Write($"SystolicBP: {r.SystolicBP} ");
//            Console.Write($"DiastolicBP: {r.DiastolicBP} ");
//            Console.Write($"TimeStamp: {r.Timestamp} ");
//             Console.WriteLine();  
//         } 
        
//     }
//     public static void AbnormalReadings(Record[] records)
//     {
//         foreach(Record r in records)
//         {
//             bool abnormal= false;
//             if(r.Heartrate<60 || r.Heartrate > 100)
//             {
//                 abnormal=true;
//             }
//             if (r.OxygenLevel < 95)
//             {
//                 abnormal=true;
//             }
//             if(r.SystolicBP>140 || r.DiastolicBP > 90)
//             {
//                 abnormal=true;
//             }
//             if (abnormal)
//             {
//                 Console.WriteLine($"Abnormal Readings: {r.Heartrate} BPM, {r.OxygenLevel} SpO2%, {r.SystolicBP}/{r.DiastolicBP}");
//             }
//         }
//     }
//     public static double AverageHeartRate(Record[] records)
//     {
//         int sum=0;
//         foreach(Record r in records)
//         {
//             sum+=r.Heartrate;
//         }
//         return (double)sum/records.Length;
//     }
//     public static void SlidingWindowAverage(Record[] records, int windowSize)
//     {
//         if(windowSize > records.Length)
//             return;

//         for(int i = 0; i <= records.Length - windowSize; i++)
//         {
//             int sum = 0;

//             for(int j = i; j < i + windowSize; j++)
//             {
//                 sum += records[j].Heartrate;
//             }

//             double avg = (double)sum / windowSize;

//             Console.WriteLine(
//                 $"Window {records[i].Timestamp} - " +
//                 $"{records[i + windowSize - 1].Timestamp}: {avg:F2}"
//             );
//         }
//     }
//     public static void SortByHeartRate(Record[] records)
//     {
//         for(int i = 0; i < records.Length - 1; i++)
//         {
//             for(int j = 0; j < records.Length - i - 1; j++)
//             {
//                 if(records[j].Heartrate > records[j + 1].Heartrate)
//                 {
//                     Record temp = records[j];
//                     records[j] = records[j + 1];
//                     records[j + 1] = temp;
//                 }
//             }
//         }
//     }

//     public static void Main(string[] args)
//     {
//         Record[] records =
//         {
//             new Record(72,98,120,80,"10:00"),
//             new Record(85,97,125,82,"10:01"),
//             new Record(110,93,150,95,"10:02"),
//             new Record(65,99,118,78,"10:03"),
//             new Record(55,94,145,92,"10:04")
//         };
//         Console.WriteLine("All Records");
//         DisplayRecords(records);

//         AbnormalReadings(records);
//         double avg=AverageHeartRate(records);
//         Console.WriteLine($"Average Heartrate: {avg}");

//         SlidingWindowAverage(records,3);
//         SortByHeartRate(records);
//         DisplayRecords(records);
        


        
//     }
// }