using System;
using recipe_amerihome.Interfaces;
using recipe_amerihome.Enumerations;

namespace recipe_amerihome.Ingredients
{
    public static class facIngredientItem
    {

        #region Public Functions
        /// <summary>
        /// Returns an instance of a recipe item based on the type passed in, uses default constructor
        /// </summary>
        /// <param name="ingredientType">Type of Ingredient you want to instanciate.</param>
        /// <returns>Instance of the item requested with properties left at default value</returns>
        public static IRecipeItem GetItemOfType(enumIngredientType ingredientType)
        {
            switch (ingredientType)
            {
                case enumIngredientType.Pantry:
                    {
                        return new PantryItem();
                    }
                case enumIngredientType.Produce:
                    {
                        return new ProduceItem();
                    }
                case enumIngredientType.MeatPoultry:
                    {
                        return new MeatPoultryItem();
                    }
                default:
                    {
                        throw new Exception("Unknown Ingredient type detected: " + ingredientType.ToString());
                    }
            }
        }

        /// <summary>
        /// Returns an instance of a recipe item based on the type passed in, uses initializing constructor without number of units
        /// </summary>
        /// <param name="ingredientType">Type of ingredient you want to instanciate.</param>
        /// <param name="productName">Name of the ingredient.</param>
        /// <param name="unitName">Name of the units of measurement for the ingredient.</param>
        /// <param name="isOrganic">True if this item is organic, false otherwise.</param>
        /// <param name="unitCost">Cost per unit of this item.</param>
        /// <returns>Instance of the item requested with properties initialized.</returns>
        public static IRecipeItem GetItemOfType(enumIngredientType ingredientType, string productName, string unitName, bool isOrganic, double unitCost)
        {
            switch (ingredientType)
            {
                case enumIngredientType.Pantry:
                    {
                        return new PantryItem(productName, unitName, isOrganic, unitCost);
                    } 
                case enumIngredientType.Produce:
                    {
                        return new ProduceItem(productName, unitName, isOrganic, unitCost);
                    } 
                case enumIngredientType.MeatPoultry:
                    {
                        return new MeatPoultryItem(productName, unitName, isOrganic, unitCost);
                    } 
                default:
                    {
                        throw new Exception("Unknown Ingredient type detected: " + ingredientType.ToString());
                    }
            }
        }

        /// <summary>
        /// Returns an instance of a recipe item based on the type passed in, uses initializing constructor
        /// </summary>
        /// <param name="ingredientType">Type of ingredient you want to instanciate.</param>
        /// <param name="productName">Name of the ingredient.</param>
        /// <param name="unitName">Name of the units of measurement for the ingredient.</param>
        /// <param name="isOrganic">True if this item is organic, false otherwise.</param>
        /// <param name="unitCost">Cost per unit of this item.</param>
        /// <param name="units">Number of units of this ingredient in the recipe.</param>
        /// <returns>Instance of the item requested with properties initialized.</returns>
        public static IRecipeItem GetItemOfType(enumIngredientType ingredientType, string productName, string unitName, bool isOrganic, double unitCost, double units)
        {
            switch (ingredientType)
            {
                case enumIngredientType.Pantry:
                    {
                        return new PantryItem(productName, unitName, isOrganic, unitCost, units);
                    } 
                case enumIngredientType.Produce:
                    {
                        return new ProduceItem(productName, unitName, isOrganic, unitCost, units);
                    } 
                case enumIngredientType.MeatPoultry:
                    {
                        return new MeatPoultryItem(productName, unitName, isOrganic, unitCost, units);
                    } 
                default:
                    {
                        throw new Exception("Unknown Ingredient type detected: " + ingredientType.ToString());
                    }
            }
        }

        /// <summary>
        /// Deep copy with units
        /// </summary>
        /// <param name="item">The IRecipeItem to copy</param>
        /// <param name="units">The number of units of the item in the recipe</param>
        /// <returns>A deep copy of the item with its Units property updated.</returns>
        public static IRecipeItem GetItemOfType(IRecipeItem item, double units)
        {
            switch (item.IngredientType)
            {
                case enumIngredientType.Pantry:
                    {
                        return new PantryItem(item.Name, item.UnitName, item.IsOrganic, item.UnitCost, units);
                    }
                case enumIngredientType.Produce:
                    {
                        return new ProduceItem(item.Name, item.UnitName, item.IsOrganic, item.UnitCost, units);
                    }
                case enumIngredientType.MeatPoultry:
                    {
                        return new MeatPoultryItem(item.Name, item.UnitName, item.IsOrganic, item.UnitCost, units);
                    }
                default:
                    {
                        throw new Exception("Unknown Ingredient type detected: " + item.IngredientType.ToString());
                    }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// static constructor
        /// </summary>
        static facIngredientItem()
        {

        }
        #endregion

    }
}
