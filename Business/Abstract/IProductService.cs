using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        Product GetProductDetails(string url);
        List<Product> GetProductsByCategory(string name, int currentPage, int InitialItemPcs);
        List<Product> GetAll();
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);

        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        int GetCountByCategory(string category);
    }
}