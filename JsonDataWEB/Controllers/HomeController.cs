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
            var obj = _personService.GetByID(id);
            return View(obj);
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
            var obj = _personService.Insert(model);
            return RedirectToAction("PersonList");
        }

        public ActionResult PersonEdit(int id)
        {
            var obj = _personService.GetByID(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult PersonEdit(PersonModel model)
        {
            model.Tags = model.TagsString.Split(',').ToList();
            var obj = _personService.Update(model);
            return RedirectToAction("PersonList");
        }

        public RedirectToRouteResult PersonDelete(int id)
        {
            _personService.Delete(id);
            return RedirectToAction("PersonList");
        }

        [HttpPost]
        public RedirectToRouteResult PersonDelete(PersonModel model)
        {
            _personService.Delete(model.Id);
            return RedirectToAction("PersonList");
        }


        public RedirectToRouteResult LoadDatabase()
        {
            _personService.LoadDatabase();
            return RedirectToAction("PersonList");
        }
    }
}
