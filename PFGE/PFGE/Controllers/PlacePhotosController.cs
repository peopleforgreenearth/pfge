using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PFGE.Models;

namespace PFGE.Controllers
{
    public class PlacePhotosController : Controller
    {
        private PFGEEntities db = new PFGEEntities();

        // GET: /PlacePhotos/
        public ActionResult Index()
        {
            return View(db.PlacePhotos.ToList());
        }

        // GET: /PlacePhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacePhoto placephoto = db.PlacePhotos.Find(id);
            if (placephoto == null)
            {
                return HttpNotFound();
            }
            return View(placephoto);
        }

        // GET: /PlacePhotos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PlacePhotos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PlacePhotoId,PlaceId,PhotoName,PhotoDescription")] PlacePhoto placephoto)
        {
            if (ModelState.IsValid)
            {
                db.PlacePhotos.Add(placephoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(placephoto);
        }

        // GET: /PlacePhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacePhoto placephoto = db.PlacePhotos.Find(id);
            if (placephoto == null)
            {
                return HttpNotFound();
            }
            return View(placephoto);
        }

        // POST: /PlacePhotos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlacePhotoId,PlaceId,PhotoName,PhotoDescription")] PlacePhoto placephoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placephoto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(placephoto);
        }

        // GET: /PlacePhotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacePhoto placephoto = db.PlacePhotos.Find(id);
            if (placephoto == null)
            {
                return HttpNotFound();
            }
            return View(placephoto);
        }

        // POST: /PlacePhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlacePhoto placephoto = db.PlacePhotos.Find(id);
            db.PlacePhotos.Remove(placephoto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
