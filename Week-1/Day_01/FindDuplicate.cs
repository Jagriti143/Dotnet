// namespace MyApp
// {
//     public class Dup{
//         public void FindDup(){
//             int[] num = { 1, 2, 3, 2, 4, 5, 3, 2 };
//             for (int i = 0; i < num.Length; i++){
//                 int count = 1;
//                 bool flag = false;
//                 for (int k = 0; k < i; k++){
//                     if (num[i] == num[k]){
//                         flag = true;
//                         break;
//                     }
//                 }
//                 if (flag)
//                     continue;
//                 for (int j = i + 1; j < num.Length; j++){
//                     if (num[i] == num[j]){
//                         count++;
//                     }
//                 }
//                 if (count > 1){
//                     Console.Write(num[i] + " is duplicate ");
//                     Console.WriteLine($"Count is {count}");
                
//                 }
//             }
//         }
//     }
// }