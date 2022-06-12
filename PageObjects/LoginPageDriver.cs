using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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
