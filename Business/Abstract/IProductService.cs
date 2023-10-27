using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Business.Abstract
{
    public interface IProductService : IValidator<Product>
    {
        Product GetProductById(int id);
        Product GetProductByIdWithCategories(int id);
        Product GetProductDetails(string url);
        List<Product> GetProductsByCategory(string name, int currentPage, int InitialItemPcs);
        List<Product> GetAll();
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);

        bool Create(Product entity);
        bool Update(Product entity);
        bool Update(Product entity, int[] categoryId);
        void Delete(Product entity);
        int GetCountByCategory(string category);
    }
}