using DemoWebShopAutomation.Pages;
using OpenQA.Selenium;

namespace DemoWebShopAutomation.Tests
{
    [TestFixture]
    public class CartTests : BaseTest
    {
        private const string ValidEmail = "testuserMTTPP@testmail.com";
        private const string ValidPassword = "Test123!";

        private void PerformLogin()
        {
            Home.ClickLogin()
                .EnterEmail(ValidEmail)
                .EnterPassword(ValidPassword)
                .ClickLoginButton();
        }

        private void GoToCategoryWithProducts()
        {
            Driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/books");

            Wait.Until(d =>
                d.FindElements(By.CssSelector(".product-item, .item-box")).Count > 0);
        }

        [Test]
        public void AddBookToCart()
        {
            PerformLogin();
            GoToCategoryWithProducts();

            new ProductPage(Driver).AddFirstToCart();

            Wait.Until(d => int.Parse(Home.GetCartQuantity()) > 0);

            Assert.That(int.Parse(Home.GetCartQuantity()), Is.EqualTo(1));
        }

        [Test]
        public void RemoveItemFromCart()
        {
            PerformLogin();
            GoToCategoryWithProducts();

            new ProductPage(Driver).AddFirstToCart();

            var cartPage = Home.GoToShoppingCart();

            Wait.Until(d =>
                d.FindElements(By.Name("removefromcart")).Count > 0);

            cartPage.CheckFirstRemoveCheckbox();
            cartPage.ClickUpdateCart();

            Wait.Until(d => cartPage.IsCartEmpty());

            Assert.That(cartPage.IsCartEmpty(), Is.True);
        }
    }
}
