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

        private readonly IWebDriver _driver;
        private NavBarPageDriver NavBarPage;

        public SettingPageDriver(IWebDriver driver)
        {
            _driver = driver;
            NavBarPage = new NavBarPageDriver(driver);
        }

        public IWebElement LogOutButton => _driver.FindElement(With.TagAndAttribute("button", "data-cy", "logout"));
    }
}
