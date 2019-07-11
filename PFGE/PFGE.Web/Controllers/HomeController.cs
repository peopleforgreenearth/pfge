using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PFGE.Web.Models;
using PFGE.Service;
using PFGE.Core;

namespace PFGE.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IPlaceService _placeService;
        public HomeController(
            IPlaceService placeService
            )
        {
            this._placeService = placeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            PFGE.Core.Domain.Place place = new Core.Domain.Place();

            place.Address = "test";
            place.Heading = "test heading";
            place.City = "test";
            place.Latitude  = 0;
            place.Longitude = 1;
            //place.PlaceId = 10;
            _placeService.AddPlace(place);

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
