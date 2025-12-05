using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestAutomation.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(string browser)
        {
            IWebDriver driver;

            switch (browser.ToLower())
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    var options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    driver = new ChromeDriver(options);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            return driver;
        }
    }
}
