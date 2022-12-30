using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Mrt.Northwind.Entities.Concrete;

namespace Mrt.Northwind.MvcWepUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; set; }
    }
}
