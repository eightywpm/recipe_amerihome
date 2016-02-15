using System;
using System.Collections;
using recipe_amerihome.Interfaces;
using recipe_amerihome.Enumerations;
using recipe_amerihome.Utility;


namespace recipe_amerihome.Ingredients
{
    public static class CalcRecipeCosts 
    {
        #region Public Functions
        /// <summary>
        /// This calculates the cost based on the Units and UnitCost properties.  Both must exist and be valid for this result to be valid.
        /// </summary>
        /// <returns>Total base cost, does not include sales tax or discounts.</returns>
        public static double CalculateCost(System.Collections.Generic.IList<IRecipeItem> items)
        {
            var total = 0.0;
            foreach (var item in items)
            {
                total = total + item.Units * item.UnitCost;
            }

            return total;
        }

        /// <summary>
        /// This calculates the sales tax based on Units and UnitCost properties.  Both must exist and be valid for this result ot be valid.
        /// </summary>
        /// <param name="salestaxPercent">The decimal representation of the sales tax, eg: 5% would be 0.05</param>
        /// <param name="salesTaxRoundTo">The cents multiple to round the tax up to, eg: 8 would mean that cents portion of total tax would be one of 0, 8, 16, 24, 32, etc.</param>
        /// <returns>The total sales tax on the recipe.</returns>
        public static double CalculateSalesTax(System.Collections.Generic.IList<IRecipeItem> items, double salesTaxPercent, int salesTaxRoundTo)
        {
            var total = CalculateCostMinusProduce(items);
            var totalTax = total * salesTaxPercent;
            var roundup_total = Utilities.RoundUp(totalTax, 2) * 100 % 100;


            if (roundup_total % salesTaxRoundTo == 0)
            {
                return totalTax;
            }
            else
            {
                // add pennies to make the cents total a multiple of 7
                totalTax = totalTax + ((salesTaxRoundTo - (roundup_total % salesTaxRoundTo)) / 100.0);
            }
            return Utilities.RoundUp(totalTax, 2);
        }

        /// <summary>
        /// This calculates the wellness discount based on Units and UnitCost properties.  Both must exist and be valid for this result ot be valid. 
        /// </summary>
        /// <param name="wellnessDiscountPercent">The decimal representation of the sales tax, eg: 7% would be 0.07</param>
        /// <returns>The total wellness discount on the recipe.</returns>
        public static double CalculateWellnessDiscount(System.Collections.Generic.IList<IRecipeItem> items, double wellnessDiscountPercent)
        {
            return Utilities.RoundUp(CalculateCostWellnessProducts(items) * wellnessDiscountPercent, 2);
        }
        #endregion

        #region Private Functions
        /// <summary>
        /// Gets the total cost of tax eligible items (not produce)
        /// </summary>
        /// <param name="items">Items in the recipe</param>
        /// <returns>Total cost of all tax eligible items in the recipe.</returns>
        private static double CalculateCostMinusProduce(System.Collections.Generic.IList<IRecipeItem> items)
        {
            var total = 0.0;
            foreach (var item in items)
            {
                if (item.IngredientType != enumIngredientType.Produce)
                {
                    total = total + item.Units * item.UnitCost;
                }
                else
                {
                    ; // do nothing - we ignore the produce cost
                }
            }
            return total;
        }

        /// <summary>
        /// Gets the total cost of all wellness discount eligible items (organic)
        /// </summary>
        /// <param name="items">Items in the recipe</param>
        /// <returns>Total cost of all wellness discount eligible items</returns>
        private static double CalculateCostWellnessProducts(System.Collections.Generic.IList<IRecipeItem> items)
        {
            var total = 0.0;
            foreach (var item in items)
            {
                if (item.IsOrganic)
                {
                    total = total + item.Units * item.UnitCost;
                }
                else
                {
                    ; // do nothing - there is only a discount for organic items.
                }
            }
            return total;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// static constructor
        /// </summary>
        static CalcRecipeCosts()
        { 
        }

        #endregion  
    }
}
