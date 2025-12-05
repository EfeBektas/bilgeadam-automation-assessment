using OpenQA.Selenium;
using TestAutomation.Core;

namespace TestAutomation.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected CustomWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new CustomWait(driver);
        }
    }
}
