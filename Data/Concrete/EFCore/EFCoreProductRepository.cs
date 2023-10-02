using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EFCore
{
    public class EFCoreProductRepository : EFCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public int GetCountByCategory(string category)
        {
            using (var db = new ShopContext())
            {
                var products = db.Products
                .Where(i => i.IsApproved)
                .AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Where(i => i.ProductCategories.Any(a => a.Category.Url == category));
                }
                return products.Count();
            }
        }

        public List<Product> GetHomePageProducts()
        {
            using (var db = new ShopContext())
            {
                return db.Products
                .Where(i => i.IsApproved && i.IsHome)
                .ToList();
            }
        }


        public Product GetProductDetails(string url)
        {
            using (var db = new ShopContext())
            {
                return db.Products
                .Where(i => i.Url == url)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string name, int currentPage, int InitialItemPcs)
        {
            using (var db = new ShopContext())
            {
                var products = db.Products
                .Where(i => i.IsApproved)
                .AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    products = products
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Where(i => i.ProductCategories.Any(a => a.Category.Url == name));
                }
                return products.Skip((currentPage - 1) * InitialItemPcs).Take(InitialItemPcs).ToList();
            }
        }

        public List<Product> GetSearchResult(string searchString)
        {
            using (var db = new ShopContext())
            {
                var products = db
                .Products
                .Where(i => i.IsApproved && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower())))
                .AsQueryable();
                return products.ToList();
            }
        }
    }
}