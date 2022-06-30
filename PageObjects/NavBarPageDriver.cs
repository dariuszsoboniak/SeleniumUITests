using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Phlex.Core.TestInfrastructure.Selenium;
using SeleniumExtras.PageObjects;
using Shouldly;

namespace SeleniumUITests.PageObjects
{
    public class NavBarPageDriver
    {   
        public void NavigateToLoginPage()
        {
            SignInButton.Displayed.ShouldBeTrue();
            SignInButton.Enabled.ShouldBeTrue();
            SignInButton.Click();
            LoginPage.VerifyLoginPageTitleIsDisplayed();
        }

        public void NavigateToSettingPage()
        {
            SettingButton.Displayed.ShouldBeTrue();
            SettingButton.Enabled.ShouldBeTrue();
            SettingButton.Click();
            VerifySetiingsTitleIsDisplayed();
        }

        public void VerifySetiingsTitleIsDisplayed()
        {
            SettingTitle.Displayed.ShouldBeTrue();
        }

        public void WatiForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(With.TagAndAttribute("a", "href", "/settings")));
        }

        public NavBarPageDriver(IWebDriver driver)
        {
            _driver = driver;
            LoginPage = new LoginPageDriver(driver);
            PageFactory.InitElements(driver, this);
        }

        private readonly IWebDriver _driver;
        LoginPageDriver LoginPage;

        [FindsBy(How = How.LinkText, Using = "Sign in")]
        private readonly IWebElement signInButton;

        public IWebElement SignInButton => signInButton;
        public IWebElement HomeButton => _driver.FindElement(With.TagAndAttribute("li", "data-cy", "home"));
        public IWebElement NewPostButton => _driver.FindElement(With.TagAndAttribute("li", "data-cy", "new-post"));
        public IWebElement SettingButton => _driver.FindElement(With.TagAndAttribute("a", "href", "/settings"));
        public IWebElement UserButton => _driver.FindElement(With.TagAndAttribute("li", "data-cy", "profile"));
        public IWebElement SettingTitle => _driver.FindElement(With.TagAndClassAndText("h1", "text-xs-center", "Your Settings"));

        
    }
}
