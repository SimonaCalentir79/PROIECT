using SchoolJournalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolJournalDBAccess;

namespace SchoolJournalApp.Controllers
{
    public class HomeController : Controller
    {
        private IPersonManager manager;

        public HomeController()
        {
            manager = new PersonManager();
        }

        public ActionResult Index()
        {
            IList<Person> persons = manager.GetAll();

            return View(persons);
        }

        public ActionResult Details(int id)
        {
            var person = manager.Get(id);
            return View(person);
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            if (id == 0)
                return View();

            var person = manager.Get(id);
            return View(person);
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            if (ModelState.IsValid)
            {
                //manager.Save(person);
                return Redirect("Index");
            }

            return View(person);
        }
    }
}