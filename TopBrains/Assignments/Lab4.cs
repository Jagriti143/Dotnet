// using System;
// using System.Collections.Generic;
// using System.Globalization;
// using System.Linq;
// using System.Text;

// static class StringToolkit
// {
//     public static string ToTitleCase(string input)
//     {
//         if (string.IsNullOrWhiteSpace(input))
//         {
//             return "";
//         }

//         TextInfo textInfo =
//             CultureInfo.CurrentCulture.TextInfo;

//         return textInfo.ToTitleCase(
//             input.ToLower()
//         );
//     }
// }


// class Employee
// {
//     public string Name { get; set; }
//     public string Department { get; set; }
//     public decimal Salary { get; set; }

//     public Employee(
//         string name,
//         string department,
//         decimal salary)
//     {
//         Name = name;
//         Department = department;
//         Salary = salary;
//     }
// }


// class Program
// {
//     static void Main()
//     {
//         const string rawData = @"
// john smith|engineering|72000
// MARY jones|sales|65000

// ravi KUMAR|engineering|81000
// ";

//         // Store employees
//         List<Employee> employees =
//             new List<Employee>();

//         // Count StringBuilder Append calls
//         int appendCalls = 0;

//         // Count string concatenations
//         int concatenationCount = 0;

//         // Split raw data into rows
//         string[] rows = rawData.Split(
//             new[] { '\r', '\n' },
//             StringSplitOptions.RemoveEmptyEntries
//         );

//         // Process each row
//         foreach (string row in rows)
//         {
//             // Defensive check
//             if (string.IsNullOrWhiteSpace(row))
//             {
//                 continue;
//             }

//             // Split row into fields
//             string[] fields = row.Split('|');

//             if (fields.Length != 3)
//             {
//                 continue;
//             }

//             string name = fields[0].Trim();
//             string department = fields[1].Trim();
//             string salaryText = fields[2].Trim();

//             // Parse salary
//             if (decimal.TryParse(
//                 salaryText,
//                 out decimal salary))
//             {
//                 Employee employee =
//                     new Employee(
//                         name,
//                         department,
//                         salary
//                     );

//                 employees.Add(employee);
//             }
//         }

//         // Calculate totals
//         decimal totalSalary = employees.Sum(
//             employee => employee.Salary
//         );

//         int employeeCount = employees.Count;

//         // Create StringBuilder
//         StringBuilder sb = new StringBuilder();
//         Console.WriteLine("=================================================");
//         // Title
//         sb.Append(
//             "           Employee Compensation Report        \n=================================================");
//         appendCalls++;

//         sb.AppendLine();
//         appendCalls++;
//         // Header
//         sb.AppendLine(
//             "Name".PadRight(22) +
//             "Department".PadRight(18) +
//             "Salary".PadLeft(12)
//         );
//         appendCalls++;

//         sb.AppendLine(
//             new string('-', 52)
//         );
//         appendCalls++;

//         // Employee rows
//         foreach (Employee employee in employees)
//         {
//             string formattedName =
//                 StringToolkit.ToTitleCase(
//                     employee.Name
//                 );

//             string formattedDepartment =
//                 StringToolkit.ToTitleCase(
//                     employee.Department
//                 );

//             string formattedSalary =
//                 employee.Salary.ToString("N0");

//             string line =
//                 formattedName.PadRight(22) +
//                 formattedDepartment.PadRight(18) +
//                 formattedSalary.PadLeft(12);

//             sb.AppendLine(line);
//             appendCalls++;
//         }

//         // Footer
//         sb.AppendLine();
//         appendCalls++;

//         sb.AppendLine(
//             $"Employees: {employeeCount}    " +
//             $"Total Salary: {totalSalary:N0}"
//         );
//         appendCalls++;
//         // Print final report
//         Console.WriteLine(
//             sb.ToString()
//         );
//         Console.WriteLine("=================================================");
//         // Statistics
//         Console.WriteLine();
//         Console.WriteLine("===== BUILD STATISTICS =====");

//         Console.WriteLine(
//             $"StringBuilder Append calls: {appendCalls}"
//         );

//         Console.WriteLine(
//             $"String concatenations in loops: {concatenationCount}"
//         );
//     }
// }