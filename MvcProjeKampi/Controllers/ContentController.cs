using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetAllContent(string p)
        {

                var values = contentManager.GetContentList(p);
                return View(values.ToList());

        }
   
        public ActionResult ContentByHeading(int id)
        {
            var contentValue = contentManager.GetListByHeadingID(id);
            return View(contentValue);
        }
    }
}