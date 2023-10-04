using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string url);
        Product GetProductByIdWithCategories(int id);
        List<Product> GetProductsByCategory(string name, int currentPage, int InitialItemPcs);
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);
        int GetCountByCategory(string category);
        void Update(Product entity, int[] categoryId);


    }
}