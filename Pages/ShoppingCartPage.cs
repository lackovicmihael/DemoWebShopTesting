using OpenQA.Selenium;

namespace DemoWebShopAutomation.Pages
{
    public class ShoppingCartPage : BasePage
    {
        private readonly By updateCartButton = By.Name("updatecart");
        private readonly By emptyCartMessage = By.XPath("//*[contains(text(), 'Your Shopping Cart is empty')]");

        public ShoppingCartPage(IWebDriver driver) : base(driver) { }

        public void CheckFirstRemoveCheckbox()
        {
            var checkbox = Wait.Until(d => d.FindElement(By.CssSelector("input[name='removefromcart']:first-of-type")));
            if (!checkbox.Selected)
            {
                checkbox.Click();
            }
        }

        public void ClickUpdateCart()
        {
            Click(updateCartButton);
        }

        public bool IsCartEmpty()
        {
            return IsDisplayed(emptyCartMessage);
        }
    }
}