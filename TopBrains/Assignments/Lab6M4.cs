// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Product
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public string Category { get; set; }
//     public decimal Price { get; set; }
//     public bool InStock { get; set; }
// }

// public class ProductSummaryDto
// {
//     public string Name { get; set; }
//     public string PriceLabel { get; set; }
// }

// public class Shape
// {
// }

// public class Circle : Shape
// {
//     public double Radius { get; set; }
// }

// public class Rectangle : Shape
// {
//     public double Width { get; set; }
//     public double Height { get; set; }
// }

// public class CategorySummary
// {
//     public string Category { get; set; }
//     public int ItemCount { get; set; }
//     public decimal TotalValue { get; set; }
//     public string TopProduct { get; set; }
// }

// public static class Data
// {
//     public static List<Product> Products = new List<Product>
//     {
//         new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Price = 999, InStock = true },
//         new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 499, InStock = true },
//         new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 12500, InStock = false },
//         new Product { Id = 4, Name = "Headphones", Category = "Electronics", Price = 1999, InStock = true },

//         new Product { Id = 5, Name = "Notebook", Category = "Stationery", Price = 120, InStock = true },
//         new Product { Id = 6, Name = "Pen", Category = "Stationery", Price = 50, InStock = true },
//         new Product { Id = 7, Name = "Marker", Category = "Stationery", Price = 80, InStock = false },
//         new Product { Id = 8, Name = "Backpack", Category = "Stationery", Price = 899, InStock = true },

//         new Product { Id = 9, Name = "T-Shirt", Category = "Clothing", Price = 799, InStock = true },
//         new Product { Id = 10, Name = "Jeans", Category = "Clothing", Price = 1499, InStock = false },
//         new Product { Id = 11, Name = "Jacket", Category = "Clothing", Price = 2499, InStock = true },

//         new Product { Id = 12, Name = "Coffee Mug", Category = "Home", Price = 299, InStock = true },
//         new Product { Id = 13, Name = "Lamp", Category = "Home", Price = 899, InStock = false },
//         new Product { Id = 14, Name = "Chair", Category = "Home", Price = 3499, InStock = true }
//     };
// }
// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("========== LAB 6 ==========\n");


//         var groups = Data.Products
//             .GroupBy(p => p.Category);

//         Console.WriteLine("1. Product Count by Category:");

//         foreach (var group in groups)
//         {
//             Console.WriteLine(
//                 $"{group.Key}: {group.Count()} products");
//         }

       
//         var filteredGroups =
//             from p in Data.Products
//             group p by p.Category into categoryGroup
//             where categoryGroup.Count() >= 3
//             orderby categoryGroup.Sum(p => p.Price) descending
//             select categoryGroup;

//         Console.WriteLine(
//             "\n2. Categories with 3+ products, " +
//             "ordered by total value DESC:");

//         foreach (var group in filteredGroups)
//         {
//             Console.WriteLine(
//                 $"{group.Key} - " +
//                 $"Count: {group.Count()} - " +
//                 $"Total: Rs.{group.Sum(p => p.Price):F2}");
//         }

        
//         Console.WriteLine("\n3. Detailed Category Report:");

//         foreach (var group in groups)
//         {
//             var mostExpensive = group
//                 .OrderByDescending(p => p.Price)
//                 .First();

//             Console.WriteLine($"\nCategory: {group.Key}");
//             Console.WriteLine($"Count: {group.Count()}");
//             Console.WriteLine(
//                 $"Total Value: Rs.{group.Sum(p => p.Price):F2}");
//             Console.WriteLine(
//                 $"Average Price: Rs.{group.Average(p => p.Price):F2}");
//             Console.WriteLine(
//                 $"Most Expensive: {mostExpensive.Name}");
//         }

        

//         var compositeGroups = Data.Products
//             .GroupBy(p => new
//             {
//                 p.Category,
//                 p.InStock
//             });

//         Console.WriteLine(
//             "\n4. Group by Category + InStock:");

//         foreach (var group in compositeGroups)
//         {
//             Console.WriteLine(
//                 $"Category: {group.Key.Category}, " +
//                 $"InStock: {group.Key.InStock}, " +
//                 $"Count: {group.Count()}");
//         }
//     }
// }