using Mrt.Core.DataAccess.EntityFramework;
using Mrt.Northwind.DataAccess.Abstract;
using Mrt.Northwind.Entities.Concrete;

namespace Mrt.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {

    }
}