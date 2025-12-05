using OpenQA.Selenium;
using TestAutomation.Core;

namespace TestAutomation.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        public CheckoutCompletePage(IWebDriver driver) : base(driver) { }

        private By SuccessMessage => By.ClassName("complete-header");

        public string GetSuccessMessage()
        {
            return Wait.UntilVisible(SuccessMessage).Text;
        }

        public bool IsOrderSuccessful()
        {
            return GetSuccessMessage().Contains("Thank you for your order");
        }
    }
}
