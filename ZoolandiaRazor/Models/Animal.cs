using System.ComponentModel.DataAnnotations;

namespace ZoolandiaRazor.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string ScienceName { get; set; }
        public string CommonName { get; set; }
        public int Age { get; set; }

        public int HabitatId { get; set; }

        public virtual Habitat Habitat { get; set; }

    }
}