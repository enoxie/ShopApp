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

        // [Display(Name = "Name", Prompt = "Enter product name")]
        // [Required(ErrorMessage = "Name alanı zorunlu bir alandır")]
        // [StringLength(60, MinimumLength = 5, ErrorMessage = "Ürün ismi en az 5-60 karakter aralığında olmalıdır")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url alanı zorunlu bir alandır")]
        [Display(Name = "URL", Prompt = "Enter product url")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Price alanı zorunlu bir alandır")]
        [Display(Name = "Price", Prompt = "Enter product price")]
        [Range(1, 300000, ErrorMessage = "Price için 1-300000 arasında değer girmelisiniz")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Description alanı zorunlu bir alandır")]
        [Display(Name = "Description", Prompt = "Enter product description")]
        public string Description { get; set; }


        [Display(Name = "ImageURL", Prompt = "Enter product ImageUrl")]
        public string? ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<Category> SelectedCategories { get; set; }



    }
}