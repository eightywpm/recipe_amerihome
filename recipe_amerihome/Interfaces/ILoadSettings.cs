namespace recipe_amerihome.Interfaces
{
    public interface ILoadSettings
    {
        /// <summary>
        /// Function to load settings into property fields
        /// </summary>
        void Load();
        /// <summary>
        /// Sales tax setting, applies to everything but produce
        /// </summary>
        double SalesTaxPercent{get;set;}
        /// <summary>
        /// Discount percent for organic items
        /// </summary>
        double WellnessDiscountPercent{get;set;}
        /// <summary>
        /// Tax applied to an item must have a cents value equal to a multiple of this number.
        /// </summary>
        int SalesTaxRoundTo{get;set;}
    }
}
