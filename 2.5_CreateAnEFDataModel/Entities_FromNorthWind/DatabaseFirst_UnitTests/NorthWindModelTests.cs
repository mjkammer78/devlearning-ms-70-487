using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using DatabaseFirst.Models;
using EntitiesCore;
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
            var category = model.Categories.SingleOrDefault(c => c.CategoryID == categoryid);

            //Assert
            Assert.IsNotNull(category);
            Assert.AreEqual(categoryid, category.CategoryID);
        }

        [DataTestMethod]
        [DataRow(1, DisplayName = "Category_1_ReturnsSingle")]
        public void GetCategoriesByIdOnObjectContext(int categoryid)
        {
            //Arrange
            var model = new NorthwindEntities();
            ObjectContext context = model.ConvertContext();

            //Act
            var categories = context.CreateObjectSet<Category>("Categories");
            var category = categories.SingleOrDefault(c => c.CategoryID == categoryid);

            //Assert
            Assert.IsNotNull(category);
            Assert.AreEqual(categoryid, category.CategoryID);
        }
    }
}
