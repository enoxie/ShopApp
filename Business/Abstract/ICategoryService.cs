using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category GetByIdWithProducts(int categoryId);
        void DeleteProductFromCategory(int ProductId, int CategoryId);
    }
}