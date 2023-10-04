using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EFCore
{
    public class EFCoreCategoryRepository : EFCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public void DeleteProductFromCategory(int ProductId, int CategoryId)
        {
            using (var db = new ShopContext())
            {
                var cmd = "DELETE from productcategory where ProductId=@p0 and CategoryId=@p1";
                db.Database.ExecuteSqlRaw(cmd, ProductId, CategoryId);

            }
        }

        public Category GetByIdWithProducts(int categoryId)
        {
            using (var db = new ShopContext())
            {
                return db.Categories
                .Where(i => i.CategoryId == categoryId)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Product)
                .FirstOrDefault();
            }
        }
    }
}