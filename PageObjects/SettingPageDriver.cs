using OpenQA.Selenium;
using Phlex.Core.TestInfrastructure.Selenium;
using Shouldly;

namespace SeleniumUITests.PageObjects
{
    public class SettingPageDriver
    {
        public void Logout()
        {
            LogOutButton.Displayed.ShouldBeTrue();
            LogOutButton.Click();
            NavBarPage.SignInButton.Displayed.ShouldBeTrue();
        }

        public SettingPageDriver(IWebDriver driver)
        {
            _driver = driver;
            NavBarPage = new NavBarPageDriver(driver);
        }

        private readonly IWebDriver _driver;
        protected NavBarPageDriver NavBarPage;

        public IWebElement LogOutButton => _driver.FindElement(With.TagAndAttribute("button", "data-cy", "logout"));
        public IWebElement SettingTitle => _driver.FindElement(With.TagAndClassAndText("h1", "text-xs-center", "Your Settings"));
    }
}
