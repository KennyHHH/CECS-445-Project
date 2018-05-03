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
            String foundNames = "";
            String lost = "";
            String lostNames = "";
            PetEntities db = new PetEntities();
            foreach (Pets pet in db.Pet)
            {
                if (pet.Lost)
                {
                    lost += pet.Address + "#";
                    lostNames += pet.PetName + "#";
                }
                else
                {
                    found += pet.Address + "#";
                    foundNames += pet.PetName + "#";
                }
            }
            if (found.Length > 0)
                found = found.Remove(found.Length - 1);
            if (lost.Length > 0)
                lost = lost.Remove(lost.Length - 1);
            if (foundNames.Length > 0)
                foundNames = foundNames.Remove(found.Length - 1);
            if (lostNames.Length > 0)
                lostNames = lostNames.Remove(lostNames.Length - 1);
            ViewData["found"] = found;
            ViewData["lost"] = lost;
            ViewData["foundNames"] = foundNames;
            ViewData["lostNames"] = lostNames;
            return View();
        }

    }
}