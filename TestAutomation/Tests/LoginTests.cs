using NUnit.Framework;
using TestAutomation.Tests;
using TestAutomation.Pages;
using TestAutomation.Core;

namespace TestAutomation.Tests
{
    public class LoginTests : TestBase
    {
        [Test]
        public void ValidLogin()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login(ConfigManager.UserName, ConfigManager.Password);

            Assert.That(driver.Url.Contains("inventory"), "User did not reach inventory page after valid login");
        }

        [Test]
        public void InvalidLogin()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("wrong_user", "wrong_pass");

            var message = loginPage.GetErrorMessage();

            Assert.That(message.ToLower().Contains("epic sadface"), "Expected error message was not displayed");
        }
    }
}
