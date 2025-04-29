using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    //DAL : Data Access Layer
    //DAO : Data Acces Object
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId = Guid.NewGuid(), CategoryId = 1, ProductName="Bardak", UnitPrice=150, UnitsInStock=15},
                new Product{ProductId = Guid.NewGuid(), CategoryId = 1, ProductName="Kamera", UnitPrice=800, UnitsInStock=3},
                new Product{ProductId = Guid.NewGuid(), CategoryId = 2, ProductName="Telefon", UnitPrice=15000, UnitsInStock=2},
                new Product{ProductId = Guid.NewGuid(), CategoryId = 2, ProductName="Klavye", UnitPrice=1500, UnitsInStock=65},
                new Product{ProductId = Guid.NewGuid(), CategoryId = 2, ProductName="Fare", UnitPrice=1000, UnitsInStock=40}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Silinecek ürün bulunur            //LINQ - Languqage Integrated Query
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Güncellenecek ürün bulunur        //LINQ - Languqage Integrated Query
            Product productToUpdate = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            //Güncelleme yapılır
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
