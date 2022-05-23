using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        Context context = new Context();

        // GET: Contact
        public ActionResult Index()
        {
            var contactValue = contactManager.GetContactList();
            return View(contactValue);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValue = contactManager.GetByID(id);
            return View(contactValue);
        }

        public ActionResult DeleteContact(int id)
        {
            var contact = contactManager.GetByID(id);
            if (contact.StatusContaactMessage == true)
            {
                contact.StatusContaactMessage = false;
                contactManager.ContactDelete(contact);
            }
            else
            {
                contact.StatusContaactMessage = true;
                contactManager.ContactDelete(contact);
            }

            return RedirectToAction("Index");
        }


        public PartialViewResult InBoxPartial()
        {

            var countAdminSendMessage = context.Messages.Where(x => x.SenderMail == "admin@gmail.com").Count();
            var countAdminReceiverMail = context.Messages.Where(x => x.ReceiverMail == "admin@gmail.com").Count();
            var countContact = context.Contacts.Count();

            var unreadContactMessage = context.Contacts.Where(x =>x.StatusContaactMessage == false).Count();


            ViewBag.unreadContactMessage = unreadContactMessage;

            ViewBag.countAdminReceiverMail = countAdminReceiverMail;
            ViewBag.countAdminSendMessage = countAdminSendMessage;
            ViewBag.countContact = countContact;

            return PartialView();
        }
    }
}