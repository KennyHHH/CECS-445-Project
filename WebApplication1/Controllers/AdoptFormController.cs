using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdoptFormController : Controller
    {

        // GET: AdoptFormForm
        private PetEntities db = new PetEntities();


        public ActionResult Index()
        {
            var pets = db.AdoptForm;
            return View(pets.ToList());
        }

        public ActionResult Catalogue()
        {
            var adp = db.AdoptForm;
            return View(adp)
;
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdoptForm AdoptForm = db.AdoptForm.Find(id);
            if (AdoptForm == null)
            {
                return HttpNotFound();
            }
            return View(AdoptForm);
        }

        public ActionResult FormSubmit()
        {
        
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormSubmit(AdoptForm AdoptForm, string petname)
        {
            if (ModelState.IsValid)
            {
                AdoptForm.PetName = petname;
                db.AdoptForm.Add(AdoptForm);
                db.SaveChanges();
                return RedirectToAction("Catalogue", "Adopt");
            }

            //ViewBag.BreedID = new SelectList(db.Breed, "BreedID", "Name", pet.BreedID);
            return View(AdoptForm);
        }
      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdoptForm AdoptForm = db.AdoptForm.Find(id);
            if (AdoptForm == null)
            {
                return HttpNotFound();
            }
            return View(AdoptForm);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdoptForm AdoptForm = db.AdoptForm.Find(id);
            db.AdoptForm.Remove(AdoptForm);
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