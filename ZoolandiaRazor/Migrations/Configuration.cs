namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZoolandiaRazor.DAL.ZooContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZoolandiaRazor.DAL.ZooContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Animals.AddOrUpdate(
                a => a.Name,
                new Animal { Name = "Bennie", Age = 2, CommonName = "Hammerhead Shark", ScienceName = "Sharkus HammerCranium", HabitatId = 1 },
                new Animal { Name = "Doug", Age = 4, CommonName = "Giraffe", ScienceName = "Girraficus Maximus", HabitatId = 2 },
                new Animal { Name = "Angie", Age = 132, CommonName = "Tortoise", ScienceName = "Tortoise Senex", HabitatId = 3 }
                );

            context.Habitats.AddOrUpdate(
                h => h.HabitatId,
                new Habitat { HabitatId = 1, HabitatName = "Aquarium", HabitatType = "Indoor" },
                new Habitat { HabitatId = 2, HabitatName = "Savannah", HabitatType = "Outdoor" },
                new Habitat { HabitatId = 3, HabitatName = "Forest", HabitatType = "Outdoor" }
                );

            context.Employees.AddOrUpdate(
                e => e.EmployeeName,
                new Employee { EmployeeName = "Jamie", EmployeeAge = 22 },
                new Employee { EmployeeName = "Andy", EmployeeAge = 43 },
                new Employee { EmployeeName = "Leslie", EmployeeAge = 52 }
                );
        }
    }
}
