using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioProject.Controllers;

namespace PortfolioTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexReturnResult() 
        {
            //arrange
            var controller = new HomeController(null);
            //act
            var result = controller.Index();
            //assert
            Assert.IsNotNull(result);
        }
    }
}
