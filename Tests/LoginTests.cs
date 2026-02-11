namespace DemoWebShopAutomation.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        private const string ValidEmail = "testuserMTTPP@testmail.com";
        private const string ValidPassword = "Test123!";
        private const string InvalidPassword = "wrongpass";

        [Test]
        public void SuccessfulLogin()
        {
            Home.ClickLogin()
                .EnterEmail(ValidEmail)
                .EnterPassword(ValidPassword)
                .ClickLoginButton();

            Assert.That(Home.IsLoggedIn(), Is.True);
        }

        [Test]
        public void FailedLoginWrongPassword()
        {
            var loginPage = Home.ClickLogin()
                .EnterEmail(ValidEmail)
                .EnterPassword(InvalidPassword);

            loginPage.ClickLoginButton();

            Assert.That(loginPage.IsErrorDisplayed(), Is.True);
            Assert.That(loginPage.GetErrorMessage(), Does.Contain("incorrect"));
        }

        [Test]
        public void SuccessfulLogout()
        {
            Home.ClickLogin()
                .EnterEmail(ValidEmail)
                .EnterPassword(ValidPassword)
                .ClickLoginButton();

            Home.ClickLogout();

            Assert.That(Home.IsLoggedOut(), Is.True);
        }

        [Test]
        public void LoginWithEmptyCredentialsShowsError()
        {
            var loginPage = Home.ClickLogin();

            loginPage.ClickLoginButton();

            Assert.That(loginPage.IsErrorDisplayed(), Is.True);

            Assert.That(loginPage.GetErrorMessage(),
                Does.Contain("No customer account found"));
        }
    }
}
