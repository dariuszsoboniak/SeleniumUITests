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
    public class UserPageDriver
    {
        public void ClickOnEditProfileSettingButton()
        {
            EditProfileSettingButton.Displayed.ShouldBeTrue();
            EditProfileSettingButton.Enabled.ShouldBeTrue();
            EditProfileSettingButton.Click();
            SettingTitle.Displayed.ShouldBeTrue();
        }


        public UserPageDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly IWebDriver _driver;

        public IWebElement EditProfileSettingButton => _driver.FindElement(With.TagAndAttribute("a", "data-cy", "edit-profile-settings"));
        public IWebElement SettingTitle => _driver.FindElement(With.TagAndClassAndText("h1", "text-xs-center", "Your Settings"));
    }
}
