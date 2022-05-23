using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        MessageValidator validation = new MessageValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
      

        // GET: WriterPanelMessage
        public ActionResult InBox()
        {
            string p = (string)Session["WriterEmail"];
            var messageList = messageManager.GetMessageInBoxList(p);
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            string p = (string)Session["WriterEmail"];
            var messageList = messageManager.GetMessageSendBoxList(p);
            return View(messageList);
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var Value = messageManager.GetByID(id);
            return View(Value);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var Value = messageManager.GetByID(id);
            return View(Value);
        }

        public PartialViewResult InBoxPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string senderSession = (string)Session["WriterEmail"];
            ValidationResult result = validation.Validate(message);
            if (result.IsValid)
            {
                message.SenderMail = senderSession;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.AddMessageBL(message);
                return RedirectToAction("SendBox");

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


        public ActionResult DeleteMessage(int id)
        {
            var message = messageManager.GetByID(id);
            if (message.MessageStatus == true)
            {
                message.MessageStatus = false;
                messageManager.MessageDelete(message);
            }
            else
            {
                message.MessageStatus = true;
                messageManager.MessageDelete(message);
            }

            return RedirectToAction("InBox");
        }
    }
}