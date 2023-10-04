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

        public Product GetProductByIdWithCategories(int id)
        {
            using (var db = new ShopContext())
            {
                return db.Products
                         .Where(i => i.ProductId == id)
                         .Include(i => i.ProductCategories)
                         .ThenInclude(i => i.Category)
                         .FirstOrDefault();
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

        public void Update(Product entity, int[] categoryId)
        {
            using (var db = new ShopContext())
            {
                var product = db.Products
                .Include(i => i.ProductCategories)
                .FirstOrDefault(i => i.ProductId == entity.ProductId);

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.Description = entity.Description;
                    product.Url = entity.Url;
                    product.ImageUrl = entity.ImageUrl;
                    product.ProductCategories = categoryId.Select(catid => new ProductCategory()
                    {
                        ProductId = entity.ProductId,
                        CategoryId = catid
                    }).ToList();
                    db.SaveChanges();
                }
            }
        }
    }
}