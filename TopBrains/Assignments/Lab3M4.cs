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
//         Console.WriteLine("========== LAB 3 ==========\n");

//         // 1. Products under Rs.500
//         var under500 = Data.Products
//             .Where(p => p.Price < 500);

//         Print("1. Products under Rs.500", under500);

//         // 2. Specific category AND in stock
//         var electronicsInStock = Data.Products
//             .Where(p => p.Category == "Electronics" &&
//                         p.InStock);

//         Print("2. Electronics that are in stock", electronicsInStock);

//         // 3. Index-aware Where
//         // index starts at 0, so even positions are 0, 2, 4...
//         var evenPositions = Data.Products
//             .Where((p, index) => index % 2 == 0);

//         Print("3. Products at even positions", evenPositions);

//         // 4. Two Where calls
//         var twoWhereCalls = Data.Products
//             .Where(p => p.Category == "Electronics")
//             .Where(p => p.InStock);

//         // One Where with &&
//         var oneWhereCall = Data.Products
//             .Where(p => p.Category == "Electronics" &&
//                         p.InStock);

//         Print("4A. Two Where calls", twoWhereCalls);
//         Print("4B. One Where with &&", oneWhereCall);

//         Console.WriteLine(
//             "\nBoth filtering approaches identical: " +
//             twoWhereCalls.SequenceEqual(oneWhereCall));

//         Console.WriteLine(
//             $"Under Rs.500 count: {under500.Count()}");
//         Console.WriteLine(
//             $"Electronics in stock count: {electronicsInStock.Count()}");
//         Console.WriteLine(
//             $"Even position count: {evenPositions.Count()}");
//     }

//     static void Print(
//         string title,
//         System.Collections.Generic.IEnumerable<Product> products)
//     {
//         Console.WriteLine($"\n{title}:");

//         foreach (var p in products)
//         {
//             Console.WriteLine(
//                 $"{p.Name} | {p.Category} | Rs.{p.Price} | " +
//                 $"In Stock: {p.InStock}");
//         }

//         Console.WriteLine($"Count: {products.Count()}");
//     }
// }