using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemoWebShopAutomation.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; }
        protected WebDriverWait Wait { get; }

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        protected void Click(By locator) =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();

        protected void SendKeys(By locator, string text)
        {
            var element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By locator) =>
            Wait.Until(ExpectedConditions.ElementIsVisible(locator)).Text;

        protected bool IsDisplayed(By locator)
        {
            try { return Wait.Until(ExpectedConditions.ElementIsVisible(locator)).Displayed; }
            catch { return false; }
        }
    }
}