using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Client.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;

        public ShopController(IProductService productService)
        {
            this._productService = productService;
        }

        public IActionResult List(string category, int currentPage = 1)
        {
            const int InitialItemPcs = 4;
            var productView = new ProductListViewModel()
            {
                Products = _productService.GetProductsByCategory(category, currentPage, InitialItemPcs),
                PageInfo = new PageInfo
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = currentPage,
                    ItemsPerPage = InitialItemPcs,
                    CurrentCategory = category
                }
            };
            return View(productView);
        }

        public IActionResult Details(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails(url);

            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailModel
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });
        }

        public IActionResult Search(string q)
        {

            var productView = new ProductListViewModel()
            {
                Products = _productService.GetSearchResult(q)

            };
            return View(productView);
        }

    }
}