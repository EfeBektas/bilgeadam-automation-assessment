using OpenQA.Selenium;
using TestAutomation.Core;

namespace TestAutomation.Pages
{
    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }
        public void AddProductToCart(string productId)
        {
            var locator = By.Id(productId);
            var button = Wait.UntilClickable(locator);
            button.Click();
        }

        public void GoToCart()
        {
            var cartButton = By.ClassName("shopping_cart_link");
            Wait.UntilClickable(cartButton).Click();
        }
    }
}
