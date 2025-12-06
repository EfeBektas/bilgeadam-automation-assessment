using NUnit.Framework;
using System.Globalization;
using TestAutomation.Core;
using TestAutomation.Pages;
using TestAutomation.TestData;
using TestAutomation.Utils;


namespace TestAutomation.Tests
{
    public class DataDrivenCartTests : TestBase
    {
        [Test]
        public void AddMultipleProducts_FromJson()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login(ConfigManager.UserName, ConfigManager.Password);

            var products = DataReader.ReadJson<Product>("TestData/products.json");

            var inventoryPage = new InventoryPage(driver);

            foreach (var p in products)
            {
                inventoryPage.AddProductToCart(p.id);
            }

            inventoryPage.GoToCart();

            var cartPage = new CartPage(driver);

            var names = cartPage.GetCartItemNames();

            var cartPrices = cartPage.GetCartItemPrices()
                .Select(p => decimal.Parse(p.Replace("$", ""), CultureInfo.InvariantCulture))
                .ToList();

            foreach (var p in products)
            {
                Assert.That(names.Contains(p.name), $"Cart does not contain product: {p.name}");

                var expectedPrice = decimal.Parse(
                    p.price.ToString(),
                    CultureInfo.GetCultureInfo("tr-TR")
                );

                Assert.That(cartPrices.Contains(expectedPrice),
                    $"Cart does not contain price: {expectedPrice}");
            }
            var quantities = cartPage.GetCartItemQuantities();

            Assert.That(quantities.All(q => q == 1), "One or more items have incorrect quantity.");

            Assert.That(quantities.Count == products.Count,
                "Number of quantities does not match number of products.");


        }
    }
}
