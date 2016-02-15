using System.Configuration;
using recipe_amerihome.Interfaces;
using recipe_amerihome.Enumerations;


namespace recipe_amerihome.Ingredients
{
    /// <summary>
    /// Base class for all implementations of Ingredient Types.
    /// </summary>
    public abstract class IngredientBaseItem : IRecipeItem
    {

        #region Public Properties

        /// <summary>
        /// The name of the ingredient.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The units of measure for the ingredient.  It is assumed that the units denoted are in multiples of the UnitName.
        /// </summary>
        public string UnitName
        {
            get;
            set;
        }

        /// <summary>
        /// True if item is Organic, false otherwise.
        /// </summary>
        public bool IsOrganic
        {
            get;
            set;
        }


        /// <summary>
        /// The cost per unit of the ingredient.  The unit is referred to in the UnitName field.
        /// </summary>
        public double UnitCost
        {
            get;
            set;
        }

        /// <summary>
        /// This denotes the type of ingredient being used, the closed list of ingredient types is available in enumIngredientType.
        /// </summary>
        public enumIngredientType IngredientType
        {
            get;
            set;
        }

        /// <summary>
        /// The number of units being used for the recipe.
        /// </summary>
        public double Units
        {
            get;
            set;
        }

        #endregion



        #region Constructors
        /// <summary>
        /// This constructor sets all public properties except for "Units".  This is intended to create the object before you know how many units are being consumed by the recipe.
        /// </summary>
        /// <param name="productName">The name of the Ingredient being used.</param>
        /// <param name="unitName">The unit of measure of the Ingredient being used.  It is assumed that this is the unit of measure for UnitCost and Units properties.</param>
        /// <param name="isOrganic">True if the item is organic, false otherwise.</param>
        /// <param name="unitCost">The price per unit as denoted by the UnitName parameter.  This is used in all Calculation functions.</param>
        /// <param name="ingredientType">The type of ingredient that exists in the closed list contained in enumIngredientType</param>
        public IngredientBaseItem(string productName, string unitName, bool isOrganic, double unitCost, enumIngredientType ingredientType) 
        {
            Name = productName;
            UnitName = unitName;
            IsOrganic = isOrganic;
            
            UnitCost = unitCost;
            IngredientType = ingredientType;
        }

        /// <summary>
        /// This constructor sets all public properties.  This is intended to create the object before you know how many units are being consumed by the recipe.
        /// </summary>
        /// <param name="productName">The name of the Ingredient being used.</param>
        /// <param name="unitName">The unit of measure of the Ingredient being used.  It is assumed that this is the unit of measure for UnitCost and Units properties.</param>
        /// <param name="isOrganic">True if the item is organic, false otherwise.</param>
        /// <param name="unitCost">The price per unit as denoted by the UnitName parameter.  This is used in all Calculation functions.</param>
        /// <param name="ingredientType">The type of ingredient that exists in the closed list contained in enumIngredientType</param>
        /// <param name="units">The number of units being consumed by the recipe.</param>
        public IngredientBaseItem(string productName, string unitName, bool isOrganic, double unitCost, enumIngredientType ingredientType, double units) 
                : this(productName, unitName, isOrganic, unitCost, ingredientType)
        {
            Units = units;
        }

        /// <summary>
        /// Default constructor to create the object with no property instanciation.  
        /// </summary>
        public IngredientBaseItem()
        {

        }

        #endregion

    }
}
