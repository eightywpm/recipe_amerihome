using recipe_amerihome.Interfaces;
using recipe_amerihome.Enumerations;

namespace recipe_amerihome.Ingredients
{
    /// <summary>
    /// Represents a ProduceItem ingredient in a recipe.
    /// </summary>
    public class ProduceItem : IngredientBaseItem, IRecipeItem
    {
 

        #region Constructors
        /// <summary>
        /// This constructor sets all public properties.  This is intended to create the object before you know how many units are being consumed by the recipe.
        /// </summary>
        /// <param name="productName">The name of the Ingredient being used.</param>
        /// <param name="unitName">The unit of measure of the Ingredient being used.  It is assumed that this is the unit of measure for UnitCost and Units properties.</param>
        /// <param name="isOrganic">True if the item is organic, false otherwise.</param>
        /// <param name="unitCost">The price per unit as denoted by the UnitName parameter.  This is used in all Calculation functions.</param>
        /// <param name="units">The number of units being consumed by the recipe.</param>
        public ProduceItem(string productName, string unitName, bool isOrganic, double unitCost, double units) 
            : base(productName, unitName, isOrganic, unitCost, enumIngredientType.Produce, units)
        {
            
        }

        /// <summary>
        /// This constructor sets all public properties except for "Units".  This is intended to create the object before you know how many units are being consumed by the recipe.
        /// </summary>
        /// <param name="productName">The name of the Ingredient being used.</param>
        /// <param name="unitName">The unit of measure of the Ingredient being used.  It is assumed that this is the unit of measure for UnitCost and Units properties.</param>
        /// <param name="isOrganic">True if the item is organic, false otherwise.</param>
        /// <param name="unitCost">The price per unit as denoted by the UnitName parameter.  This is used in all Calculation functions.</param>
        public ProduceItem(string productName, string unitName, bool isOrganic, double unitCost)
            : base(productName, unitName, isOrganic, unitCost, enumIngredientType.Produce)
        {

        }

        /// <summary>
        /// Default constructor to create the object with no property instanciation.  
        /// </summary>
        public ProduceItem()
        {
            IngredientType = enumIngredientType.Produce;
        }

        #endregion



    }
}
