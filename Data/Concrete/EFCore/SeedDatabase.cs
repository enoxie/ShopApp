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
                    db.AddRange(ProductCategories);
                }
                db.SaveChanges();
            }
        }
        private static Category[] Categories = {
        new Category(){Name="Telefon", Url="telefon",Description="Telefon kategorisi açıklama alanı burasıdır."},
        new Category(){Name="Bilgisayar",Url="bilgisayar",Description="Bilgisayar kategorisi açıklama alanı burasıdır."},
        new Category(){Name="Monitör",Url="monitor",Description="Monitör kategorisi açıklama alanı burasıdır."},
        new Category(){Name="Tablet",Url="tablet",Description="Tablet kategorisi açıklama alanı burasıdır."},
        new Category(){Name="Elektronik",Url="elektronik",Description="Elektronik kategorisi açıklama alanı burasıdır."},
        new Category(){Name="Beyaz Eşya",Url="beyaz-esya",Description="Beyaz Eşya kategorisi açıklama alanı burasıdır."},
    };
        private static Product[] Products = {
        new Product(){Name="Iphone 15 Pro Max", Url="iphone-15-pro-max",Price=64999,ImageUrl="1.png",Description="İyi telefon",IsApproved=true},
        new Product(){Name="Iphone 14 Plus",  Url="iphone-14-plus",Price=49999,ImageUrl="2.png",Description="İyi telefon",IsApproved=true},
        new Product(){Name="Iphone 13",  Url="iphone-13",Price=36999,ImageUrl="3.png",Description="İyi telefon",IsApproved=true},
        new Product(){Name="Iphone 12 Pro",  Url="iphone-12-pro",Price=52200,ImageUrl="4.png",Description="İyi telefon",IsApproved=true},
        new Product(){Name="Iphone 11",  Url="iphone-11",Price=24689,ImageUrl="5.png",Description="İyi telefon",IsApproved=false},
        new Product(){Name="Iphone 10",  Url="iphone-10",Price=12549,ImageUrl="6.png",Description="İyi telefon",IsApproved=false},
        new Product(){Name="Tulpar T5 V23.3 15,6\" Oyun Bilgisayarı", Url="tulpar-t5", Price=34399,ImageUrl="4.png",Description="Intel® Alder Lake Core™ i5-12450H 8C/12T; 12MB L3; E-CORE Max 3.30GHZ P-CORE Max 4.40GHZ; 45W NVIDIA® GeForce® RTX4060 Max-Performance 8GB GDDR6 128-Bit DX12",IsApproved=true},
        new Product(){Name="Aryond A24 V1.1 144 Hz Gaming Monitör",  Url="aryond-a24",Price=4999,ImageUrl="5.png",Description="24\" Çerçevesiz Flat Ekran 16:9, 144 Hz Ekran Yenileme Hızı, 1 Ms Tepki Süresi, FAST IPS Panel, 1920x1080 FHD Çözünürlük, Dikey Kullanım İmkanı, HDR10 ve MPRT Teknolojileri",IsApproved=true},
    };

        private static ProductCategory[] ProductCategories = {
            new ProductCategory(){Product= Products[0],Category=Categories[0]},
            new ProductCategory(){Product= Products[1],Category=Categories[0]},
            new ProductCategory(){Product= Products[2],Category=Categories[0]},
            new ProductCategory(){Product= Products[3],Category=Categories[0]},
            new ProductCategory(){Product= Products[4],Category=Categories[0]},
            new ProductCategory(){Product= Products[5],Category=Categories[0]},
            new ProductCategory(){Product= Products[6],Category=Categories[1]},
            new ProductCategory(){Product= Products[7],Category=Categories[1]},


        };
    }
}