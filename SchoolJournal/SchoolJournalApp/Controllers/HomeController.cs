using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
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