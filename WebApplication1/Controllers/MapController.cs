using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MapController : Controller
    {
        public ActionResult Map()
        {
            ViewData["found"] = "1801 Conquista Ave Long Beach, CA 90815" + "#" + "761 E 46th St, Long Beach, CA 90813";
            ViewData["lost"] = "3101 Pacific Coast Hwy Signal Hill, CA 90755";
            return View();
        }

    }
}