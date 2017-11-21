using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldApi;
using HelloWorldApi.Controllers;

namespace HelloWorldApi.Tests.Controllers
{
    [TestClass]
    public class MessageControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            MessageController controller = new MessageController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Hello World", result.text);
        }
    }
}
