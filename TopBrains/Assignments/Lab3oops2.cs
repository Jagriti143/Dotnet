// using System;

// public class TaxCalculator
// {
//     public virtual decimal CalculateTax(decimal amount)
//     {
//         return amount * 0.10m;
//     }
// }

// public class RegionalTaxCalculator : TaxCalculator
// {
//     public sealed override decimal CalculateTax(decimal amount)
//     {
//         return amount * 0.12m;
//     }
// }


// public sealed class FixedDiscountCalculator
// {
//     public decimal ApplyDiscount(decimal price)
//     {
//         return price * 0.90m;
//     }
// }



// class Program
// {
//     static void Main()
//     {
//         RegionalTaxCalculator regionalTax =
//             new RegionalTaxCalculator();

//         decimal tax = regionalTax.CalculateTax(200);

//         Console.WriteLine(
//             $"RegionalTaxCalculator.CalculateTax(200) -> {tax:F2}");

//         FixedDiscountCalculator discount =
//             new FixedDiscountCalculator();

//         decimal discountedPrice =
//             discount.ApplyDiscount(50);

//         Console.WriteLine(
//             $"FixedDiscountCalculator.ApplyDiscount(50) -> {discountedPrice:F2}");

//         Console.WriteLine();
//         Console.WriteLine(
//             "(Both commented-out inheritance attempts produce a compiler error when uncommented.)");
//     }
// }