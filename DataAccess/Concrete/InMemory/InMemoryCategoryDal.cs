using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCategoryDal : ICategoryDal
    {
        List<Category> _categories;

        public InMemoryCategoryDal()
        {
            _categories = new List<Category>
            {
               new Category{CategoryId = 1 , CategoryName = "Cep Telefonu"},
               new Category{CategoryId = 2 , CategoryName = "Dizüstü Bilgisayar"},
               new Category{CategoryId = 3 , CategoryName = "Beyaz Eşya"}
            };
        }

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Delete(Category category)
        {
            //Silinecekcategory bulunur            //LINQ - Languqage Integrated Query
            Category categoryToDelete = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            _categories.Remove(categoryToDelete);
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public void Update(Category category)
        {
            //Güncellenecek category bulunur        //LINQ - Languqage Integrated Query
            Category categoryToUpdate = _categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            //Güncelleme yapılır
            categoryToUpdate.CategoryName = category.CategoryName;
            
        }
    }
}
