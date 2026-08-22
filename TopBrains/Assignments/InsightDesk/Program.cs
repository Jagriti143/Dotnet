
using System;
using System.Collections.Generic;

namespace InsightDesk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ============================================================
            // 1. SEED DATA
            // ============================================================

            List<SaleLineItem> sales = SeedData.GetSales();
            List<Promotion> promotions = SeedData.GetPromotions();

            Reports reports = new Reports(sales, promotions);

            Console.WriteLine("=================================================");
            Console.WriteLine("          INSIGHTDESK SALES ANALYTICS");
            Console.WriteLine("=================================================");

            Console.WriteLine($"Sales records: {sales.Count}");
            Console.WriteLine($"Promotions: {promotions.Count}");

            // ============================================================
            // 2. TOP SELLING PRODUCTS
            // ============================================================

            Console.WriteLine();
            Console.WriteLine("===== 1. TOP SELLING PRODUCTS =====");

            var topProducts = reports.TopSellingProducts(5);

            foreach (var product in topProducts)
            {
                Console.WriteLine(
                    $"{product.ProductName,-15} Quantity: {product.TotalQuantity}");
            }

            // ============================================================
            // 3. REVENUE BY CATEGORY
            // ============================================================
            // IMPORTANT:
            // Store query first.
            // Do NOT enumerate immediately.

            var revenueByCategory = reports.RevenueByCategory();

            // Another operation happens before enumeration.
            var staffPreview = reports.StaffPerformanceReport();

            Console.WriteLine();
            Console.WriteLine("===== 2. REVENUE BY CATEGORY =====");

            foreach (var category in revenueByCategory)
            {
                Console.WriteLine(
                    $"{category.Category,-15} Revenue: {category.Revenue:C}");
            }

            // ============================================================
            // 4. STAFF PERFORMANCE
            // ============================================================

            Console.WriteLine();
            Console.WriteLine("===== 3. STAFF PERFORMANCE =====");

            foreach (var staff in staffPreview)
            {
                Console.WriteLine(
                    $"{staff.StaffName,-10} " +
                    $"Sales: {staff.SalesCount,-3} " +
                    $"Revenue: {staff.TotalRevenue,12:C} " +
                    $"Average: {staff.AverageSaleValue,10:C}");
            }

            // ============================================================
            // 5. HOURLY SALES TREND
            // ============================================================
            // Store query first.
            // Another report will execute before enumeration.

            var hourlyTrend = reports.HourlySalesTrend();

            var storePreview = reports.StoreComparisonReport();

            Console.WriteLine();
            Console.WriteLine("===== 4. HOURLY SALES TREND =====");

            foreach (var hour in hourlyTrend)
            {
                Console.WriteLine(
                    $"{hour.Hour:00}:00 " +
                    $"Sales: {hour.SalesCount,-3} " +
                    $"Revenue: {hour.Revenue:C}");
            }

            // ============================================================
            // 6. PERCENT OFF PROMOTIONS
            // ============================================================

            Console.WriteLine();
            Console.WriteLine("===== 5. PERCENT-OFF PROMOTIONS ABOVE 15% =====");

            var promotionsAbove15 =
                reports.PercentOffPromotionsOver(15);

            foreach (var promotion in promotionsAbove15)
            {
                Console.WriteLine(
                    $"{promotion.Code,-10} {promotion.PercentOff}% OFF");
            }

            // ============================================================
            // 7. LOW PERFORMING CATEGORIES
            // ============================================================

            Console.WriteLine();
            Console.WriteLine("===== 6. LOW PERFORMING CATEGORIES =====");

            var lowCategories =
                reports.LowPerformingCategories(10000);

            foreach (var category in lowCategories)
            {
                Console.WriteLine(
                    $"{category.Category,-15} Revenue: {category.Revenue:C}");
            }

            // ============================================================
            // 8. STORE COMPARISON
            // ============================================================

            Console.WriteLine();
            Console.WriteLine("===== 7. STORE COMPARISON =====");

            foreach (var store in storePreview)
            {
                Console.WriteLine(
                    $"{store.StoreLocation,-12} " +
                    $"Revenue: {store.Revenue,12:C} " +
                    $"Items: {store.ItemCount,-4} " +
                    $"Top Category: {store.TopCategory}");
            }

            // ============================================================
            // 9. DEFERRED VS SNAPSHOT
            // ============================================================

            reports.DeferredVsSnapshotDemo();

            // ============================================================
            // 10. QUERY SYNTAX VS METHOD SYNTAX
            // ============================================================

            Console.WriteLine();
            Console.WriteLine("===== QUERY SYNTAX VS METHOD SYNTAX =====");

            bool equivalent =
                reports.CheckTopProductsEquivalence(5);

            Console.WriteLine(
                equivalent
                    ? "PASS: Both implementations produce identical results."
                    : "FAIL: Results are different.");

            // ============================================================
            // 11. BROKEN STAFF SORT
            // ============================================================

            Console.WriteLine();
            Console.WriteLine("===== BROKEN STAFF SORT =====");

            Console.WriteLine();
            Console.WriteLine("Broken: OrderByDescending().OrderBy()");

            foreach (var staff in reports.BrokenStaffSort())
            {
                Console.WriteLine(
                    $"{staff.StaffName,-10} Revenue: {staff.TotalRevenue:C}");
            }

            Console.WriteLine();
            Console.WriteLine("Correct: OrderByDescending().ThenBy()");

            foreach (var staff in reports.StaffPerformanceReport())
            {
                Console.WriteLine(
                    $"{staff.StaffName,-10} Revenue: {staff.TotalRevenue:C}");
            }

            Console.WriteLine();
            Console.WriteLine(
                "Explanation: The second OrderBy replaces the first ordering. " +
                "ThenBy preserves the primary ordering and applies a secondary sort.");

            // ============================================================
            // 12. EDGE CASE: TOP 100
            // ============================================================

            Console.WriteLine();
            Console.WriteLine("===== EDGE CASE: TOP 100 PRODUCTS =====");

            var top100 = reports.TopSellingProducts(100);

            int count = 0;

            foreach (var product in top100)
            {
                Console.WriteLine(
                    $"{product.ProductName,-15} {product.TotalQuantity}");

                count++;
            }

            Console.WriteLine(
                $"Requested 100 products. Returned: {count}");

            // ============================================================
            // 13. EDGE CASE: NO PROMOTIONS ABOVE 999%
            // ============================================================

            Console.WriteLine();
            Console.WriteLine(
                "===== EDGE CASE: PROMOTIONS ABOVE 999% =====");

            var impossiblePromotions =
                reports.PercentOffPromotionsOver(999);

            int promotionCount = 0;

            foreach (var promotion in impossiblePromotions)
            {
                Console.WriteLine(
                    $"{promotion.Code}: {promotion.PercentOff}%");

                promotionCount++;
            }

            Console.WriteLine(
                $"Matching promotions: {promotionCount}");

            Console.WriteLine();
            Console.WriteLine("=================================================");
            Console.WriteLine("             DEMONSTRATION COMPLETE");
            Console.WriteLine("=================================================");

            Console.ReadLine();
        }
    }
}