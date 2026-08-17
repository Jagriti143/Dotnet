// using System;
// using System.Text.RegularExpressions;

// class Program
// {
//     static void Main()
//     {
//         // 1. US ZIP Code
//         string zipPattern = @"^\d{5}(-\d{4})?$";

//         Console.WriteLine(
//             $"ZIP \"12345\": {Regex.IsMatch("12345", zipPattern)}"
//         );

//         Console.WriteLine(
//             $"ZIP \"12345-6789\": {Regex.IsMatch("12345-6789", zipPattern)}"
//         );

//         Console.WriteLine(
//             $"ZIP \"1234\": {Regex.IsMatch("1234", zipPattern)}"
//         );


//         // 2. Username
//         // 3-16 characters
//         // Letters, digits, underscore
//         // Cannot start with digit
//         string usernamePattern = @"^[A-Za-z_][A-Za-z0-9_]{2,15}$";

//         Console.WriteLine(
//             $"Username \"user_1\": {Regex.IsMatch("user_1", usernamePattern)}"
//         );

//         Console.WriteLine(
//             $"Username \"1user\": {Regex.IsMatch("1user", usernamePattern)}"
//         );

//         Console.WriteLine(
//             $"Username \"ab\": {Regex.IsMatch("ab", usernamePattern)}"
//         );


//         // 3. Hex Color
//         string hexPattern = @"^#[0-9A-Fa-f]{6}$";

//         Console.WriteLine(
//             $"Hex \"#1A2B3C\": {Regex.IsMatch("#1A2B3C", hexPattern)}"
//         );

//         Console.WriteLine(
//             $"Hex \"#GGGGGG\": {Regex.IsMatch("#GGGGGG", hexPattern)}"
//         );

//         Console.WriteLine(
//             $"Hex \"1A2B3C\": {Regex.IsMatch("1A2B3C", hexPattern)}"
//         );


//         // 4. Password
//         // At least 8 characters
//         // At least one digit
//         // At least one uppercase letter

//         string passwordPattern = @"^(?=.*[A-Z])(?=.*\d).{8,}$";

//         Console.WriteLine(
//             $"Password \"password\": {Regex.IsMatch("password", passwordPattern)}"
//         );

//         Console.WriteLine(
//             $"Password \"Password1\": {Regex.IsMatch("Password1", passwordPattern)}"
//         );

//         Console.WriteLine(
//             $"Password \"pass1\": {Regex.IsMatch("pass1", passwordPattern)}"
//         );


//         // 5. Sentence
//         // Must end with exactly one . ! or ?
//         // No additional . ! ? inside

//         string sentencePattern = @"^[^.!?]*[.!?]$";

//         Console.WriteLine(
//             $"Sentence \"Hello there.\": {Regex.IsMatch("Hello there.", sentencePattern)}"
//         );

//         Console.WriteLine(
//             $"Sentence \"Wait...\": {Regex.IsMatch("Wait...", sentencePattern)}"
//         );

//         Console.WriteLine(
//             $"Sentence \"Really?\": {Regex.IsMatch("Really?", sentencePattern)}"
//         );
//     }
// }
