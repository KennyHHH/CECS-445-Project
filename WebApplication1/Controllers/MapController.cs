using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MapController : Controller
    {
        public ActionResult Map()
        {
            String found = "";
            String lost = "";
            PetEntities db = new PetEntities();
            foreach (Pets pet in db.Pet)
            {
                if(pet.Lost)
                    lost += pet.Address + "#";
                else
                    found += pet.Address + "#";
            }
            found = found.Remove(found.Length - 1);
            lost = lost.Remove(lost.Length - 1);
            ViewData["found"] = found;
            ViewData["lost"] = lost;
            return View();
        }

    }
}