using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Client.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [Display(Name = "Name", Prompt = "Enter category name")]
        public string Name { get; set; }
        [Display(Name = "URL", Prompt = "Enter category URL")]
        public string Url { get; set; }
        [Display(Name = "Description", Prompt = "Enter category Description")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }


    }
}