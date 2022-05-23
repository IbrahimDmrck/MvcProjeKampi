using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterEmail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterEmail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentValue = contentManager.GetListByWriter(writerIdInfo);
            return View(contentValue);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterEmail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterEmail == mail).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writerIdInfo;
            content.ContenStatus = true;
            contentManager.AddContentBL(content);
            return RedirectToAction("MyContent");
        }

        [HttpGet]
        public ActionResult EditContent(int id)
        {


            var contentValue = contentManager.GetByID(id);
            return View(contentValue);
        }

        [HttpPost]
        public ActionResult EditContent(Content content)
        {
            string mail = (string)Session["WriterEmail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterEmail == mail).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writerIdInfo;
            content.ContenStatus = true;
            contentManager.ContentUpdate(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult DeleteContent(int id)
        {
            var contentValue = contentManager.GetByID(id);
            contentManager.ContentDelete(contentValue);
            return RedirectToAction("MyContent");
        }

    }
}