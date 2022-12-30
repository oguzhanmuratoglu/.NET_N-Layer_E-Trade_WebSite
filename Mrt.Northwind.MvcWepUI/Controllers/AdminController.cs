using Microsoft.AspNetCore.Mvc;
using Mrt.Northwind.Business.Abstract;
using Mrt.Northwind.Entities.Concrete;
using Mrt.Northwind.MvcWepUI.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Mrt.Northwind.MvcWepUI.Controllers
{
    [Authorize (Roles= "Editor")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };

            return View(productListViewModel);
        }

        public IActionResult Add()
        {
            var productAddViewModel = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()

            };
            return View(productAddViewModel);
        }


        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("massage", String.Format("Your product , {0} , was successfully added!", product.ProductName));
            }

            return RedirectToAction("Add");

        }

        public IActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("massage", String.Format("Your product , {0} , was successfully updated!", product.ProductName));
            }

            return RedirectToAction("Update");

        }

        public IActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            TempData.Add("massage", "Your product was successfully deleted!");
            return RedirectToAction("Index");
            

        }
    }
}
