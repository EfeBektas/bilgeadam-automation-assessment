using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace TestAutomation.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(string browser)
        {
            IWebDriver driver;

            // Şu an tek desteklenen tarayıcı Edge
            switch (browser.ToLower())
            {
                case "edge":
                default:
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--start-maximized");
                    driver = new EdgeDriver(edgeOptions);
                    break;
            }

            return driver;
        }
    }
}
