using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAutomation.Core;

namespace TestAutomation.Pages
{
    public class LoginPage : BasePage
    {
        private By UsernameField => By.Id("user-name");
        private By PasswordField => By.Id("password");
        private By LoginButton => By.Id("login-button");
        private By ErrorMessage => By.CssSelector("h3[data-test='error']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterUsername(string username)
        {
            Wait.UntilVisible(UsernameField).Clear();
            Wait.UntilVisible(UsernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Wait.UntilVisible(PasswordField).Clear();
            Wait.UntilVisible(PasswordField).SendKeys(password);
        }

        public void ClickLogin()
        {
            Wait.UntilClickable(LoginButton).Click();
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }

        public string GetErrorMessage()
        {
            return Wait.UntilVisible(ErrorMessage).Text;
        }
    }
}
