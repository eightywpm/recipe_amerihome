using System;
using System.Text.RegularExpressions;

namespace recipe_amerihome.Utility
{
    public static class Utilities
    {
        #region Public Functions
        /// <summary>
        /// Convert a fraction into a ouble
        /// </summary>
        /// <param name="input">The fraction represented as a string</param>
        /// <returns>A double on successful conversion, otherwise 0.0</returns>
        public static double Convert(string input)
        {

            double result;

            if (double.TryParse(input, out result))
            {
                return result;
            }

            string[] split = input.Split(new char[] { ' ', '/' });

            if (split.Length == 2 || split.Length == 3)
            {
                int a, b;

                if (int.TryParse(split[0], out a) && int.TryParse(split[1], out b))
                {
                    if (split.Length == 2)
                    {
                        return (double)a / b;
                    }

                    int c;

                    if (int.TryParse(split[2], out c))
                    {
                        return a + (double)b / c;
                    }
                }
            }

            throw new FormatException("Not a valid fraction.");

        }


        public static double RoundUp(double input, int places)
        {
            double multiplier = Math.Pow(10, System.Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }

        #endregion

        #region Constructors
        static Utilities()
        {

        }
        #endregion
    }
}
