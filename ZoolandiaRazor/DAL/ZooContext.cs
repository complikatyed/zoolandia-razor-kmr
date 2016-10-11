using ZoolandiaRazor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ZoolandiaRazor.DAL
{
    public class ZooContext : DbContext
    {
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Habitat> Habitats { get; set; }


    }
}