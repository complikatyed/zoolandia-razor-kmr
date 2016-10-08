using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.Models
{
    public class Habitat
    {
        [Key]
        public int HabitatId { get; set; }
        public string HabitatName { get; set; }
        public string HabitatType { get; set; }

        public List<Animal> Animals { get; set; }
        public List<Employee> Employees { get; set; }

    }
}