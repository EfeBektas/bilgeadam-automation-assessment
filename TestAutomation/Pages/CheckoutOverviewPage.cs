using OpenQA.Selenium;
using TestAutomation.Core;
using System.Globalization;

namespace TestAutomation.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        public CheckoutOverviewPage(IWebDriver driver) : base(driver) { }

        private By ItemTotalLabel => By.ClassName("summary_subtotal_label");
        private By TaxLabel => By.ClassName("summary_tax_label");
        private By TotalLabel => By.ClassName("summary_total_label");
        private By FinishButton => By.Id("finish");

        private decimal ExtractDecimal(string text)
        {
            // Örnek text: "Item total: $39.98"
            var priceString = text.Split('$')[1];
            return decimal.Parse(priceString, CultureInfo.InvariantCulture);
        }

        public decimal GetItemTotal()
        {
            var text = Wait.UntilVisible(ItemTotalLabel).Text;
            return ExtractDecimal(text);
        }

        public decimal GetTax()
        {
            var text = Wait.UntilVisible(TaxLabel).Text;
            return ExtractDecimal(text);
        }

        public decimal GetTotal()
        {
            var text = Wait.UntilVisible(TotalLabel).Text;
            return ExtractDecimal(text);
        }

        public void FinishCheckout()
        {
            Wait.UntilClickable(FinishButton).Click();
        }
    }
}