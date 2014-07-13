using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PFGE.Models;

namespace PFGE.Controllers
{
    public class PlacesController : Controller
    {
        //
        // GET: /Places/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPlace()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPlace(Place place)
        {
            PFGEEntities db = new PFGEEntities();

            //Place place = new Place();

            //place.Address = "test";
            //place.City = "test";
            //place.Heading = "test";
            //place.Latitude = 0;
            //place.Longitude = 0.0;

            db.Places.Add(place);
            db.SaveChanges();
            return View();
        } 

	}
}