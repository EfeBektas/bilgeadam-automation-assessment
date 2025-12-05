using OpenQA.Selenium;
using TestAutomation.Core;

namespace TestAutomation.Pages
{
    public class CartPage : BasePage
    {
        private By CartItemNames => By.ClassName("inventory_item_name");
        private By CartItemPrices => By.ClassName("inventory_item_price");

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public List<string> GetCartItemNames()
        {
            return Driver.FindElements(CartItemNames).Select(x => x.Text).ToList();
        }

        public List<string> GetCartItemPrices()
        {
            return Driver.FindElements(CartItemPrices).Select(x => x.Text.Replace("$", "")).ToList();
        }
    }
}
