using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournalApp.Controllers
{
    public class PersonsController : Controller
    {
        private IPersonsManager manager;

        public PersonsController()
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
        public ActionResult Update([Bind(Include = "PersonID,PersonName,PersonEmail,PersonPhone,PersonAddress")]Persons person)
        {
            if (ModelState.IsValid)
            {
                manager.Save(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError=false)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed! Try again or see your sysadmin!";
            //var person = manager.Get(id);
            Persons person = manager.Get(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                manager.Delete(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete",new { id, saveChangesError=true});
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "PersonName,PersonEmail,PersonPhone,PersonAddress")]Persons person)
        {
            if (ModelState.IsValid)
            {
                manager.Add(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }
    }
}