using System;
using System.Collections.Generic;

namespace InsightDesk
{
    public static class SeedData
    {
        public static List<SaleLineItem> GetSales()
        {
            DateTime day = new DateTime(2026, 8, 22);

            return new List<SaleLineItem>
            {
                new SaleLineItem { Id=1, ProductName="Laptop", Category="Electronics", UnitPrice=60000, Quantity=2, StaffName="Alice", StoreLocation="Delhi", SoldAt=day.AddHours(9).AddMinutes(10) },
                new SaleLineItem { Id=2, ProductName="Mouse", Category="Electronics", UnitPrice=800, Quantity=5, StaffName="Bob", StoreLocation="Gurugram", SoldAt=day.AddHours(9).AddMinutes(30) },
                new SaleLineItem { Id=3, ProductName="Keyboard", Category="Electronics", UnitPrice=1500, Quantity=3, StaffName="Charlie", StoreLocation="Delhi", SoldAt=day.AddHours(10).AddMinutes(5) },
                new SaleLineItem { Id=4, ProductName="Monitor", Category="Electronics", UnitPrice=12000, Quantity=2, StaffName="Alice", StoreLocation="Gurugram", SoldAt=day.AddHours(10).AddMinutes(20) },
                new SaleLineItem { Id=5, ProductName="Headphones", Category="Electronics", UnitPrice=2500, Quantity=4, StaffName="Bob", StoreLocation="Delhi", SoldAt=day.AddHours(10).AddMinutes(45) },

                new SaleLineItem { Id=6, ProductName="T-Shirt", Category="Clothing", UnitPrice=900, Quantity=6, StaffName="Charlie", StoreLocation="Gurugram", SoldAt=day.AddHours(11).AddMinutes(5) },
                new SaleLineItem { Id=7, ProductName="Jeans", Category="Clothing", UnitPrice=1800, Quantity=4, StaffName="Alice", StoreLocation="Delhi", SoldAt=day.AddHours(11).AddMinutes(30) },
                new SaleLineItem { Id=8, ProductName="Jacket", Category="Clothing", UnitPrice=3500, Quantity=2, StaffName="Bob", StoreLocation="Gurugram", SoldAt=day.AddHours(11).AddMinutes(50) },
                new SaleLineItem { Id=9, ProductName="Shoes", Category="Clothing", UnitPrice=2500, Quantity=5, StaffName="Charlie", StoreLocation="Delhi", SoldAt=day.AddHours(12).AddMinutes(10) },
                new SaleLineItem { Id=10, ProductName="Cap", Category="Clothing", UnitPrice=600, Quantity=8, StaffName="Alice", StoreLocation="Gurugram", SoldAt=day.AddHours(12).AddMinutes(30) },

                new SaleLineItem { Id=11, ProductName="Apple", Category="Grocery", UnitPrice=150, Quantity=10, StaffName="Bob", StoreLocation="Delhi", SoldAt=day.AddHours(12).AddMinutes(50) },
                new SaleLineItem { Id=12, ProductName="Milk", Category="Grocery", UnitPrice=60, Quantity=15, StaffName="Charlie", StoreLocation="Gurugram", SoldAt=day.AddHours(13).AddMinutes(10) },
                new SaleLineItem { Id=13, ProductName="Bread", Category="Grocery", UnitPrice=50, Quantity=12, StaffName="Alice", StoreLocation="Delhi", SoldAt=day.AddHours(13).AddMinutes(25) },
                new SaleLineItem { Id=14, ProductName="Rice", Category="Grocery", UnitPrice=700, Quantity=5, StaffName="Bob", StoreLocation="Gurugram", SoldAt=day.AddHours(13).AddMinutes(45) },
                new SaleLineItem { Id=15, ProductName="Oil", Category="Grocery", UnitPrice=160, Quantity=8, StaffName="Charlie", StoreLocation="Delhi", SoldAt=day.AddHours(14).AddMinutes(5) },

                new SaleLineItem { Id=16, ProductName="Chair", Category="Furniture", UnitPrice=4000, Quantity=2, StaffName="Alice", StoreLocation="Gurugram", SoldAt=day.AddHours(14).AddMinutes(20) },
                new SaleLineItem { Id=17, ProductName="Table", Category="Furniture", UnitPrice=7000, Quantity=1, StaffName="Bob", StoreLocation="Delhi", SoldAt=day.AddHours(14).AddMinutes(40) },
                new SaleLineItem { Id=18, ProductName="Sofa", Category="Furniture", UnitPrice=25000, Quantity=1, StaffName="Charlie", StoreLocation="Gurugram", SoldAt=day.AddHours(15).AddMinutes(5) },
                new SaleLineItem { Id=19, ProductName="Lamp", Category="Furniture", UnitPrice=1200, Quantity=4, StaffName="Alice", StoreLocation="Delhi", SoldAt=day.AddHours(15).AddMinutes(25) },
                new SaleLineItem { Id=20, ProductName="Bookshelf", Category="Furniture", UnitPrice=6000, Quantity=2, StaffName="Bob", StoreLocation="Gurugram", SoldAt=day.AddHours(15).AddMinutes(45) },

                new SaleLineItem { Id=21, ProductName="Laptop", Category="Electronics", UnitPrice=60000, Quantity=1, StaffName="Charlie", StoreLocation="Delhi", SoldAt=day.AddHours(16).AddMinutes(5) },
                new SaleLineItem { Id=22, ProductName="Mouse", Category="Electronics", UnitPrice=800, Quantity=7, StaffName="Alice", StoreLocation="Gurugram", SoldAt=day.AddHours(16).AddMinutes(20) },
                new SaleLineItem { Id=23, ProductName="Keyboard", Category="Electronics", UnitPrice=1500, Quantity=5, StaffName="Bob", StoreLocation="Delhi", SoldAt=day.AddHours(16).AddMinutes(40) },
                new SaleLineItem { Id=24, ProductName="Monitor", Category="Electronics", UnitPrice=12000, Quantity=1, StaffName="Charlie", StoreLocation="Gurugram", SoldAt=day.AddHours(17).AddMinutes(5) },
                new SaleLineItem { Id=25, ProductName="Headphones", Category="Electronics", UnitPrice=2500, Quantity=6, StaffName="Alice", StoreLocation="Delhi", SoldAt=day.AddHours(17).AddMinutes(20) },

                new SaleLineItem { Id=26, ProductName="T-Shirt", Category="Clothing", UnitPrice=900, Quantity=10, StaffName="Bob", StoreLocation="Gurugram", SoldAt=day.AddHours(17).AddMinutes(40) },
                new SaleLineItem { Id=27, ProductName="Jeans", Category="Clothing", UnitPrice=1800, Quantity=3, StaffName="Charlie", StoreLocation="Delhi", SoldAt=day.AddHours(18).AddMinutes(5) },
                new SaleLineItem { Id=28, ProductName="Jacket", Category="Clothing", UnitPrice=3500, Quantity=3, StaffName="Alice", StoreLocation="Gurugram", SoldAt=day.AddHours(18).AddMinutes(20) },
                new SaleLineItem { Id=29, ProductName="Shoes", Category="Clothing", UnitPrice=2500, Quantity=4, StaffName="Bob", StoreLocation="Delhi", SoldAt=day.AddHours(18).AddMinutes(40) },
                new SaleLineItem { Id=30, ProductName="Cap", Category="Clothing", UnitPrice=600, Quantity=9, StaffName="Charlie", StoreLocation="Gurugram", SoldAt=day.AddHours(19).AddMinutes(5) },

                new SaleLineItem { Id=31, ProductName="Apple", Category="Grocery", UnitPrice=150, Quantity=20, StaffName="Alice", StoreLocation="Delhi", SoldAt=day.AddHours(19).AddMinutes(20) },
                new SaleLineItem { Id=32, ProductName="Milk", Category="Grocery", UnitPrice=60, Quantity=25, StaffName="Bob", StoreLocation="Gurugram", SoldAt=day.AddHours(19).AddMinutes(40) },
                new SaleLineItem { Id=33, ProductName="Bread", Category="Grocery", UnitPrice=50, Quantity=20, StaffName="Charlie", StoreLocation="Delhi", SoldAt=day.AddHours(20).AddMinutes(5) },
                new SaleLineItem { Id=34, ProductName="Rice", Category="Grocery", UnitPrice=700, Quantity=8, StaffName="Alice", StoreLocation="Gurugram", SoldAt=day.AddHours(20).AddMinutes(20) },
                new SaleLineItem { Id=35, ProductName="Oil", Category="Grocery", UnitPrice=160, Quantity=10, StaffName="Bob", StoreLocation="Delhi", SoldAt=day.AddHours(20).AddMinutes(40) },

                new SaleLineItem { Id=36, ProductName="Chair", Category="Furniture", UnitPrice=4000, Quantity=3, StaffName="Charlie", StoreLocation="Gurugram", SoldAt=day.AddHours(21).AddMinutes(5) },
                new SaleLineItem { Id=37, ProductName="Table", Category="Furniture", UnitPrice=7000, Quantity=2, StaffName="Alice", StoreLocation="Delhi", SoldAt=day.AddHours(21).AddMinutes(20) },
                new SaleLineItem { Id=38, ProductName="Sofa", Category="Furniture", UnitPrice=25000, Quantity=1, StaffName="Bob", StoreLocation="Gurugram", SoldAt=day.AddHours(21).AddMinutes(35) },
                new SaleLineItem { Id=39, ProductName="Lamp", Category="Furniture", UnitPrice=1200, Quantity=5, StaffName="Charlie", StoreLocation="Delhi", SoldAt=day.AddHours(21).AddMinutes(50) },
                new SaleLineItem { Id=40, ProductName="Bookshelf", Category="Furniture", UnitPrice=6000, Quantity=3, StaffName="Alice", StoreLocation="Gurugram", SoldAt=day.AddHours(22).AddMinutes(5) }
            };
        }

        public static List<Promotion> GetPromotions()
        {
            return new List<Promotion>
            {
                new PercentOffPromotion
                {
                    Code = "P10",
                    PercentOff = 10
                },

                new PercentOffPromotion
                {
                    Code = "P20",
                    PercentOff = 20
                },

                new PercentOffPromotion
                {
                    Code = "P30",
                    PercentOff = 30
                },

                new FlatAmountPromotion
                {
                    Code = "FLAT500",
                    AmountOff = 500
                },

                new FlatAmountPromotion
                {
                    Code = "FLAT1000",
                    AmountOff = 1000
                },

                new BuyOneGetOnePromotion
                {
                    Code = "BOGO"
                }
            };
        }
    }
}