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