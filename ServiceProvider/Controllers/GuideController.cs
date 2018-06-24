using ServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceProvider.Controllers
{
    public class GuideController : Controller
    {
        // GET: Guid
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Guide AddGuide)
        {
            Guide.Add(AddGuide);
            return RedirectToAction("List");
        }



        public ActionResult Update(int id)
        {
            Guide guide = Guide.FindId(id);
            return View(guide);
        }
        [HttpPost]
        public ActionResult Update(int id, Guide EditGuide)
        {
            Guide.Edit(id, EditGuide);
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Guide.Delete(id);
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            List<Guide> guide = Guide.GetGuideList();
            return View(guide);
        }
    }
}