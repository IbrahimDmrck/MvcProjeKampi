using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        Context context = new Context();
 
        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterEmail"];
            id = context.Writers.Where(x => x.WriterEmail == p).Select(y => y.WriterID).FirstOrDefault();
            var writervalue = writerManager.GetById(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator validation = new WriterValidator();
            ValidationResult result = validation.Validate(writer);
            if (result.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("WriterProfile");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                
                }
                Response.Write("<script language=\"javascript\">alert(\"İşlem Başarısız ! ,Bilgilerinizi Kontrol Edip Tekrara Deneyin\")</script>");
            }


            return View();
        }

        public ActionResult MyHeading(string p)
        {
           
            p = (string)Session["WriterEmail"];
             var writerIdInfo = context.Writers.Where(x => x.WriterEmail == p).Select(y => y.WriterID).FirstOrDefault();
            var value = headingManager.GetListByWriter(writerIdInfo);
            return View(value);
        }

        [HttpGet]
        public ActionResult NewHeading()
        { 
            List<SelectListItem> selectListCategory = (from x in categoryManager.GetCategoryList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryID.ToString()
                                                       }).ToList();
            ViewBag.vlc = selectListCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMailInfo = (string)Session["WriterEmail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterEmail == writerMailInfo).Select(y => y.WriterID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writerIdInfo;
            heading.HeadingStatus = true;   
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");   
        
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

            HeadingValidator validations = new HeadingValidator();
            ValidationResult result = validations.Validate(heading);
            if (result.IsValid)
            {
                headingManager.HeadingUpdate(heading);
                return RedirectToAction("MyHeading");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetByID(id);
            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
                headingManager.HeadingDelete(headingValue);
            }
            else
            {
                headingValue.HeadingStatus = true;
                headingManager.HeadingDelete(headingValue);
            }


            return RedirectToAction("MyHeading");

        }

        public ActionResult AllHeading(int page=1)
        {
            var headingList = headingManager.GetHeadingList().ToPagedList(page,6);
            return View(headingList);
        }

    }
}