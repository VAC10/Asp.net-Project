using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
                _products = new List<Product> { 
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=25,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=2,ProductName="kamera",UnitPrice=75,UnitsInStock=7},
                new Product{ProductId=3,CategoryId=2,ProductName="bilgisayar",UnitPrice=45,UnitsInStock=1},
                new Product{ProductId=4,CategoryId=3,ProductName="masa",UnitPrice=44,UnitsInStock=25},
                };
        }

        public void add(Product product)
        {
            _products.Add(product); 
        }

        public void delete(Product product)
        {
           Product productToDelete=_products.SingleOrDefault(p=>p.ProductId==product.ProductId); 
            _products.Remove(productToDelete);  
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public void update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
