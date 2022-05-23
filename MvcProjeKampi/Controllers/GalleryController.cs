using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ımageFileManager = new ImageFileManager(new EfImageDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var files = ımageFileManager.GetList();
            return View(files);
        }
    }
}