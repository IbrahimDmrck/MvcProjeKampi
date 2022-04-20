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
    public class StatistikController : Controller
    {

        Context context = new Context();
        public int id;
        // GET: Istatistik
        public ActionResult Index()
        {
           

            var ctgCount = context.Categories.Count();
            var headSoftWare = context.Headings.Where(x => x.Category.CategoryName == "Yazılm").Count();
            var writerName = context.Writers.Where(x => x.WriterName.Contains("a")).Count();
            var trueCategory = context.Categories.Where(x => x.CategoryStatus == true).Count();
            var falseCategory = context.Categories.Where(x => x.CategoryStatus == false).Count();
            var true_false_result = trueCategory - falseCategory;
            var most_Head_Category_Name = context.Headings.GroupBy(x => x.CategoryID).Select(a => new { a.Key, Count = a.Count() }).ToList();

            int max = 0;
            foreach (var item in most_Head_Category_Name)
            {
                if (item.Count>max)
                {
                    max = item.Count;
                    id = item.Key;
                }
            }
            var categoryName = context.Categories.Where(x => x.CategoryID == id).Select(a => a.CategoryName).FirstOrDefault();

            ViewBag.ctgCount = ctgCount;
            ViewBag.headSoftWare = headSoftWare;
            ViewBag.writerName = writerName;
            ViewBag.categoryName = categoryName;
            ViewBag.true_false_result = true_false_result;

            return View("Index");
        }
    }
}