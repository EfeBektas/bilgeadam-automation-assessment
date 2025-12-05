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
        public List<int> GetCartItemQuantities()
        {
            return Driver.FindElements(By.ClassName("cart_quantity"))
                         .Select(q => int.Parse(q.Text))
                         .ToList();
        }
        public void ProceedToCheckout()
        {
            var checkoutButton = By.Id("checkout");
            Wait.UntilClickable(checkoutButton).Click();
        }

    }
}
