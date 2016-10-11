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


    }

}
