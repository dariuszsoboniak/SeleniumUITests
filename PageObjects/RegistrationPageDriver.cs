using OpenQA.Selenium;
using Phlex.Core.TestInfrastructure.Selenium;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUITests.PageObjects
{
    public class RegistrationPageDriver
    {
        public void EnterUserName(string userName)
        {
            UserNameField.Displayed.ShouldBeTrue();
            UserNameField.SendKeys(userName);
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

        public void ClickSignUpButton()
        {
            SignUpButton.Displayed.ShouldBeTrue();
            SignUpButton.Click();
            UserFeedPage.VerifyYourFeedTabIsDisplayed();
        }


        public RegistrationPageDriver(IWebDriver driver)
        {
            _driver = driver;
            UserFeedPage = new UserFeedPageDriver(driver);
        }

        private readonly IWebDriver _driver;
        UserFeedPageDriver UserFeedPage;

        public IWebElement UserNameField => _driver.FindElement(With.TagAndAttribute("input", "data-cy", "username"));
        public IWebElement EmailField => _driver.FindElement(With.TagAndAttribute("input", "data-cy", "email"));
        public IWebElement PasswordField => _driver.FindElement(With.TagAndAttribute("input", "data-cy", "password"));
        public IWebElement SignUpButton => _driver.FindElement(With.TagAndText("button", "Sign up"));
    }
}
