using NUnit.Framework;
using OpenQA.Selenium;
using TestAutomation.Drivers;
using TestAutomation.Core;

namespace TestAutomation.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver(ConfigManager.Browser);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigManager.ImplicitWait);
            driver.Navigate().GoToUrl(ConfigManager.BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
                driver.Quit();
        }
    }
}
