using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Mrt.Northwind.Business.Abstract;
using Mrt.Northwind.DataAccess.Concrete.EntityFramework;
using Mrt.Northwind.Entities.Concrete;

namespace Mrt.Northwind.MvcWepUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int CurrentPage { get; internal set; }
    }
}
