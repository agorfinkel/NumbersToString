using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersToString.Resources;

namespace NumbersToString.Test
{
    [TestClass]
    public class NumbersToStringTest : BaseTest
    {
        [TestMethod]
        public void ConvertToString()
        {

            var numbersToStringManager = new Resources.NumbersToString();
            var response = numbersToStringManager.Convert(testNumber3);

            Assert.IsNotNull(response);

        }
    }
}
