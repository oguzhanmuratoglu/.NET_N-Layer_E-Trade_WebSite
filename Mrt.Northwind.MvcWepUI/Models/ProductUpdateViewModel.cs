using Mrt.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Mrt.Northwind.MvcWepUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}