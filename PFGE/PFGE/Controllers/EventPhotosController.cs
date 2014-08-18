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
    public class EventPhotosController : Controller
    {
        private PFGEEntities db = new PFGEEntities();

        // GET: /EventPhotos/
        public ActionResult Index()
        {
            return View(db.EventPhotos.ToList());
        }

        // GET: /EventPhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventPhoto eventphoto = db.EventPhotos.Find(id);
            if (eventphoto == null)
            {
                return HttpNotFound();
            }
            return View(eventphoto);
        }

        // GET: /EventPhotos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EventPhotos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventPhoto eventphoto)
        {
            if (ModelState.IsValid)
            {
                db.EventPhotos.Add(eventphoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventphoto);
        }

        // GET: /EventPhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventPhoto eventphoto = db.EventPhotos.Find(id);
            if (eventphoto == null)
            {
                return HttpNotFound();
            }
            return View(eventphoto);
        }

        // POST: /EventPhotos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventPhoto eventphoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventphoto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventphoto);
        }

        // GET: /EventPhotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventPhoto eventphoto = db.EventPhotos.Find(id);
            if (eventphoto == null)
            {
                return HttpNotFound();
            }
            return View(eventphoto);
        }

        // POST: /EventPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventPhoto eventphoto = db.EventPhotos.Find(id);
            db.EventPhotos.Remove(eventphoto);
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
