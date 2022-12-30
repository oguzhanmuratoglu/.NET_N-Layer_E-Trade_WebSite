using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mrt.Northwind.Business.Abstract;
using Mrt.Northwind.DataAccess.Abstract;
using Mrt.Northwind.Entities.Concrete;

namespace Mrt.Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId || categoryId==0);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product{ProductId = productId});
        }

        public Product GetById(int productId)
        {
           var result = _productDal.Get(p => p.ProductId == productId);
           return result;
        }
    }
}
