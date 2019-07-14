using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PFGE.Models;
using System.IO;

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
            Response.Cookies.Add(new HttpCookie("place", place.PlaceId.ToString()));

            return RedirectToAction("AddImages");
        }

        public ActionResult ViewPlaces()
        {
            PFGEEntities db = new PFGEEntities();
            var list = from lst in db.Places select lst;
            return View(list);
        }

        public ActionResult AddImages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            int placeId = 0;

            placeId = Convert.ToInt32(Request.Cookies["place"].Value.ToString());

            string directory = base.Server.MapPath("~/Uploadings/" + placeId.ToString());
                       
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            //we process it distinct ways based on a browser
            //find more info here http://stackoverflow.com/questions/4884920/mvc3-valums-ajax-file-upload
            Stream stream = null;
            var fileName = "";
            var contentType = "";
            if (String.IsNullOrEmpty(Request["qqfile"]))
            {
                // IE
                HttpPostedFileBase httpPostedFile = Request.Files[0];
                if (httpPostedFile == null)
                    throw new ArgumentException("No file uploaded");
                stream = httpPostedFile.InputStream;
                fileName = Path.GetFileName(httpPostedFile.FileName);
                contentType = httpPostedFile.ContentType;
            }
            else
            {
                //Webkit, Mozilla
                stream = Request.InputStream;
                fileName = Request["qqfile"];
            }

            ////int shoppingCartItemID = 0;

            ////shoppingCartItemID = int.Parse(Request.QueryString["shoppingCartItemID"].ToString());

            var fileBinary = new byte[stream.Length];
            stream.Read(fileBinary, 0, fileBinary.Length);

            var fileExtension = Path.GetExtension(fileName);
            if (!String.IsNullOrEmpty(fileExtension))
                fileExtension = fileExtension.ToLowerInvariant();

            string filePath = directory + fileName;

            System.IO.File.WriteAllBytes(filePath, fileBinary);

            ////(new ShoppingCartFilesServices()).Insert(shoppingCartItemID, fileName, filePath, DateTime.Now.ToString("dd-MMM-yyyy"), "");

            //int fileMaxSize = _catalogSettings.FileUploadMaximumSizeBytes;
            //if (fileBinary.Length > fileMaxSize)
            //{
            //    //when returning JSON the mime-type must be set to text/plain
            //    //otherwise some browsers will pop-up a "Save As" dialog.
            //    return Json(new
            //    {
            //        success = false,
            //        message = string.Format(_localizationService.GetResource("ShoppingCart.MaximumUploadedFileSize"), (int)(fileMaxSize / 1024)),
            //        downloadGuid = Guid.Empty,
            //    }, "text/plain");
            //}

            //var download = new Download()
            //{
            //    DownloadGuid = Guid.NewGuid(),
            //    UseDownloadUrl = false,
            //    DownloadUrl = "",
            //    DownloadBinary = fileBinary,
            //    ContentType = contentType,
            //    //we store filename without extension for downloads
            //    Filename = Path.GetFileNameWithoutExtension(fileName),
            //    Extension = fileExtension,
            //    IsNew = true
            //};
            //_downloadService.InsertDownload(download);

            PFGEEntities db = new PFGEEntities();
            PlacePhoto placePhoto = new PlacePhoto();
            placePhoto.PlaceId = placeId;
            placePhoto.PhotoName = fileName;
            //placePhoto.PhotoDescription = "";
            db.PlacePhotos.Add(placePhoto);
            db.SaveChanges();

            //when returning JSON the mime-type must be set to text/plain
            //otherwise some browsers will pop-up a "Save As" dialog.
            return Json(new
            {
                success = true,
                message = "uploaded sussessfully",
                downloadGuid = Guid.NewGuid(),
            }, "text/plain");
        }

        //public ActionResult ShoppingCartFiles(int id)
        //{
        //    var shoppingCartFiles = (new ShoppingCartFilesServices()).SelectByShoppingCartItemID(id);
        //    return View(shoppingCartFiles);
        //}

        //public JsonResult DeletePrintFile(int id)
        //{
        //    var shoppingCartFiles = (new ShoppingCartFilesServices()).SelectByFileID(id);
        //    string path = shoppingCartFiles.FirstOrDefault().FilePath;
        //    if (System.IO.File.Exists(path))
        //    {
        //        System.IO.File.Delete(path);
        //    }
        //    (new ShoppingCartFilesServices()).Delete(id);
        //    return Json(new { success = true }, "text/html");
        //    //return View(shoppingCartFiles);
        //}
	}
}