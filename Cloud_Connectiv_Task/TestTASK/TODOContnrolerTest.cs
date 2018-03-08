using Cloud_Connectiv_Task.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using Moq;

namespace TestTASK
{    [TestClass]
    class TODOContnrolerTest
    {
        [TestMethod]
        public void Create()
        {
            //Arrange
            TODOController Controller = new TODOController();

            //Act
            var Actual = Controller.Index();

            //Assert
            NUnit.Framework.Assert.IsInstanceOf<ActionResult>(Actual);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange  
            TODOController controller = new TODOController();

            // Act  
            ViewResult result = controller.Create() as ViewResult;

            // Assert  
            NUnit.Framework.Assert.IsNotNull(result);
        }

    }
}
