using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZoolandiaRazor.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        //[Route(“/Animal/Detail/{id}”)]
        public ActionResult Index()
        {
            ViewBag.Message = "Let's look at some animals, yo!";
            //ViewBag.Animal = id;

            return View();
        }


        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
