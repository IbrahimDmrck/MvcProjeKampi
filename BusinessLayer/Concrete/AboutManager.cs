using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutDelete(About about)
        {
            _aboutDal.Update(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }

        public void AddAboutBL(About about)
        {
            _aboutDal.Insert(about);
        }

        public List<About> GetAboutList()
        {
            return _aboutDal.List();
        }

        public About GetByID(int id)
        {
            return _aboutDal.Get(x => x.AboutID == id); ;
        }
    }
}
