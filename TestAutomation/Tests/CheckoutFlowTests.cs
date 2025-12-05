using NUnit.Framework;
using System.Globalization;
using TestAutomation.Core;
using TestAutomation.Pages;

namespace TestAutomation.Tests
{
    public class CheckoutFlowTests : TestBase
    {
        [Test]
        public void FullCheckoutFlow_And_ReAddProductBehavior()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login(ConfigManager.UserName, ConfigManager.Password);

            var inventoryPage = new InventoryPage(driver);
            string productId = "add-to-cart-sauce-labs-backpack";
            string productName = "Sauce Labs Backpack";
            inventoryPage.AddProductToCart(productId);

            inventoryPage.GoToCart();
            var cartPage = new CartPage(driver);

            var cartPrices = cartPage.GetCartItemPrices()
                .Select(p => decimal.Parse(p.Replace("$", ""), CultureInfo.InvariantCulture))
                .ToList();

            decimal itemTotal = cartPrices.Sum();

            cartPage.ProceedToCheckout(); // Bu buton id="checkout"

            var infoPage = new CheckoutInformationPage(driver);
            infoPage.FillFormAndContinue("Efe", "Bektas", "34000");

            var overviewPage = new CheckoutOverviewPage(driver);

            decimal domItemTotal = overviewPage.GetItemTotal();
            decimal domTax = overviewPage.GetTax();
            decimal domTotal = overviewPage.GetTotal();

            decimal expectedTax = Math.Round(itemTotal * 0.08m, 2);
            decimal expectedTotal = itemTotal + expectedTax;

            Assert.That(domItemTotal, Is.EqualTo(itemTotal), "Item total mismatch!");
            Assert.That(domTax, Is.EqualTo(expectedTax), "Tax calculation mismatch!");
            Assert.That(domTotal, Is.EqualTo(expectedTotal), "Total calculation mismatch!");

            overviewPage.FinishCheckout();

            var completePage = new CheckoutCompletePage(driver);
            Assert.That(completePage.IsOrderSuccessful(), "Order not marked as successful!");

            driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");

            bool reAddPossible = true;
            try
            {
                inventoryPage.AddProductToCart(productId);
            }
            catch
            {
                reAddPossible = false;
            }

            Assert.That(reAddPossible, Is.True, "Re-adding product after order gave an unexpected error!");
        }
    }
}
