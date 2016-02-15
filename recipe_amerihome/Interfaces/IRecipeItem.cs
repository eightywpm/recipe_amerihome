using recipe_amerihome.Enumerations;

namespace recipe_amerihome.Interfaces
{
    public interface IRecipeItem
    {
        /// <summary>
        /// The name of the ingredient.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The units of measure for the ingredient.  It is assumed that the units denoted are in multiples of the UnitName.
        /// </summary>
        string UnitName { get; set; }
        /// <summary>
        /// True if item is Organic, false otherwise.
        /// </summary>
        bool IsOrganic { get; set; }
        /// <summary>
        /// The cost per unit of the ingredient.  The unit is referred to in the UnitName field.
        /// </summary>
        double UnitCost { get; set; }
        /// <summary>
        /// The number of units being used for the recipe.
        /// </summary>
        double Units { get; set; }
        /// <summary>
        /// This denotes the type of ingredient being used, the closed list of ingredient types is available in enumIngredientType.
        /// </summary>
        enumIngredientType IngredientType { get; set; }

       
    }
}
