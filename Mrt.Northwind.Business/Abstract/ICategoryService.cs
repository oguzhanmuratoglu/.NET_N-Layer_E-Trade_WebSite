using System.Collections.Generic;
using Mrt.Northwind.Entities.Concrete;

namespace Mrt.Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}