using OpenQA.Selenium;

namespace DemoWebShopAutomation.Pages
{
    public class RegisterPage : BasePage
    {
        private readonly By genderMale = By.Id("gender-male");
        private readonly By firstName = By.Id("FirstName");
        private readonly By lastName = By.Id("LastName");
        private readonly By email = By.Id("Email");
        private readonly By password = By.Id("Password");
        private readonly By confirmPassword = By.Id("ConfirmPassword");
        private readonly By registerButton = By.Id("register-button");
        private readonly By resultMessage = By.ClassName("result");

        public RegisterPage(IWebDriver driver) : base(driver) { }

        public RegisterPage SelectMale() { Click(genderMale); return this; }
        public RegisterPage EnterFirstName(string name) { SendKeys(firstName, name); return this; }
        public RegisterPage EnterLastName(string name) { SendKeys(lastName, name); return this; }
        public RegisterPage EnterEmail(string mail) { SendKeys(email, mail); return this; }
        public RegisterPage EnterPassword(string pass) { SendKeys(password, pass); return this; }
        public RegisterPage ConfirmPassword(string pass) { SendKeys(confirmPassword, pass); return this; }
        public void ClickRegister() => Click(registerButton);

        public string GetResultMessage() => GetText(resultMessage);
    }
}