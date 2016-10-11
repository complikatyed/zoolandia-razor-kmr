using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class AnimalController : Controller
    {
        private ZooRepository repo = new ZooRepository();

        // GET: Animal
        //[Route(“/Animal/Detail/{id}”)]
        public ActionResult Index()
        {
            List<Animal> list_of_animals = repo.GetAnimals();
            ViewBag.Message = "Let's look at some animals, yo!";
            ViewBag.Animals = list_of_animals;

            return View();
        }


        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            //chosen_animal = repo.GetAnimal(int id);

            return View();
        }

    }
}
