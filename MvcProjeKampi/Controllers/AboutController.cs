using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutValidator validator = new AboutValidator(); 
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        // GET: About
        public ActionResult Index()
        {
            var aboutvalue = aboutManager.GetAboutList();
            return View(aboutvalue);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var aboutVale = aboutManager.GetByID(id);
            if (aboutVale.AboutStatus == true)
            {
                aboutVale.AboutStatus = false;
                aboutManager.AboutDelete(aboutVale);
            }
            else
            {
                aboutVale.AboutStatus = true;
                aboutManager.AboutDelete(aboutVale);
            }


            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {

            ValidationResult result = validator.Validate(about);
            if (result.IsValid)
            {

                aboutManager.AddAboutBL(about);
                return RedirectToAction("Index");

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

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}