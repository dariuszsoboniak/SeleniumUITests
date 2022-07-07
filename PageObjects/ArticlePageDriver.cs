using OpenQA.Selenium;
using Phlex.Core.TestInfrastructure.Selenium;
using Shouldly;

namespace SeleniumUITests.PageObjects
{
    public  class ArticlePageDriver
    {
        public void DeleteArticle()
        {
            DeleteArticleButton.Displayed.ShouldBeTrue();
            DeleteArticleButton.Click();
            UserFeed.VerifyYourFeedTabIsDisplayed();
        }
       
        public ArticlePageDriver(IWebDriver driver)
        {
            _driver = driver;
            UserFeed = new UserFeedPageDriver(driver);
        }

        private readonly IWebDriver _driver;
        private readonly UserFeedPageDriver UserFeed;

        public IWebElement DeleteArticleButton => _driver.FindElement(With.TagAndAttribute("button", "data-cy", "delete-article"));
    }
}
