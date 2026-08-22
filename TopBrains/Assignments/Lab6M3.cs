// using System;
// using System.Collections.Generic;

// class Order
// {
//     public string OrderId { get; set; }
//     public string CustomerName { get; set; }
//     public double Amount { get; set; }
// }

// class Product
// {
//     public string Name { get; set; }
//     public double Price { get; set; }
//     public double DiscountPercent { get; set; }
//     public bool InStock { get; set; }

//     public double DiscountedPrice
//     {
//         get
//         {
//             return Price * (1 - DiscountPercent / 100);
//         }
//     }

//     public override string ToString()
//     {
//         return $"{Name} - Price: {Price:F2}, " +
//                $"Discounted: {DiscountedPrice:F2}, " +
//                $"In Stock: {InStock}";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("===== LAB 6: Lambda Expressions =====");



//         Func<double, double, double> rectangleArea =
//             (w, h) => w * h;

//         Console.WriteLine(
//             $"Rectangle area: {rectangleArea(10, 5)}");


//         Action<Order> printReceipt = order =>
//         {
//             Console.WriteLine("\n========== RECEIPT ==========");
//             Console.WriteLine($"Order ID: {order.OrderId}");
//             Console.WriteLine($"Customer: {order.CustomerName}");
//             Console.WriteLine($"Amount:   {order.Amount:C}");
//             Console.WriteLine("=============================");
//         };

//         Order order = new Order
//         {
//             OrderId = "ORD-001",
//             CustomerName = "John",
//             Amount = 1499.99
//         };

//         printReceipt(order);

  

//         List<Product> products = new List<Product>
//         {
//             new Product
//             {
//                 Name = "Laptop",
//                 Price = 70000,
//                 DiscountPercent = 10,
//                 InStock = true
//             },

//             new Product
//             {
//                 Name = "Mouse",
//                 Price = 1000,
//                 DiscountPercent = 5,
//                 InStock = true
//             },

//             new Product
//             {
//                 Name = "Keyboard",
//                 Price = 2500,
//                 DiscountPercent = 20,
//                 InStock = false
//             },

//             new Product
//             {
//                 Name = "Monitor",
//                 Price = 15000,
//                 DiscountPercent = 15,
//                 InStock = true
//             }
//         };



//         Console.WriteLine("\nOriginal products:");

//         PrintProducts(products);

//         products.Sort(
//             (p1, p2) => p1.Price.CompareTo(p2.Price));

//         Console.WriteLine("\nSorted by price ascending:");

//         PrintProducts(products);


//         products.Sort(
//             (p1, p2) => string.Compare(
//                 p2.Name,
//                 p1.Name,
//                 StringComparison.Ordinal));

//         Console.WriteLine("\nSorted by name descending:");

//         PrintProducts(products);

//         products.Sort(
//             (p1, p2) =>
//                 p1.DiscountedPrice.CompareTo(
//                     p2.DiscountedPrice));

//         Console.WriteLine("\nSorted by discounted price:");

//         PrintProducts(products);

        
//         products.RemoveAll(
//             p => !p.InStock);

//         Console.WriteLine(
//             "\nAfter removing out-of-stock products:");

//         PrintProducts(products);
//     }

//     static void PrintProducts(List<Product> products)
//     {
//         foreach (Product product in products)
//         {
//             Console.WriteLine(product);
//         }
//     }
// }