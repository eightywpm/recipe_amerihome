using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recipe_amerihome.Utility;

namespace utRecipe
{
    [TestClass]
    public class utUtility
    {
        [TestMethod]
        public void TestFractionDoubleConversion()
        {
            var input = "1 3/4";
            var result = Utilities.Convert(input);
            Assert.IsTrue(result == 1.75);
            input = "1";
            result = Utilities.Convert(input);
            Assert.IsTrue(result == 1);
            input = "1 3/4 /5";
            try
            {
                result = Utilities.Convert(input);
                Assert.IsTrue(false);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("valid fraction"))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                    Assert.IsTrue(false);
                }
            }
        }

        [TestMethod]
        public void TestRoundUp()
        {
            var input = 81.123;
            var result = Utilities.RoundUp(input, 2);
            Assert.IsTrue(result == 81.13);
            result = Utilities.RoundUp(input, 1);
            Assert.IsTrue(result == 81.2);
            result = Utilities.RoundUp(input, 3);
            Assert.IsTrue(result == 81.123);
            input = 81.120;
            result = Utilities.RoundUp(input, 2);
            Assert.IsTrue(result == 81.12);
        }
    }
}
