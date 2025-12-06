using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(ConfigManager.ImplicitWait);

            driver.Navigate().GoToUrl(ConfigManager.BaseUrl);
        }


        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;

            if (status == TestStatus.Failed)
            {
                TakeScreenshot(testName);
                CaptureBrowserConsoleLogs(testName);
            }

            driver.Quit();
        }

        private void TakeScreenshot(string testName)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var folder = "Screenshots";
                Directory.CreateDirectory(folder);
                var filePath = Path.Combine(folder, $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                screenshot.SaveAsFile(filePath);
                TestContext.AddTestAttachment(filePath);
            }
            catch { }
        }

        private void CaptureBrowserConsoleLogs(string testName)
        {
            try
            {
                var logs = driver.Manage().Logs.GetLog(LogType.Browser);
                var folder = "Logs";
                Directory.CreateDirectory(folder);
                var filePath = Path.Combine(folder, $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.log");

                File.WriteAllLines(filePath, logs.Select(x => x.ToString()));
                TestContext.AddTestAttachment(filePath);
            }
            catch { }
        }
    }
}
