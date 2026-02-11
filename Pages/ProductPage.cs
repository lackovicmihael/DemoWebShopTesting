using OpenQA.Selenium;

namespace DemoWebShopAutomation.Pages
{
    public class ProductPage : BasePage
    {
        private readonly By addToCartButton = By.XPath("(//div[contains(@class,'item-box')]//input[@value='Add to cart'])[1]");

        public ProductPage(IWebDriver driver) : base(driver) { }

        public void AddFirstToCart() => Click(addToCartButton);
    }
}