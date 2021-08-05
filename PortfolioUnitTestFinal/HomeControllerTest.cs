using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UnitTest
{
    // So far this is a regular c# class, how do we extend it to make it a test class?
    [TestClass]
    public class HomeControllerTest
    {
        //class is set up
        [TestMethod]
        public void IndexReturnsResult()
        {
            //arrange
            var controller = new HomeControllerTest();
            //act
            var result = controller.Index();
            //assert
            Assert.IsNotNull(result);
        }


        //class is set up
        [TestMethod]
        public void PrivacyReturnsResult()
        {
            //arrange
            var controller = new HomeController();
            //act
            var result = controller.Privacy();
            //assert
            Assert.IsNotNull(result);
        }

    }
}
