using ServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceProvider.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
       [HttpPost]
       public ActionResult Create(Hotel AddHotel)
        {
            Hotel.Add(AddHotel);
            return RedirectToAction("List");

        }


        public ActionResult Update(int id)
        {
            Hotel hotel = Hotel.FindId(id);
            return View(hotel);
        }
        [HttpPost]
        public ActionResult Update(int id , Hotel EditHotel)
        {
            Hotel.Edit(id, EditHotel);
            return RedirectToAction("List");
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            Hotel.Delete(id);
            return RedirectToAction("List");
        }

   
        public ActionResult List()
        {
            List<Hotel> hotel = Hotel.GetHotelList();
            return View(hotel);
        }
    }
}