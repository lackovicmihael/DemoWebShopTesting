using OpenQA.Selenium;

namespace DemoWebShopAutomation.Tests
{
    [TestFixture]
    public class RegistrationTests : BaseTest
    {

        [Test]
        public void SuccessfulUserRegistration()
        {
            var registerPage = Home.ClickRegister()
                .SelectMale()
                .EnterFirstName("Test")
                .EnterLastName("User")
                .EnterEmail($"testuser{Guid.NewGuid().ToString().Substring(0, 8)}@mail.com")
                .EnterPassword("Test123!")
                .ConfirmPassword("Test123!");
            registerPage.ClickRegister();

            Assert.That(registerPage.GetResultMessage(), Does.Contain("Your registration completed"));
        }

        [Test]
        public void RegistrationWithMismatchedPasswordsShowsError()
        {
            var registerPage = Home.ClickRegister()
                .SelectMale()
                .EnterFirstName("Test")
                .EnterLastName("User")
                .EnterEmail($"testmismatch{Guid.NewGuid().ToString().Substring(0, 8)}@mail.com")
                .EnterPassword("Test123!")
                .ConfirmPassword("Kriva123!");

            registerPage.ClickRegister();

            Wait.Until(d => d.FindElement(By.CssSelector(".validation-summary-errors, .field-validation-error")).Displayed);

            var errorMessage = Driver.FindElement(By.CssSelector(".validation-summary-errors li, .field-validation-error"));
            Assert.That(errorMessage.Text,
                Does.Contain("password") | Does.Contain("mismatch") | Does.Contain("confirm"));
        }
    }
}