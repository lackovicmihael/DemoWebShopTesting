using DemoWebShopAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DemoWebShopAutomation.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected HomePage Home;

        protected WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(20));

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            Home = new HomePage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}