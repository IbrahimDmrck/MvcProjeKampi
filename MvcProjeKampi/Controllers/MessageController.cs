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
    public class MessageController : Controller
    {
        MessageValidator validation = new MessageValidator();
        DraftMessageValidator draftValidation = new DraftMessageValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        // GET: Message


        [Authorize]
        public ActionResult InBox(string p)
        {
            var messageList = messageManager.GetMessageInBoxList(p);
            return View(messageList);
        }

        public PartialViewResult PartialCountInBoxMessage()
        {
            Context context = new Context();
            var unreadMessage = context.Messages.Where(x => x.ReceiverMail == "aslkaya@gmail.com" && x.MessageStatus == false).Count();
            ViewBag.unreadMessage = unreadMessage;
            return PartialView();
        }

        public ActionResult SendBox(string p)
        {
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

        [HttpGet]
        public ActionResult AddDrafts()
        {

            return RedirectToAction("InBox");
        }

        [HttpPost]
        public ActionResult AddDrafts(Message message)
        {
          
            ValidationResult result = draftValidation.Validate(message);
            if (result.IsValid)
            {

                messageManager.AddDraftsMessage(message);
                return RedirectToAction("ListDrafts");
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

        public ActionResult ListDrafts()
        {
            var draftMessageList = messageManager.GetDraftBoxList();
            return View(draftMessageList);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult result = validation.Validate(message);
            if (result.IsValid)
            {
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
    }
}