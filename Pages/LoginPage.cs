using OpenQA.Selenium;

namespace DemoWebShopAutomation.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By email = By.Id("Email");
        private readonly By password = By.Id("Password");
        private readonly By loginButton = By.ClassName("login-button");
        private readonly By errorMessage = By.CssSelector(".message-error li");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage EnterEmail(string mail) { SendKeys(email, mail); return this; }
        public LoginPage EnterPassword(string pass) { SendKeys(password, pass); return this; }
        public void ClickLoginButton() => Click(loginButton);

        public bool IsErrorDisplayed() => IsDisplayed(errorMessage);
        public string GetErrorMessage() => GetText(errorMessage);
    }
}