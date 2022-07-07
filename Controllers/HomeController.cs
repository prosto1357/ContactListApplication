using ContactListApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace ContactListApplication.Controllers
{
    public class HomeController : Controller
    {
        ContactsContext db = new ContactsContext();
        public ActionResult Index()
        {
            var phoneNumbers = db.PhoneNumbers.Include(p => p.Contact);
            return View(phoneNumbers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList contacts = new SelectList(db.Contacts, "Id", "Fullname");
            ViewBag.Contacts = contacts;
            return View();
        }
        [HttpPost]
        public ActionResult Create(PhoneNumber phoneNumber)
        {
            PhoneNumber phoneNumberFound = db.PhoneNumbers.Where(p => p.pNumber == phoneNumber.pNumber).FirstOrDefault();
            if (phoneNumberFound != null || !Regex.IsMatch(phoneNumber.pNumber, @"^\+\d{1}-\d{3}-\d{3}-\d{2}-\d{2}", RegexOptions.IgnoreCase))
            {
                return RedirectToAction("index");
            }

            db.PhoneNumbers.Add(phoneNumber);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            PhoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            SelectList contacts = new SelectList(db.Contacts, "Id", "Fullname", phoneNumber.ContactId);
            ViewBag.Contacts = contacts;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(PhoneNumber phoneNumber)
        {
            PhoneNumber phoneNumberFound = db.PhoneNumbers.Where(p => p.pNumber == phoneNumber.pNumber).FirstOrDefault();
            if (phoneNumberFound != null || !Regex.IsMatch(phoneNumber.pNumber, @"^\+\d{1}-\d{3}-\d{3}-\d{2}-\d{2}", RegexOptions.IgnoreCase))
            {
                return RedirectToAction("index");
            }

            db.Entry(phoneNumber).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            PhoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }

            db.PhoneNumbers.Remove(phoneNumber);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}