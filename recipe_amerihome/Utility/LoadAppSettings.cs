using System;
using System.Configuration;
using recipe_amerihome.Interfaces;

namespace recipe_amerihome.Utility
{
    public class LoadAppSettings : ILoadSettings
    {
        #region Public Functions
        /// <summary>
        /// Function to load settings into property fields
        /// </summary>
        public void Load()
        {
            try
            { 
                var settingHolder = ConfigurationSettings.AppSettings.Get("WellnessDiscount");
                WellnessDiscountPercent = Convert.ToDouble(settingHolder);
                settingHolder = ConfigurationSettings.AppSettings.Get("SalesTax");
                SalesTaxPercent = Convert.ToDouble(settingHolder);
                settingHolder = ConfigurationSettings.AppSettings.Get("TaxRoundTo");
                SalesTaxRoundTo = Convert.ToInt32(settingHolder);
            }
            catch (Exception)
            { 
                // future logging
                throw;
            }

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Sales tax setting, applies to everything but produce
        /// </summary>
        public double SalesTaxPercent { get; set; }
        
        /// <summary>
        /// Discount percent for organic items
        /// </summary>
        public double WellnessDiscountPercent { get; set; }

        /// <summary>
        /// Tax applied to an item must have a cents value equal to a multiple of this number.
        /// </summary>
        public int SalesTaxRoundTo { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.  This class uses the app.config to read settings.
        /// </summary>
        public LoadAppSettings()
        {
 
        }
        #endregion
    }
}
