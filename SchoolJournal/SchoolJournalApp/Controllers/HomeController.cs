using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var person = manager.Get(id);
            return View(person);
        }

        [HttpPost]
        public ActionResult Update(Persons person)
        {
            if (ModelState.IsValid)
            {
                manager.Save(person);
                return Redirect("Details");
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