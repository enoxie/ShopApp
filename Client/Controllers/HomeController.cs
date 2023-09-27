using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Data;
using ShopApp.Models;
namespace ShopApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            var productView = new ProductViewModel()
            {
                Products = ProductRepository.Products

            };
            return View(productView);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}