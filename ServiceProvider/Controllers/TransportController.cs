using ServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceProvider.Controllers
{
    public class TransportController : Controller
    {
        // GET: Transport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
       [HttpPost]
       public ActionResult Create(Transport AddTransport)
        {
            Transport.Add(AddTransport);
            return RedirectToAction("List");
        }


        public ActionResult Update(int id)
        {
            Transport transport = Transport.FindId(id);
            return View(transport);
        }
        [HttpPost]
        public ActionResult Update(int id, Transport EditTransport)
        {
            Transport.Edit(id, EditTransport);
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Transport.Delete(id);
            return RedirectToAction("List");
        }


        public ActionResult List()
        {
            List<Transport> transport = Transport.GetTransportList();
            return View(transport);
        }
    }
}