using System;
using System.Linq;
using DatabaseFirst.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseFirst_UnitTests
{
    [TestClass]
    public class NorthWindModelTests
    {
        [DataTestMethod]
        [DataRow(1, DisplayName = "Category_1_ReturnsSingle")]
        public void GetCategoriesById(int categoryid)
        {
            //Arrange
            var model = new NorthwindEntities();

            //Act
            var category = model.Categories.Single(c => c.CategoryID == categoryid);

            //Assert
            Assert.IsNotNull(category);
            Assert.AreEqual(categoryid, category.CategoryID);
        }
    }
}
