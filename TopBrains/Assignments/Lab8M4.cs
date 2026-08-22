using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }
}

public class ProductSummaryDto
{
    public string Name { get; set; }
    public string PriceLabel { get; set; }
}

public class Shape
{
}

public class Circle : Shape
{
    public double Radius { get; set; }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
}

public class CategorySummary
{
    public string Category { get; set; }
    public int ItemCount { get; set; }
    public decimal TotalValue { get; set; }
    public string TopProduct { get; set; }
}

public static class Data
{
    public static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Keyboard", Category = "Electronics", Price = 999, InStock = true },
        new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 499, InStock = true },
        new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 12500, InStock = false },
        new Product { Id = 4, Name = "Headphones", Category = "Electronics", Price = 1999, InStock = true },

        new Product { Id = 5, Name = "Notebook", Category = "Stationery", Price = 120, InStock = true },
        new Product { Id = 6, Name = "Pen", Category = "Stationery", Price = 50, InStock = true },
        new Product { Id = 7, Name = "Marker", Category = "Stationery", Price = 80, InStock = false },
        new Product { Id = 8, Name = "Backpack", Category = "Stationery", Price = 899, InStock = true },

        new Product { Id = 9, Name = "T-Shirt", Category = "Clothing", Price = 799, InStock = true },
        new Product { Id = 10, Name = "Jeans", Category = "Clothing", Price = 1499, InStock = false },
        new Product { Id = 11, Name = "Jacket", Category = "Clothing", Price = 2499, InStock = true },

        new Product { Id = 12, Name = "Coffee Mug", Category = "Home", Price = 299, InStock = true },
        new Product { Id = 13, Name = "Lamp", Category = "Home", Price = 899, InStock = false },
        new Product { Id = 14, Name = "Chair", Category = "Home", Price = 3499, InStock = true }
    };
}

class Program
{
    static void Main()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("       LAB 8 - MINI PRODUCT REPORT");
        Console.WriteLine("========================================\n");


        var queryReport =
            from p in Data.Products
            where p.InStock
            group p by p.Category into categoryGroup
            let orderedProducts = categoryGroup
                .OrderByDescending(p => p.Price)
            let totalValue = categoryGroup.Sum(p => p.Price)
            orderby totalValue descending
            select new CategorySummary
            {
                Category = categoryGroup.Key,
                ItemCount = categoryGroup.Count(),
                TotalValue = totalValue,
                TopProduct = orderedProducts.First().Name
            };

        var methodReport = Data.Products
            .Where(p => p.InStock)
            .GroupBy(p => p.Category)
            .Select(categoryGroup =>
            {
                var orderedProducts = categoryGroup
                    .OrderByDescending(p => p.Price);

                return new CategorySummary
                {
                    Category = categoryGroup.Key,
                    ItemCount = categoryGroup.Count(),
                    TotalValue = categoryGroup.Sum(p => p.Price),
                    TopProduct = orderedProducts.First().Name
                };
            })
            .OrderByDescending(x => x.TotalValue);


        Console.WriteLine("QUERY SYNTAX REPORT");
        Console.WriteLine("===================\n");

        PrintReport(queryReport);


        Console.WriteLine("\nMETHOD SYNTAX REPORT");
        Console.WriteLine("====================\n");

        PrintReport(methodReport);

        bool reportsMatch = queryReport
            .Zip(
                methodReport,
                (q, m) =>
                    q.Category == m.Category &&
                    q.ItemCount == m.ItemCount &&
                    q.TotalValue == m.TotalValue &&
                    q.TopProduct == m.TopProduct)
            .All(x => x);

        Console.WriteLine(
            "\nQuery and Method reports match: " +
            reportsMatch);
    }

    static void PrintReport(
        IEnumerable<CategorySummary> report)
    {
        foreach (var category in report)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(
                $"Category     : {category.Category}");
            Console.WriteLine(
                $"Item Count   : {category.ItemCount}");
            Console.WriteLine(
                $"Total Value  : Rs.{category.TotalValue:F2}");
            Console.WriteLine(
                $"Top Product  : {category.TopProduct}");
            Console.WriteLine("----------------------------------------");
        }
    }
}