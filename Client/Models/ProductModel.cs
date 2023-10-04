using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Client.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Display(Name = "Name", Prompt = "Enter product name")]
        public string Name { get; set; }
        [Display(Name = "URL", Prompt = "Enter product url")]
        public string Url { get; set; }
        [Display(Name = "Price", Prompt = "Enter product price")]
        public double? Price { get; set; }
        [Display(Name = "Description", Prompt = "Enter product description")]
        public string Description { get; set; }
        [Display(Name = "ImageURL", Prompt = "Enter product ImageUrl")]
        public string ImageUrl { get; set; }
        public List<Category> SelectedCategories { get; set; }



    }
}