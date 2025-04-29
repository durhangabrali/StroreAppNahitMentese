using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;


namespace Business.Concrete
{
    // Business katmanında Class'lar  Manager olarak tanımlanır.
    // Bir iş (businnes) sınıfında başka sınıflar new'lanmaz.
    // Onun yerine soyut bir referans tip tanımlanıp, constructor'da buna injeksiyon yapılır.
    // Soyut referans değişkeni InMemory'yi işaret edebileceği gibi, daha sonra eklenecek başka
    // sınıfarı da (örneğin Entity Franework veya Hibernate gibi) işaret edebilir.
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        //Contructor üzerinden categoryDal nesnesi enjekte edilir.
        public CategoryManager(ICategoryDal categoryDal)
        {
            // business code...
            _categoryDal = categoryDal;
        }
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public List<Category> GetAll()
        {
            // business code...
            return _categoryDal.GetAll();
        }
    }
}
