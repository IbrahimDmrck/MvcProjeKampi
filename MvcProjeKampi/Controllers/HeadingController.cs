using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: Heading
        public ActionResult Index()
        {
            var headingValue = headingManager.GetHeadingList();
            return View(headingValue);
        }

        public ActionResult HeadingReport()
        {
            var headingValue = headingManager.GetHeadingList();
            return View(headingValue);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> selectListCategory = (from x in categoryManager.GetCategoryList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryID.ToString()
                                                       }).ToList();

            List<SelectListItem> selectListWriter = (from x in writerManager.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.WriterName + " " + x.WriterSurName,
                                                         Value = x.WriterID.ToString()
                                                     }).ToList();

            ViewBag.vlc = selectListCategory;
            ViewBag.vlw = selectListWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> selectListCategory = (from x in categoryManager.GetCategoryList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryID.ToString()
                                                       }).ToList();

            ViewBag.vlc = selectListCategory;

            var headingValue = headingManager.GetByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetByID(id);
            if (headingValue.HeadingStatus==true)
            {
                headingValue.HeadingStatus = false;
                headingManager.HeadingDelete(headingValue);
            }
            else
            {
                headingValue.HeadingStatus = true;
                headingManager.HeadingDelete(headingValue);
            }

          
            return RedirectToAction("Index");
             
        }

    }
}