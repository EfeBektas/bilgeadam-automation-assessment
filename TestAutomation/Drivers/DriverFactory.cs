using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
                    var options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    driver = new ChromeDriver(options);  // Selenium Manager auto-handles driver version
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            return driver;
        }
    }
}
