using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["action"].ToString().ToLower() == "list")
            {
                ViewBag.SelectedCategory = "0";
                if (RouteData.Values["id"] != null)
                {
                    ViewBag.SelectedCategory = RouteData?.Values["id"];
                }

            }

            return View(CategoryRepository.Categories);
        }
    }
}