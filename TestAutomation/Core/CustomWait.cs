using OpenQA.Selenium;
using TestAutomation.Core.Exceptions;

namespace TestAutomation.Core
{
    public class CustomWait
    {
        private readonly IWebDriver _driver;
        private readonly int _timeoutSeconds;

        public CustomWait(IWebDriver driver)
        {
            _driver = driver;
            _timeoutSeconds = ConfigManager.ExplicitWait;
        }

        public IWebElement UntilVisible(By locator)
        {
            var endTime = DateTime.Now.AddSeconds(_timeoutSeconds);
            while (DateTime.Now < endTime)
            {
                try
                {
                    var element = _driver.FindElement(locator);
                    if (element.Displayed)
                        return element;
                }
                catch { }
                Thread.Sleep(200);
            }
            throw new WaitTimeoutException($"Element not visible after {_timeoutSeconds} seconds: {locator}");
        }

        public IWebElement UntilClickable(By locator)
        {
            var endTime = DateTime.Now.AddSeconds(_timeoutSeconds);
            while (DateTime.Now < endTime)
            {
                try
                {
                    var element = _driver.FindElement(locator);
                    if (element.Displayed && element.Enabled)
                        return element;
                }
                catch { }
                Thread.Sleep(200);
            }
            throw new WaitTimeoutException($"Element not clickable after {_timeoutSeconds} seconds: {locator}");
        }

        public bool UntilExists(By locator)
        {
            var endTime = DateTime.Now.AddSeconds(_timeoutSeconds);
            while (DateTime.Now < endTime)
            {
                try
                {
                    _driver.FindElement(locator);
                    return true;
                }
                catch { }
                Thread.Sleep(200);
            }
            throw new WaitTimeoutException($"Element not found in DOM after {_timeoutSeconds} seconds: {locator}");
        }
    }
}
