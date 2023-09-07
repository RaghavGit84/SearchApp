using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public DateTime MfgDate { get; set; }
        public string Category { get; set; }
    }
    public class ProductViewModel
    {
        public string TextField { get; set; }
        public List<string> DropdownOptions { get; set; }
        public string SelectedOption { get; set; }
        public List<ProductModel> Product { get; set; }
    }

       
}