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
//         Console.WriteLine("========== LAB 4 ==========\n");

//         // ==========================================
//         // 1. List<object>
//         // ==========================================

//         var mixedObjects = new List<object>
//         {
//             10,
//             20,
//             "Hello",
//             "LINQ",
//             12.5,
//             25.7,
//             Data.Products[0],
//             Data.Products[1]
//         };

//         var integers = mixedObjects.OfType<int>();
//         var strings = mixedObjects.OfType<string>();
//         var products = mixedObjects.OfType<Product>();

//         Console.WriteLine("1. Integers:");
//         foreach (var number in integers)
//         {
//             Console.WriteLine(number);
//         }

//         Console.WriteLine("\nStrings:");
//         foreach (var text in strings)
//         {
//             Console.WriteLine(text);
//         }

//         Console.WriteLine("\nProducts:");
//         foreach (var product in products)
//         {
//             Console.WriteLine(product.Name);
//         }


//         var shapes = new List<Shape>
//         {
//             new Circle { Radius = 5 },
//             new Rectangle { Width = 4, Height = 6 },
//             new Circle { Radius = 3 },
//             new Rectangle { Width = 10, Height = 2 }
//         };

//         double totalCircleArea = shapes
//             .OfType<Circle>()
//             .Sum(c => Math.PI * c.Radius * c.Radius);

//         double totalRectangleArea = shapes
//             .OfType<Rectangle>()
//             .Sum(r => r.Width * r.Height);

//         Console.WriteLine(
//             $"\n2. Total Circle Area: {totalCircleArea:F2}");

//         Console.WriteLine(
//             $"Total Rectangle Area: {totalRectangleArea:F2}");


//         Console.WriteLine("\n3. OfType<Rectangle>():");

//         var rectangles = shapes.OfType<Rectangle>();

//         foreach (var rectangle in rectangles)
//         {
//             Console.WriteLine(
//                 $"Rectangle: {rectangle.Width} x {rectangle.Height}");
//         }

//         Console.WriteLine("\nCast<Rectangle>():");

//         try
//         {
//             var castRectangles = shapes.Cast<Rectangle>();

//             foreach (var rectangle in castRectangles)
//             {
//                 Console.WriteLine(
//                     $"Rectangle: {rectangle.Width} x {rectangle.Height}");
//             }
//         }
//         catch (InvalidCastException ex)
//         {
//             Console.WriteLine(
//                 "Caught InvalidCastException.");
//             Console.WriteLine(
//                 $"Message: {ex.Message}");
//         }

//     }
// }