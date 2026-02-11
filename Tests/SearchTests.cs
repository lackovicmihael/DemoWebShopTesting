using OpenQA.Selenium;

namespace DemoWebShopAutomation.Tests
{
    [TestFixture]
    public class SearchTests : BaseTest
    {

        [Test]
        public void SearchLaptopReturnsResults()
        {
            Home.Search("laptop");

            Assert.That(Driver.FindElements(By.CssSelector(".product-item")).Count, Is.GreaterThan(0));
        }

        [Test]
        public void SearchWithSpecialCharactersReturnsNoResults()
        {
            Home.Search("@#$%");

            Wait.Until(d => Driver.Url.Contains("/search"));

            var results = Driver.FindElements(By.CssSelector(".product-item"));
            Assert.That(results.Count, Is.EqualTo(0));
        }
    }
}