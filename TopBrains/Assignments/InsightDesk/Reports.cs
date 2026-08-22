using System;
using System.Collections.Generic;
using System.Linq;

namespace InsightDesk
{
    public class Reports
    {
        private readonly List<SaleLineItem> _sales;
        private readonly List<Promotion> _promotions;

        public Reports(
            List<SaleLineItem> sales,
            List<Promotion> promotions)
        {
            _sales = sales;
            _promotions = promotions;
        }

        /// <summary>
        /// Returns the top N products based on total quantity sold.
        /// </summary>
        public IEnumerable<ProductSalesReport> TopSellingProducts(int topN)
        {
            if (topN <= 0)
                return Enumerable.Empty<ProductSalesReport>();

            return _sales
                .GroupBy(s => s.ProductName)
                .Select(g => new ProductSalesReport
                {
                    ProductName = g.Key,
                    TotalQuantity = g.Sum(s => s.Quantity)
                })
                .OrderByDescending(x => x.TotalQuantity)
                .Take(topN);
        }

        /// <summary>
        /// Returns total revenue for each category in descending revenue order.
        /// Demonstrates LINQ query syntax and query continuation with into.
        /// </summary>
        public IEnumerable<CategoryRevenueReport> RevenueByCategory()
        {
            var query =
                from sale in _sales
                group sale by sale.Category into categoryGroup
                let revenue = categoryGroup.Sum(s => s.LineTotal)
                orderby revenue descending
                select new CategoryRevenueReport
                {
                    Category = categoryGroup.Key,
                    Revenue = revenue
                };

            return query;
        }

        /// <summary>
        /// Returns staff performance including sales count,
        /// total revenue and average sale value.
        /// Results are sorted by revenue descending and staff name ascending for ties.
        /// </summary>
        public IEnumerable<StaffPerformance> StaffPerformanceReport()
        {
            return _sales
                .GroupBy(s => s.StaffName)
                .Select(g => new StaffPerformance
                {
                    StaffName = g.Key,
                    SalesCount = g.Count(),
                    TotalRevenue = g.Sum(s => s.LineTotal),
                    AverageSaleValue = g.Average(s => s.LineTotal)
                })
                .OrderByDescending(x => x.TotalRevenue)
                .ThenBy(x => x.StaffName);
        }

        /// <summary>
        /// Returns hourly sales count and revenue ordered chronologically.
        /// </summary>
        public IEnumerable<HourlySalesReport> HourlySalesTrend()
        {
            var query =
                from sale in _sales
                group sale by sale.SoldAt.Hour into hourGroup
                let revenue = hourGroup.Sum(s => s.LineTotal)
                orderby hourGroup.Key
                select new HourlySalesReport
                {
                    Hour = hourGroup.Key,
                    SalesCount = hourGroup.Count(),
                    Revenue = revenue
                };

            return query;
        }

        /// <summary>
        /// Returns percent-off promotions whose discount is greater
        /// than the supplied minimum percentage.
        /// </summary>
        public IEnumerable<PercentOffPromotion> PercentOffPromotionsOver(
            double minPercent)
        {
            return _promotions
                .OfType<PercentOffPromotion>()
                .Where(p => p.PercentOff > minPercent);
        }

        /// <summary>
        /// Returns categories whose total revenue is below the supplied threshold.
        /// Demonstrates GroupBy, into and where using query syntax.
        /// </summary>
        public IEnumerable<CategoryRevenueReport> LowPerformingCategories(
            decimal revenueThreshold)
        {
            var query =
                from sale in _sales
                group sale by sale.Category into categoryGroup
                let revenue = categoryGroup.Sum(s => s.LineTotal)
                where revenue < revenueThreshold
                select new CategoryRevenueReport
                {
                    Category = categoryGroup.Key,
                    Revenue = revenue
                };

            return query;
        }

        /// <summary>
        /// Returns revenue, item count and highest-revenue category
        /// for every store location.
        /// </summary>
        public IEnumerable<StoreComparison> StoreComparisonReport()
        {
            return _sales
                .GroupBy(s => s.StoreLocation)
                .Select(storeGroup =>
                {
                    var topCategory = storeGroup
                        .GroupBy(s => s.Category)
                        .Select(categoryGroup => new
                        {
                            Category = categoryGroup.Key,
                            Revenue = categoryGroup.Sum(s => s.LineTotal)
                        })
                        .OrderByDescending(x => x.Revenue)
                        .FirstOrDefault();

                    return new StoreComparison
                    {
                        StoreLocation = storeGroup.Key,
                        Revenue = storeGroup.Sum(s => s.LineTotal),
                        ItemCount = storeGroup.Sum(s => s.Quantity),
                        TopCategory = topCategory?.Category ?? "No sales"
                    };
                });
        }

        /// <summary>
        /// Demonstrates deferred execution versus immediate materialization.
        /// A deferred query sees a later mutation to the source list,
        /// while a materialized snapshot retains the original result.
        /// </summary>
        public void DeferredVsSnapshotDemo()
        {
            Console.WriteLine();
            Console.WriteLine("===== Deferred Execution vs Snapshot =====");

            var deferredQuery = _sales
                .Where(s => s.Category == "Electronics");

            var snapshot = _sales
                .Where(s => s.Category == "Electronics")
                .ToList();

            int beforeCount = deferredQuery.Count();

            Console.WriteLine(
                $"Electronics before mutation: {beforeCount}");

            _sales.Add(new SaleLineItem
            {
                Id = 1000,
                ProductName = "Gaming Console",
                Category = "Electronics",
                UnitPrice = 50000,
                Quantity = 1,
                StaffName = "Alice",
                StoreLocation = "Delhi",
                SoldAt = new DateTime(2026, 8, 22, 22, 30, 0)
            });

            int deferredAfterMutation = deferredQuery.Count();
            int snapshotAfterMutation = snapshot.Count;

            Console.WriteLine(
                $"Deferred query after mutation: {deferredAfterMutation}");

            Console.WriteLine(
                $"Snapshot after mutation: {snapshotAfterMutation}");

            Console.WriteLine(
                "Explanation: deferred LINQ queries execute when enumerated, " +
                "so they see the new item. ToList() executes immediately, " +
                "so the snapshot does not change.");

            // Clean up so the demonstration does not affect other reports.
            _sales.RemoveAll(s => s.Id == 1000);
        }

        /// <summary>
        /// Demonstrates the incorrect use of OrderBy twice.
        /// The second OrderBy replaces the first ordering.
        /// </summary>
        public IEnumerable<StaffPerformance> BrokenStaffSort()
        {
            return _sales
                .GroupBy(s => s.StaffName)
                .Select(g => new StaffPerformance
                {
                    StaffName = g.Key,
                    SalesCount = g.Count(),
                    TotalRevenue = g.Sum(s => s.LineTotal),
                    AverageSaleValue = g.Average(s => s.LineTotal)
                })
                .OrderByDescending(x => x.TotalRevenue)
                .OrderBy(x => x.StaffName);
        }

        /// <summary>
        /// Provides an alternate query-syntax implementation of
        /// TopSellingProducts for syntax-equivalence testing.
        /// </summary>
        public IEnumerable<ProductSalesReport> TopSellingProductsQuerySyntax(
            int topN)
        {
            if (topN <= 0)
                return Enumerable.Empty<ProductSalesReport>();

            var query =
                from sale in _sales
                group sale by sale.ProductName into productGroup
                let quantity = productGroup.Sum(s => s.Quantity)
                orderby quantity descending
                select new ProductSalesReport
                {
                    ProductName = productGroup.Key,
                    TotalQuantity = quantity
                };

            return query.Take(topN);
        }

        /// <summary>
        /// Compares the method-syntax and query-syntax versions
        /// of TopSellingProducts.
        /// </summary>
        public bool CheckTopProductsEquivalence(int topN)
        {
            var methodResult = TopSellingProducts(topN).ToList();
            var queryResult = TopSellingProductsQuerySyntax(topN).ToList();

            if (methodResult.Count != queryResult.Count)
                return false;

            return methodResult.Zip(
                    queryResult,
                    (a, b) =>
                        a.ProductName == b.ProductName &&
                        a.TotalQuantity == b.TotalQuantity)
                .All(x => x);
        }
    }
}