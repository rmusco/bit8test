using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web.Mvc;
using JsonDataService.Interfaces;
using JsonDataService.Models;

namespace JsonDataWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PersonList()
        {
            return View();
        }

        public ActionResult PersonDetail2(int id)
        {
            ViewBag.PersonId = id;
            return View();
        }

        public ActionResult PersonDetail(int id)
        {
            try
            {
                var obj = _personService.GetByID(id);
                return View(obj);
            }
            catch
            {
                return View("Error", new HandleErrorInfo(new Exception("Not possible to Get Person by this id: " + id), "Home", "PersonDetail"));
            }
        }

        public ActionResult PersonCreate()
        {
            var model = new PersonModel();
            model.Guid = Guid.NewGuid();
            return View();
        }

        [HttpPost]
        public ActionResult PersonCreate(PersonModel model)
        {
            try
            {
                var obj = _personService.Insert(model);
                return RedirectToAction("PersonList");
            }
            catch
            {
                return View("Error", new HandleErrorInfo(new Exception("Not possible to create Person"), "Home", "PersonCreate"));
            }
        }

        public ActionResult PersonEdit(int id)
        {
            try
            {
                var obj = _personService.GetByID(id);
                return View(obj);
            }
            catch
            {
                return View("Error", new HandleErrorInfo(new Exception("Not possible to Get Person by this id: " + id), "Home", "PersonDetail"));
            }
        }

        [HttpPost]
        public ActionResult PersonEdit(PersonModel model)
        {
            try
            {
                model.Tags = model.TagsString.Split(',').ToList();
                var obj = _personService.Update(model);
                return RedirectToAction("PersonList");
            }
            catch
            {
                return View("Error", new HandleErrorInfo(new Exception("Not possible to edit Person"), "Home", "PersonEdit"));
            }
        }

        public ActionResult PersonDelete(int id)
        {
            try
            {
                _personService.Delete(id);
                return RedirectToAction("PersonList");
            }
            catch
            {
                return View("Error", new HandleErrorInfo(new Exception("Not possible to delete Person: " + id), "Home", "PersonDelete"));
            }
        }

        public ActionResult LoadDatabase()
        {
            try
            {
                _personService.LoadDatabase();
                return RedirectToAction("PersonList");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(new Exception("Not possible to load database. " + ex.Message), "Home", "PersonDelete"));
            }
        }
    }
}
