using Mrt.Core.DataAccess;
using Mrt.Northwind.Entities.Concrete;

namespace Mrt.Northwind.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        //Custom Operations
    }
}