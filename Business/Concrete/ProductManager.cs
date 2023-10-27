using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Data.Concrete.EFCore;
using Entity;
namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;


        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool Create(Product entity)
        {
            if (Validation(entity))
            {
                _productRepository.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productRepository.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()
        {
            return _productRepository.GetHomePageProducts();
        }

        public Product GetProductDetails(string url)
        {
            return _productRepository.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name, int currentPage, int InitialItemPcs)
        {
            return _productRepository.GetProductsByCategory(name, currentPage, InitialItemPcs);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            return _productRepository.GetSearchResult(searchString);
        }

        public bool Update(Product entity)
        {
            _productRepository.Update(entity);
            return true;
        }
        public bool Update(Product entity, int[] categoryId)
        {
            if (Validation(entity))
            {
                if (categoryId.Length == 0)
                {
                    ErrorMessage += "Ürün için en az bir kategori seçmelisiniz";
                    return false;
                }
                _productRepository.Update(entity, categoryId);
                return true;
            }
            return false;

        }

        public Product GetProductByIdWithCategories(int id)
        {
            return _productRepository.GetProductByIdWithCategories(id);
        }

        public string ErrorMessage { get; set; }
        public bool Validation(Product entity)
        {
            var isValid = true;
            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "ürün ismi girmelisiniz. \n";
                isValid = false;

            }
            if (entity.Price < 0)
            {
                ErrorMessage += "Ürün fiyatı negatif olamaz. \n";
                isValid = false;
            }
            return isValid;
        }

    }
}