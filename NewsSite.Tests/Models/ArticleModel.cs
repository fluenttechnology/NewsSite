using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsSite.Models;

namespace NewsSite.Tests.Models
{
    [TestClass]
    public class ArticleModel
    {
        [TestMethod]
        public void Instantiate()
        {
            // Arrange
            Article article = new Article() { id = "1" };

            // Assert
            Assert.IsNotNull(article);
            Assert.IsNotNull(article.id == "1");
        }
    }
}
