using OpenQA.Selenium;

namespace DemoWebShopAutomation.Pages
{
    public class HomePage : BasePage
    {
        private readonly By loginLink = By.ClassName("ico-login");
        private readonly By registerLink = By.ClassName("ico-register");
        private readonly By logoutLink = By.ClassName("ico-logout");
        private readonly By searchBox = By.Id("small-searchterms");
        private readonly By searchButton = By.CssSelector("input.search-box-button");
        private readonly By cartQty = By.CssSelector(".cart-qty");
        private readonly By shoppingCartLink = By.LinkText("Shopping cart");

        public HomePage(IWebDriver driver) : base(driver) { }

        public LoginPage ClickLogin()
        {
            Click(loginLink);
            return new LoginPage(Driver);
        }

        public RegisterPage ClickRegister()
        {
            Click(registerLink);
            return new RegisterPage(Driver);
        }

        public void ClickLogout()
        {
            Click(logoutLink);
        }

        public void Search(string term)
        {
            SendKeys(searchBox, term);
            Click(searchButton);
        }

        public bool IsLoggedIn() => IsDisplayed(logoutLink);

        public bool IsLoggedOut() => IsDisplayed(loginLink);

        public string GetCartQuantity()
            => GetText(cartQty).Replace("(", "").Replace(")", "");

        public ShoppingCartPage GoToShoppingCart()
        {
            Click(shoppingCartLink);
            return new ShoppingCartPage(Driver);
        }
    }
}
