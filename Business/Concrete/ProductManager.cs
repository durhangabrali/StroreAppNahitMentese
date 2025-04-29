
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    // Business katmanında Class'lar  Manager olarak tanımlanır.
    // Bir iş (businnes) sınıfında başka sınıflar new'lanmaz.
    // Onun yerine soyut bir referans tip tanımlanıp, constructor'da buna injeksiyon yapılır.
    // Soyut referans değişkeni InMemory'yi işaret edebileceği gibi, daha sonra eklenecek başka
    // sınıfarı da (örneğin Entity Franework veya Hibernate gibi) işaret edebilir.
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        //Contructor üzerinden productDal nesnesi enjekte edilir.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            // business code...
            _productDal.Add(product);
        }

        public List<Product> GetAll()
        {
            // İş kodları
            // Yetkisi var mı?
            return _productDal.GetAll();
        }
    }
}
