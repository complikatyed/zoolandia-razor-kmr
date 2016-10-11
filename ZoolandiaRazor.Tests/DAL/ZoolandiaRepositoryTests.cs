using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZoolandiaRazor.DAL;
using System.Collections.Generic;
using ZoolandiaRazor.Models;
using Moq;
using System.Data.Entity;
using System.Linq;


namespace ZoolandiaRazor.Tests.DAL
{
    [TestClass]
    public class ZoolandiaRepositoryTests
    {
        Mock<ZooContext> mock_context { get; set; }
        Mock<DbSet<Animal>> mock_animal_table { get; set; }
        List<Animal> animal_list { get; set; }
        ZooRepository repo { get; set; }


        public void ConnectMocksToDatastore()
        {
            var queryable_list = animal_list.AsQueryable();

            
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_animal_table.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            // Animal property returns Queryable List (Fake database table).
            mock_context.Setup(c => c.Animals).Returns(mock_animal_table.Object);

            mock_animal_table.Setup(t => t.Add(It.IsAny<Animal>())).Callback((Animal a) => animal_list.Add(a));
            mock_animal_table.Setup(t => t.Remove(It.IsAny<Animal>())).Callback((Animal a) => animal_list.Remove(a));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ZooContext>();
            mock_animal_table = new Mock<DbSet<Animal>>();
            animal_list = new List<Animal>();
            repo = new ZooRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void RepoEnsureCanCreateInstance()
        {
            ZooRepository repo = new ZooRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureRepoHasContext()
        {
            ZooRepository repo = new ZooRepository();

            ZooContext actual_context = repo.Context;

            Assert.IsInstanceOfType(actual_context, typeof(ZooContext));

        }

        [TestMethod]
        public void RepoEnsureNoAnimals()
        {
            // Confused about how this ought to be working with seeding...
            // I recognize that we don't want to be testing with 'real' data,
            // But I also don't quite understand WHY we don't want to do at least
            // *some* tests using seeded data... or are we supposed to seed with Moq?
            List<Animal> actual_animals = repo.GetAnimals();

            int expected_animals_count = 0;
            int actual_animals_count = actual_animals.Count();

            Assert.AreEqual(expected_animals_count, actual_animals_count);

        }

        [TestMethod]
        public void RepoEnsureCanAddAnimalToDatabase()
        {
            Animal first_animal = new Animal { Name = "Joe's Animal", Age = 2, CommonName = "Monkeybutt", ScienceName = "Monkeyus Glutteus", HabitatId = 1 };
        
            repo.AddAnimal(first_animal);

            int actual_animal_count = repo.GetAnimals().Count;

            int expected_animal_count = 1;

            // Assert
            Assert.AreEqual(expected_animal_count, actual_animal_count);
        }

        [TestMethod]
        public void RepoEnsureCanFindAnimalById()
        {
            Animal first_animal = new Animal { AnimalId = 1, Name = "Joe's Animal", Age = 2, CommonName = "Monkeybutt", ScienceName = "Monkeyus Glutteus", HabitatId = 1 };
            Animal second_animal = new Animal { AnimalId = 2, Name = "Steve's Animal", Age = 2, CommonName = "Software Evolutionizer", ScienceName = "Senex Magister", HabitatId = 2 };
            Animal third_animal = new Animal { AnimalId = 3, Name = "Jurnell's Animal", Age = 2, CommonName = "Tweetmaster", ScienceName = "Twitterus Imperius", HabitatId = 3 };

            repo.AddAnimal(first_animal);
            repo.AddAnimal(second_animal);
            repo.AddAnimal(third_animal);

            int animal_id = 2;
            Animal chosen_animal = repo.GetAnimalById(animal_id);
            

            string expected_animal_name = "Steve's Animal";

            string actual_animal_name = chosen_animal.Name;

            Assert.AreEqual(expected_animal_name, actual_animal_name);
        }


    }

}
