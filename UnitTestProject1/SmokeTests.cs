using Core.Utils;
using NUnit.Framework;
using SeleniumCore;

namespace WebTests
{
    [TestFixture]
    public class SmokeTests : Base
    {
        private readonly int NR_OF_RESULTS = 10;

        [Test]
        public void CanSearchForNET()
        {
            ExtentManager.AssignTestCategory("Smoke Tests", "Regression");
            Google.GoTo();
            Google.Search(".NET");
            Google.VerifyResultsCount(NR_OF_RESULTS);
        }

        [Test]
        public void CanSearchForJava()
        {
            ExtentManager.AssignTestCategory("Smoke Tests", "Regression");
            Google.GoTo();
            Google.Search("java");
            Google.VerifyResultsCount(NR_OF_RESULTS);
        }
    }
}
