using OpenQA.Selenium;
using Phlex.Core.TestInfrastructure.Selenium;
using SeleniumUITests.Models;
using Shouldly;
using System.Collections.Generic;

namespace SeleniumUITests.PageObjects
{
    public class NewPostPageDriver
    {
        public void PopulateNewPostFields(Post post)
        {
            EnterArticleTitle(post.ArticleTitle);
            EnterSubtitle(post.SubTitle);
            EnterArticle(post.Article);
            EnterTags(post.Tags);
        }

        public void EnterArticleTitle(string articleTitle)
        {
            ArticleTitleField.Displayed.ShouldBeTrue();
            ArticleTitleField.SendKeys(articleTitle);
        }

        public void EnterSubtitle(string subtitle)
        {
            SubTitleField.Displayed.ShouldBeTrue();
            SubTitleField.SendKeys(subtitle);
        }

        public void EnterArticle(string article)
        {
            ArticleField.Displayed.ShouldBeTrue();
            ArticleField.SendKeys(article);
        }

        public void EnterTags(List<string> tags)
        {
            TagsField.Displayed.ShouldBeTrue();
            string tagsString = "";

            foreach (var tag in tags)
                tagsString = tagsString + "#" + tag;
         
            TagsField.SendKeys(tagsString);
        }

        public void ClickPublishArticleButton()
        {
            PublishArticleButton.Displayed.ShouldBeTrue();
            PublishArticleButton.Click();
            VerifyArticlePageIsDisplayed();
        }

        public void VerifyArticlePageIsDisplayed()
        {
            ArticlePage.Displayed.ShouldBeTrue();
        }

        public NewPostPageDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly IWebDriver _driver;

        public IWebElement ArticleTitleField => _driver.FindElement(With.TagAndAttribute("input", "data-cy", "title"));
        public IWebElement SubTitleField => _driver.FindElement(With.TagAndAttribute("input", "data-cy", "about"));
        public IWebElement ArticleField => _driver.FindElement(With.TagAndAttribute("textarea", "data-cy", "article"));
        public IWebElement TagsField => _driver.FindElement(With.TagAndAttribute("input", "data-cy", "tags"));
        public IWebElement PublishArticleButton => _driver.FindElement(With.TagAndText("button", "Publish Article"));
        public IWebElement ArticlePage => _driver.FindElement(With.ClassName("article-page"));
    }
}
