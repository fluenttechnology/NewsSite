using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsSite.Controllers;

namespace NewsSite.Tests.Controllers
{
    [TestClass]
    public class ArticleControllerTest
    {
        [TestMethod]
        public void Index()
        {   
            // Arrange
            ArticleController controller = new ArticleController();

            // Act
            ViewResult result = controller.Index("", "", "") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
