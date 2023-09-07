using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var model = TempData["NewModel"] as ProductViewModel;
            if (model == null)
            { 
                var products = _context.Products.ToList();
             model = new ProductViewModel
            {
                DropdownOptions = new List<string>
                {
                    "ProductName",
                    "Size",
                    "Price",
                    "MfgDate",
                    "Category"
                },
                Product = products
            };
        }
            return View(model);
        }

       
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            var products = _context.Products.ToList();
            if(model.SelectedOption == "ProductName")
                products=products.Where(p=>p.ProductName.ToLower().Contains(model.TextField.ToLower()))
                                 .ToList();
            if (model.SelectedOption == "Size")
                products = products.Where(p => p.Size.ToLower().Contains(model.TextField.ToLower()))
                                 .ToList();
            if (model.SelectedOption == "Category")
                products = products.Where(p => p.Category.ToLower().Contains(model.TextField.ToLower()))
                                 .ToList();
            else if (model.SelectedOption == "Price")
            {
                
                decimal priceFilter;
                if (decimal.TryParse(model.TextField, out priceFilter))
                {
                    products = products.Where(p => p.Price == priceFilter)
                                      .ToList();
                }
               
            }
            else if (model.SelectedOption == "MfgDate")
            {
               
                DateTime mfgDateFilter;
                if (DateTime.TryParse(model.TextField, out mfgDateFilter))
                {
                    products = products.Where(p => p.MfgDate == mfgDateFilter)
                                      .ToList();
                }
              
            }

            var newModel = new ProductViewModel
            {
                DropdownOptions = new List<string>
                {
                    "ProductName",
                    "Size",
                    "Price",
                    "MfgDate",
                    "Category"
                },
                Product = products
            };
            TempData["NewModel"] = newModel;
            return RedirectToAction("Index");
        }
    }
}