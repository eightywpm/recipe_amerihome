using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recipe_amerihome.Utility;

namespace integrationTestRecipe
{
    [TestClass]
    public class itRecipe
    {
        [TestMethod]
        public void itReadXML()
        {
            var settings = new LoadAppSettings();
            Assert.IsNotNull(settings);
            Assert.IsTrue(settings.SalesTaxPercent == 0);
            Assert.IsTrue(settings.SalesTaxRoundTo == 0);
            Assert.IsTrue(settings.WellnessDiscountPercent == 0);

            settings.Load();
            Assert.IsTrue(settings.SalesTaxPercent > 0);
            Assert.IsTrue(settings.SalesTaxRoundTo > 0);
            Assert.IsTrue(settings.WellnessDiscountPercent > 0);
        }


        [TestMethod]
        public void itReadConfig()
        {
            var ingredientList = LoadRecipesFromXML.GetIngredientsList();
            Assert.IsTrue(ingredientList.Count > 0);
            var recipeList = LoadRecipesFromXML.GetRecipes();
            Assert.IsTrue(recipeList.Count > 0);
        }

    }
}
