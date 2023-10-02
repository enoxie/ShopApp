using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace ShopApp.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = "0";
            if (RouteData.Values["category"] != null)
            {

                if (RouteData.Values["category"] != null)
                {
                    ViewBag.SelectedCategory = RouteData?.Values["category"];
                }

            }
            return View(_categoryService.GetAll());
        }
    }
}