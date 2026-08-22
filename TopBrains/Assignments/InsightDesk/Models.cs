using System;

namespace InsightDesk
{
    public class SaleLineItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string StaffName { get; set; }
        public string StoreLocation { get; set; }
        public DateTime SoldAt { get; set; }

        public decimal LineTotal => UnitPrice * Quantity;
    }

    // Promotion hierarchy
    public abstract class Promotion
    {
        public string Code { get; set; }
    }

    public class PercentOffPromotion : Promotion
    {
        public double PercentOff { get; set; }
    }

    public class FlatAmountPromotion : Promotion
    {
        public decimal AmountOff { get; set; }
    }

    public class BuyOneGetOnePromotion : Promotion
    {
    }

    // Report result classes

    public class ProductSalesReport
    {
        public string ProductName { get; set; }
        public int TotalQuantity { get; set; }
    }

    public class CategoryRevenueReport
    {
        public string Category { get; set; }
        public decimal Revenue { get; set; }
    }

    public class StaffPerformance
    {
        public string StaffName { get; set; }
        public int SalesCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AverageSaleValue { get; set; }
    }

    public class HourlySalesReport
    {
        public int Hour { get; set; }
        public int SalesCount { get; set; }
        public decimal Revenue { get; set; }
    }

    public class StoreComparison
    {
        public string StoreLocation { get; set; }
        public decimal Revenue { get; set; }
        public int ItemCount { get; set; }
        public string TopCategory { get; set; }
    }
}