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
    }
}