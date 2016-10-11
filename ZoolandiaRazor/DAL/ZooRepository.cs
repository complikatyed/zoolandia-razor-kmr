using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.DAL
{
    public class ZooRepository
    {
        public ZooContext Context { get; set; }

        public ZooRepository()
        {
            Context = new ZooContext();
        }

        public ZooRepository(ZooContext _context)
        {
            Context = _context;
        }

        public List<Animal> GetAnimals()
        {
            int i = 1;
            return Context.Animals.ToList();
        }

        public Animal GetAnimalById(int id)
        {
            Animal selected_animal = Context.Animals.First(a => a.AnimalId == id);
            return selected_animal;
        }

        public void AddAnimal(Animal animal)
        {
            Context.Animals.Add(animal);
            Context.SaveChanges();
        }

        public List<Habitat> GetHabitats()
        {
            int i = 1;
            return Context.Habitats.ToList();
        }


        public List<Employee> GetEmployees()
        {
            int i = 1;
            return Context.Employees.ToList();
        }
    }
}