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

        public ActionResult Create()
        {
            //ViewBag.BreedID = new SelectList(db.Breed, "BreedID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pets pet)
        {
            if (ModelState.IsValid)
            {
                db.Pet.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.BreedID = new SelectList(db.Breed, "BreedID", "Name", pet.BreedID);
            return View(pet);
        }
    }
}