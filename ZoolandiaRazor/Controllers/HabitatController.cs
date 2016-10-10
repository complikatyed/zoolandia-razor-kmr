using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class HabitatController : Controller
    {
        private ZoolandiaRepository repo = new ZoolandiaRepository();

        // GET: Habitat
        public ActionResult Index()
        {
            List<Habitat> list_of_habitats = repo.GetHabitats();

            ViewBag.Message = "Woo-hoooo!  It's habitat time!";
            ViewBag.Habitats = list_of_habitats;
            return View();
        }

        // GET: Habitat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
