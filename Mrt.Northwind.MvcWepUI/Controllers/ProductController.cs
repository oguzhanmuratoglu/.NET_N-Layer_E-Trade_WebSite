﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mrt.Northwind.Business.Abstract;
using Mrt.Northwind.MvcWepUI.Models;

namespace Mrt.Northwind.MvcWepUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int page=1, int category=0)
        {
            int pageSize = 10;
            var products = _productService.GetByCategory(category);  
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page-1)*pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count/(double)pageSize),
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page
            };
            
            return View(model);
        }
    }
}
