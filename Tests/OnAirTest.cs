using NUnit.Framework;
using NinjaPlus.Common;

namespace NinjaPlus.Tests
{
    public class OnAirTest : BaseTest
    {
        [Test]
        [Category("Smoke")]
        public void ShouldHaveTitle()
        {
            Browser.Visit("/login");
            Assert.AreEqual("Ninja+", Browser.Title);
        }

    }

}