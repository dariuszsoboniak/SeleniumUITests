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
    public class UserFeedPageDriver
    {
        public void VerifyYourFeedTabIsDisplayed()
        {
            YourFeedButton.Displayed.ShouldBeTrue();
        }

        public UserFeedPageDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly IWebDriver _driver;

        public IWebElement YourFeedButton => _driver.FindElement(With.TagAndText("a", "Your Feed"));
    }
}
