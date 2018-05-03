using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class AdoptController : Controller
    {
        private PetEntities db = new PetEntities();

        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            var pets = db.Adopt;
            return View(pets.ToList());
        }

        public ActionResult Catalogue()
        {
            var adp = db.Adopt;
            return View(adp)
;       }
    

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopt adopt = db.Adopt.Find(id);
            if (adopt == null)
            {
                return HttpNotFound();
            }
            return View(adopt);
        }

        public ActionResult Create()
        {
            //ViewBag.BreedID = new SelectList(db.Breed, "BreedID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Adopt adopt, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);

                    adopt.ImagePath = file.FileName;
                }
                db.Adopt.Add(adopt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.BreedID = new SelectList(db.Breed, "BreedID", "Name", pet.BreedID);
            return View(adopt);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopt adopt = db.Adopt.Find(id);
            if (adopt == null)
            {
                return HttpNotFound();
            }
            return View(adopt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Adopt adopt)
        {
            if (ModelState.IsValid)
            {
             
                db.Entry(adopt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adopt);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopt adopt = db.Adopt.Find(id);
            if (adopt == null)
            {
                return HttpNotFound();
            }
            return View(adopt);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adopt adopt = db.Adopt.Find(id);
            db.Adopt.Remove(adopt);
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