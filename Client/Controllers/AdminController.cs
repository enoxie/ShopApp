using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Client.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult ProductList()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAll()
            });
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            var entity = new Product()
            {
                Name = model.Name,
                Url = model.Url,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl
            };
            _productService.Create(entity);
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün başarıyla oluşturuldu.",
                AlertType = "success"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult EditProduct(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetProductByIdWithCategories((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new ProductModel()
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Url = entity.Url,
                Price = entity.Price,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                SelectedCategories = entity.ProductCategories.Select(i => i.Category).ToList()

            };
            ViewBag.Categories = _categoryService.GetAllCategories();

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductModel model, int[] categoryId)
        {
            var entity = _productService.GetProductById(model.ProductId);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            entity.Url = model.Url;
            entity.Price = model.Price;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            _productService.Update(entity, categoryId);
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün başarıyla güncellendi.",
                AlertType = "success"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("ProductList");

        }

        public IActionResult DeleteProduct(int ProductId)
        {
            var entity = _productService.GetProductById(ProductId);
            if (entity == null)
            {
                return NotFound();
            }
            _productService.Delete(entity);
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün başarıyla silindi.",
                AlertType = "danger"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("ProductList");

        }

        public IActionResult CategoryList()
        {

            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAllCategories()
            });

        }


        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _categoryService.GetByIdWithProducts((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new CategoryModel()
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Url = entity.Url,
                Description = entity.Description,
                Products = entity.ProductCategories.Select(i => i.Product).ToList()
            };
            return View(model);

        }

        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetCategoryById(model.CategoryId);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            entity.Url = model.Url;
            entity.Description = model.Description;
            _categoryService.Update(entity);
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli kategori başarıyla güncellendi.",
                AlertType = "success"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int CategoryId)
        {
            var entity = _categoryService.GetCategoryById(CategoryId);
            if (entity == null)
            {
                return NotFound();
            }
            _categoryService.Delete(entity);
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün başarıyla silindi.",
                AlertType = "danger"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("CategoryList");

        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name,
                Url = model.Url,
                Description = model.Description,
            };
            _categoryService.Create(entity);
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli kategori başarıyla oluşturuldu.",
                AlertType = "success"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteProductFromCategory(int ProductId, int CategoryId)
        {

            _categoryService.DeleteProductFromCategory(ProductId, CategoryId);
            return Redirect("/admin/categories/" + CategoryId);
        }


    }
}