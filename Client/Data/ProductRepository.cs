using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApp.Models;

namespace ShopApp.Data
{
    public static class ProductRepository
    {
        private static List<Product> _products = null;

        static ProductRepository()
        {
            _products = new List<Product>{
                new Product() {
                ProductId=1,
                Name = "Iphone 15 Pro Max",
                Price = 87000,
                Description = "Pahalı telefon",
                ImageUrl = "4.png",
                CategoryId=1,
                },
                new Product() {
                ProductId=2,
                Name = "Iphone 14 Pro Max",
                Price = 6000,
                Description = "Orta telefon",
                IsApproved = true,
                ImageUrl = "2.png",
                CategoryId=1
                },
                 new Product() {
                ProductId=3,
                Name = "Iphone 13 Pro Max",
                Price = 6000,
                Description = "Kötü telefon",
                IsApproved = true,
                ImageUrl = "1.png",
                CategoryId=1
                },
                new Product() {
                ProductId=4,
                Name = "Monster Notebook",
                Price = 87000,
                Description = "Pahalı telefon",
                ImageUrl = "5.png",
                CategoryId=2
                },
                new Product() {
                ProductId=5,
                Name = "Lenova Notebook",
                Price = 6000,
                Description = "Orta telefon",
                IsApproved = true,
                ImageUrl = "6.png",
                CategoryId=2
                },
                new Product() {
                ProductId=6,
                Name = "Macbook Air",
                Price = 6000,
                Description = "Kötü telefon",
                IsApproved = true,
                ImageUrl = "7.png",
                CategoryId=2
                }
            };
        }
        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public static Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.ProductId == id);
        }

        public static void EditProduct(Product product)
        {

            foreach (var p in _products)
            {
                if (p.ProductId == product.ProductId)
                {
                    p.Name = product.Name;
                    p.Description = product.Description;
                    p.Price = product.Price;
                    p.ImageUrl = product.ImageUrl;
                    p.IsApproved = product.IsApproved;
                    p.CategoryId = product.CategoryId;
                }
            }
        }

        public static void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

    }
}