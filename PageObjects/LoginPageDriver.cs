using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumUITests.Models;
using Shouldly;

namespace SeleniumUITests.PageObjects
{
    public  class LoginPageDriver
    {
        private readonly IWebDriver _driver;

        public LoginPageDriver(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LogIn(User user)
        {
            EnterEmail(user.Email);
            EnterPassword(user.Password);
            ClickLoginButton();
        }

        public void EnterEmail(string email)
        {
            EmailField.Displayed.ShouldBeTrue();
            EmailField.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            PasswordField.Displayed.ShouldBeTrue();
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Displayed.ShouldBeTrue();
            LoginButton.Click();
        }

        [FindsBy(How = How.CssSelector, Using = "[placeholder='Email']")]
        private readonly IWebElement emailField;
        [FindsBy(How = How.CssSelector, Using = "[placeholder='Password']")]
        private readonly IWebElement passwordField;
        [FindsBy(How = How.TagName, Using = "Button")]
        private readonly IWebElement logInButton;

        public IWebElement EmailField => emailField;
        public IWebElement PasswordField => passwordField;
        public IWebElement LoginButton => logInButton;
    }
}
