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
{
    [TestClass]
    class TODOMIRRORTEST
    {
        [TestMethod]
        public void Create()
        {
            //Arrange
            TODO_MIRRORController Controller = new TODO_MIRRORController();

            //Act
            var Actual = Controller.Index();

            //Assert
            NUnit.Framework.Assert.IsInstanceOf<ActionResult>(Actual);
        }

    }
}