using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumUITests.PageObjects;
using SeleniumUITests.Utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumUITests.Tests
{
    public class Tests : Base
    {
        [Test]
        public void LoginPageTest()
        {
            NavBarPage.SignInButton.Click();
            

            LoginPage.EmailField.SendKeys(User.Email);
            LoginPage.PasswordField.SendKeys(User.Password);
            LoginPage.LoginButton.Click();

            NavBarPage.SettingButton.Click();

            SettingPage.Logout();

        }
    }
}