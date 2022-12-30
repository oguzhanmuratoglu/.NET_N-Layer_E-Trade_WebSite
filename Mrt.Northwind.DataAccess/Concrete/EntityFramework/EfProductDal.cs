using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mrt.Core.DataAccess.EntityFramework;
using Mrt.Northwind.DataAccess.Abstract;
using Mrt.Northwind.Entities.Concrete;

namespace Mrt.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {

    }
}
