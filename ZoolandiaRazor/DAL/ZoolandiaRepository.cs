using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.DAL
{
    public class ZoolandiaRepository
    {
        public ZoolandiaContext Context { get; set; }

        public ZoolandiaRepository()
        {
            Context = new ZoolandiaContext();
        }

        public ZoolandiaRepository(ZoolandiaContext _context)
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