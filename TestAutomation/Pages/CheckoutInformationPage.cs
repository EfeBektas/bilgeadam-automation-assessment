using OpenQA.Selenium;
using TestAutomation.Core;

namespace TestAutomation.Pages
{
    public class CheckoutInformationPage : BasePage
    {
        public CheckoutInformationPage(IWebDriver driver) : base(driver) { }

        private By FirstNameField => By.Id("first-name");
        private By LastNameField => By.Id("last-name");
        private By PostalCodeField => By.Id("postal-code");
        private By ContinueButton => By.Id("continue");

        public void EnterFirstName(string firstName)
        {
            Wait.UntilVisible(FirstNameField).SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            Wait.UntilVisible(LastNameField).SendKeys(lastName);
        }

        public void EnterPostalCode(string postalCode)
        {
            Wait.UntilVisible(PostalCodeField).SendKeys(postalCode);
        }

        public void Continue()
        {
            Wait.UntilClickable(ContinueButton).Click();
        }

        public void FillFormAndContinue(string first, string last, string zip)
        {
            EnterFirstName(first);
            EnterLastName(last);
            EnterPostalCode(zip);
            Continue();
        }
    }
}
