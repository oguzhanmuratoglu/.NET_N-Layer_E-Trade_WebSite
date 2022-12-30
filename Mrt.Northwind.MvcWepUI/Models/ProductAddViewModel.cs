using System.Collections.Generic;
using Mrt.Northwind.Entities.Concrete;

namespace Mrt.Northwind.MvcWepUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}