using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EFCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var db = new ShopContext();

            if (db.Database.GetPendingMigrations().Count() == 0)
            {
                if (db.Categories.Count() == 0)
                {
                    db.Categories.AddRange(Categories);

                }

                if (db.Products.Count() == 0)
                {
                    db.Products.AddRange(Products);
                }
                db.SaveChanges();
            }
        }
        private static Category[] Categories = {
        new Category(){Name="Telefon"},
        new Category(){Name="Bilgisayar"},
        new Category(){Name="Tablet"}
    };
        private static Product[] Products = {
        new Product(){Name="Iphone 15 Pro Max", Price=98000,ImageUrl="1.png",Description="İyi telefon",IsApproved=true},
        new Product(){Name="Iphone 14 Pro Max", Price=68000,ImageUrl="2.png",Description="İyi telefon",IsApproved=true},
        new Product(){Name="Iphone 13 Pro Max", Price=58000,ImageUrl="3.png",Description="İyi telefon",IsApproved=true},
        new Product(){Name="Iphone 12 Pro", Price=48000,ImageUrl="4.png",Description="İyi telefon",IsApproved=true},
        new Product(){Name="Iphone 11", Price=38000,ImageUrl="5.png",Description="İyi telefon",IsApproved=false},
        new Product(){Name="Iphone 10", Price=18000,ImageUrl="6.png",Description="İyi telefon",IsApproved=false},
    };
    }
}