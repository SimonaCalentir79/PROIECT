using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournalApp.Controllers
{
    public class HomeController : Controller
    {
        private IPersonsManager manager;

        public HomeController()
        {
            manager = new PersonsManager();
        }

        public ActionResult Index()
        {
            var persons = manager.GetAllPersons();
            return View(persons);
        }

        public ActionResult Details(int id)
        {
            var person = manager.Get(id);
            return View(person);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = manager.Get(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include ="PersonID,PersonName,PersonEmail,PersonPhone,PersonAddress")]Persons person)
        {
            if (ModelState.IsValid)
            {
                manager.Save(person);
                return RedirectToAction("Index");
            }
            return View(person);
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