using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Data;
using PortfolioProject.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioTests
{
    [TestClass]
    public class FreelanceProjectsControllerTests
    {


        //Creating mock data 
        private ApplicationDbContext _context;
        //empty list of freelance project themes
        List<FreelanceProject> freelanceProject = new List<FreelanceProject>();
        //declare Controller being tested
        FreelanceProjectsController controller;

        
        [TestInitialize]
        public void TestInitialize()
        {
            //instantiate in memory db > similar to startup.cs
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            //create mock data in this db
            //Creating 1 category
            var category = new Category { Id = 3, Name = "Test Category" };
            _context.Categories.Add(category);
            _context.SaveChanges();
            //Creating 3 freelance projects
            freelanceProject.Add(new FreelanceProject 
            {   Id = 22, 
                FirstName = "Isadora", 
                LastName = "Santos", 
                Email = "isa@gc.com",
                PhoneNumber = 786009990, 
                Category = category, 
                Theme = "Programming Tutorial Video",
                ProjectDespription = "Edit a Programming tutorial for Begginers" });

            freelanceProject.Add(new FreelanceProject
            {
                Id = 23,
                FirstName = "Lana",
                LastName = "Santos",
                Email = "laninha@gc.com",
                PhoneNumber = 786009991,
                Category = category,
                Theme = "Funny Cats Compilation Video",
                ProjectDespription = "Edit a compilation of cat videos for youtube"});

            freelanceProject.Add(new FreelanceProject
            {
                Id = 24,
                FirstName = "Emily",
                LastName = "Mororo",
                Email = "emy@gc.com",
                PhoneNumber = 786009992,
                Category = category,
                Theme = "Marathon Contest",
                ProjectDespription = "film and edit a 10k Marathon"
            });

            foreach (var fp in freelanceProject) 
            {
                _context.FreelanceProjects.Add(fp);
            }
            _context.SaveChanges();
            //instantiate the controller class with mock db contect

            controller = new FreelanceProjectsController(_context);

        }

        //Test 1
        [TestMethod]
        public void CreateReturnResult()
        {
            //arrange
            var controller = new FreelanceProjectsController(null);
            //act
            var result = controller.Create();
            //assert
            Assert.IsNotNull(result);
        }

        //Test 2
        [TestMethod]
        public void IndexViewLoads()
        {
            //arrange
           
            //act
            var result = controller.Index();
            var viewResult = (ViewResult)result.Result;
            //assert
            Assert.AreEqual("Index", viewResult.ViewName);
        }

        //Test 3
        [TestMethod]
        public void IndexReturnsFreelanceProjectsData()
        {
            //arrange

            //act
            var result = controller.Index();
            var viewResult = (ViewResult)result.Result;
            var model = (List<FreelanceProject>)viewResult.Model;
            CollectionAssert.AreEqual(freelanceProject, model);
            //assert
            Assert.AreEqual("Index", viewResult.ViewName);
        }

        [TestMethod]
        public void GetCreateView() {
            var result = (ViewResult)controller.Create();
            Assert.AreEqual("Create", result.ViewName);

        }


    }
}
