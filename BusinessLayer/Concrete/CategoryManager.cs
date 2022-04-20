using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetALLBL()
        //{
        //    return repo.List();
        //}

        //public void CategoryAddBL(Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >=51)
        //    {
        //        //Hata Mesajı
        //    }
        //    else
        //    {
        //        repo.Insert(p);
        //    }
        //}

        readonly ICategoryDal _categoryDal;

   

        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }

       

        public void AddCategoryBL(Category category)
        {
            _categoryDal.Insert(category);
        }

       

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetCategoryList()
        {
            return _categoryDal.List();
        }
    }
}
