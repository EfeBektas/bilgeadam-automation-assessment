using NUnit.Framework;
using TestAutomation.Core;
using TestAutomation.Pages;

namespace TestAutomation.Tests
{
    public class UnauthorizedAccessTests : TestBase
    {
        [Test]
        public void CannotAccessProtectedPages_WithoutLogin()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");

            Assert.That(driver.Url.Contains("saucedemo.com"), "URL not correct");
            Assert.That(driver.Url.EndsWith("/"), "User should be redirected to login page");
        }

        [Test]
        public void CanAccessCheckoutComplete_AfterLoginWithoutCheckout()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login(ConfigManager.UserName, ConfigManager.Password);

            driver.Navigate().GoToUrl("https://www.saucedemo.com/checkout-complete.html");

            Assert.That(driver.Url.Contains("checkout-complete"),
                "Checkout complete page should be accessible even without completing checkout (application behavior).");
        }

    }
}
