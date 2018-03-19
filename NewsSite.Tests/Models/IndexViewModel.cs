using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsSite.Models;

namespace NewsSite.Tests.Models
{
    [TestClass]
    public class IndexViewModel
    {
        [TestMethod]
        public void Pager()
        {
            Pager pager = new Pager(4,2,2);

            Assert.IsNotNull(pager);
            Assert.IsNotNull(pager.TotalPages == 2);
        }

        [TestMethod]
        public void IndexViewModelTest()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            
            Assert.IsNotNull(indexViewModel);
        }
    }
}
