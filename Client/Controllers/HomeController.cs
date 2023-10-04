using System;
using System.Collections.Generic;
using Business.Abstract;
using Client.Models;
using Data.Abstract;
using Microsoft.AspNetCore.Mvc;



namespace ShopApp.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult Index()
        {

            var productView = new ProductListViewModel()
            {
                Products = _productService.GetHomePageProducts()
            };
            return View(productView);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}