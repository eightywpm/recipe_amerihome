using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using recipe_amerihome.Enumerations;
using recipe_amerihome.Interfaces;
using recipe_amerihome.Ingredients;

namespace recipe_amerihome.Utility
{
    public static class LoadRecipesFromXML
    {
        #region Private Variables
        static XmlDocument doc;
        #endregion

        #region Public Functions
        /// <summary>
        /// Gets the set of all ingredients in the XML file
        /// </summary>
        /// <returns>An IDictionary with the key being the name of the ingredient and the value being the IRecipeItem representing the ingredient.</returns>
        public static IDictionary<string, IRecipeItem> GetIngredientsList()
        {

            var ingredients = new Dictionary<string, IRecipeItem>();
            // produce items
            XmlNodeList nodeList = doc.SelectNodes("/root/ingredients/Produce/ingredient");
            var ingredientType = enumIngredientType.Produce;
            foreach (XmlNode node in nodeList)
            {
                var name = node.Attributes["name"].Value.ToString();
                var unitType = node.Attributes["unitType"].Value.ToString();
                var isOrganic = Convert.ToBoolean(node.Attributes["organic"].Value);
                var unitCost = Convert.ToDouble(node.Attributes["unitCost"].Value);
                var produceItem = facIngredientItem.GetItemOfType(ingredientType, name, unitType, isOrganic, unitCost);
                ingredients.Add(name, produceItem);
            }

            // meatpoultry items
            nodeList = doc.SelectNodes("/root/ingredients/MeatPoultry/ingredient");
            ingredientType = enumIngredientType.MeatPoultry;
            foreach (XmlNode node in nodeList)
            {
                var name = node.Attributes["name"].Value.ToString();
                var unitType = node.Attributes["unitType"].Value.ToString();
                var isOrganic = Convert.ToBoolean(node.Attributes["organic"].Value);
                var unitCost = Convert.ToDouble(node.Attributes["unitCost"].Value);
                var produceItem = facIngredientItem.GetItemOfType(ingredientType, name, unitType, isOrganic, unitCost);
                ingredients.Add(name, produceItem);
            }

            // pantry items
            nodeList = doc.SelectNodes("/root/ingredients/Pantry/ingredient");
            ingredientType = enumIngredientType.Pantry;
            foreach (XmlNode node in nodeList)
            {
                var name = node.Attributes["name"].Value.ToString();
                var unitType = node.Attributes["unitType"].Value.ToString();
                var isOrganic = Convert.ToBoolean(node.Attributes["organic"].Value);
                var unitCost = Convert.ToDouble(node.Attributes["unitCost"].Value);
                var produceItem = facIngredientItem.GetItemOfType(ingredientType, name, unitType, isOrganic, unitCost);
                ingredients.Add(name, produceItem);
            }
            return ingredients;
        }

        /// <summary>
        /// Gets the set of all recipes
        /// </summary>
        /// <returns>An IDictionary of key: recipename, value: IDictionary of key: Ingredient Name, value: Numunits in recipe.</returns>
        public static IDictionary<string, IDictionary<string, double>> GetRecipes()
        {
            var recipes = new Dictionary<string, IDictionary<string, double>>();
            XmlNodeList nodeList = doc.SelectNodes("/root/recipes/recipe");
            var x = nodeList.Count;
            foreach (XmlNode node in nodeList)
            {
                var recipeIngredients = new Dictionary<string, double>();
                foreach (XmlNode childNode in node.ChildNodes)
                { 
                    // these are ingredient name/unit pairs
                    var name = childNode.Attributes["name"].Value.ToString();
                    var units = childNode.Attributes["units"].Value.ToString();
                    recipeIngredients.Add(name, Utilities.Convert(units));
                }
                var recipeName = node.Attributes["name"].Value.ToString();
                recipes.Add(recipeName, recipeIngredients);
            }

            return recipes;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// static constructor, loads the XML document
        /// </summary>
        static LoadRecipesFromXML()
        {
            try
            {
                doc = new XmlDocument();
                doc.Load(@"..\..\Utility\Input.xml");
            }
            catch (Exception e)
            {
                var exmsg = e.Message;
                throw;
            }
        }
        #endregion
    }
}
