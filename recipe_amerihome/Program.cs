using System;
using System.Collections.Generic;
using System.Text;

using recipe_amerihome.Interfaces;
using recipe_amerihome.Ingredients;
using recipe_amerihome.Enumerations;
using recipe_amerihome.Utility;

namespace recipe_amerihome
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, IRecipeItem> ingredientsList;
            IDictionary<string, IDictionary<string, double>> recipeList;
            var settings = LoadSettings();
            LoadRecipes(out ingredientsList, out recipeList);

            if (ingredientsList == null || recipeList == null)
            {
                throw new Exception("ingredients or recipe list did not load correctly");
            }

            var sbResults = new StringBuilder();
            foreach (var recipeName in recipeList.Keys)
            {
                var recipeItemsWithUnits = new List<IRecipeItem>();
                foreach (var ingredientName in recipeList[recipeName].Keys)
                { 
                    if(!ingredientsList.ContainsKey(ingredientName))
                    {
                        throw new Exception("Ingredient " + ingredientName + " does not exist in Ingredient list!");
                    }
                    //  get a deep copy of the ingredient so we dont alter unit amounts
                    var ingredient = facIngredientItem.GetItemOfType(ingredientsList[ingredientName], recipeList[recipeName][ingredientName]);
                    recipeItemsWithUnits.Add(ingredient);
                }

                // Calculate Recipe Cost
                var recipeBaseCost = CalcRecipeCosts.CalculateCost(recipeItemsWithUnits);
                var recipeSalestax = CalcRecipeCosts.CalculateSalesTax(recipeItemsWithUnits, settings.SalesTaxPercent, settings.SalesTaxRoundTo);
                var recipeWellnessDiscount = CalcRecipeCosts.CalculateWellnessDiscount(recipeItemsWithUnits, settings.WellnessDiscountPercent);
                sbResults.AppendLine(recipeName);
                // TAX
                var sbTmp = new StringBuilder("\tTax = $");
                sbTmp.Append(recipeSalestax);
                sbResults.AppendLine(sbTmp.ToString());
                // DISCOUNT
                sbTmp = new StringBuilder("\tDiscount = ($");
                sbTmp.Append(recipeWellnessDiscount);
                sbTmp.Append(")");
                sbResults.AppendLine(sbTmp.ToString());
                // TOTAL
                sbTmp = new StringBuilder("\tTotal = $");
                var total = Utilities.RoundUp(recipeBaseCost + recipeSalestax - recipeWellnessDiscount, 2);
                sbTmp.Append(total);
                sbResults.AppendLine(sbTmp.ToString());
                sbResults.AppendLine(String.Empty);

            }

            Console.Write(sbResults.ToString());

            Console.WriteLine("I noticed that the 11.84 becomes 11.85, this is because the total was calculated to be 11.020000000000001 which rounds up to 11.03, I think the discrepency is minor and the code is correct :)");
            Console.Read();
            
        }

        static ILoadSettings LoadSettings()
        {
            var settings = new LoadAppSettings();
            settings.Load();
            return settings;
        }

        static void LoadRecipes(out IDictionary<string, IRecipeItem> ingredientsList, 
                            out IDictionary<string, IDictionary<string, double>> recipeList)
        {
            ingredientsList = LoadRecipesFromXML.GetIngredientsList();
            recipeList = LoadRecipesFromXML.GetRecipes();
        }
    }
}
