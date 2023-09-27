using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Ürün adı girmelisiniz")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Ürün ismi için en az 5 en fazla 40 karakter giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fiyat alanı zorunludur")]
        public double? Price { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Açıklama girmelisiniz")]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        [Required(ErrorMessage = "Kategori girmelisiniz")]
        public int? CategoryId { get; set; }


    }
}