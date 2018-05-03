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

    public class PetsController : Controller
    {
        private PetEntities db = new PetEntities();


        public ActionResult Index()
        {
            var pets = db.Pet;
            return View(pets.ToList());
        }
        public ActionResult FoundAnimal()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pets pet = db.Pet.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            //ViewBag.BreedID = new SelectList(db.Breed, "BreedID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pets pet, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                pet.Lost = true;
                if(file!= null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);

                    pet.ImagePath = file.FileName;
                }
                db.Pet.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.BreedID = new SelectList(db.Breed, "BreedID", "Name", pet.BreedID);
            return View(pet);
        }

        [Authorize(Roles = "User")]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pets ePet = db.Pet.Find(id);
            if(ePet == null)
            {
                return HttpNotFound();
            }
            return View(ePet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pets pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         
            return View(pet);
        }

        [Authorize(Roles = "User")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pets dPet = db.Pet.Find(id);
            if(dPet == null)
            {
                return HttpNotFound();
            }
            return View(dPet);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pets dPet= db.Pet.Find(id);
            db.Pet.Remove(dPet);
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