using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //Bu interface Ürünlerle ilgili temel veri operasyonlarını içerecektir
    public interface IProductDal
    {        
        List<Product> GetAll();        
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);  

    }
}
