using NUnit.Framework;
using SeleniumUITests.Helpers;
using SeleniumUITests.Utilities;
using System;

namespace SeleniumUITests.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class PublishAndRemoveNewPostTest3 : Base
    {
        [Test]
        public void PublishAndRemoveNewPostTest_3()
        {
            var test = CsvReaderHelper.ReadStepsFromCsv("PublishAndRemoveNewPostTest_3");
            var post = TestData.Posts["default"]["primary"];

            //Step 1
            NavBarPage.NavigateToLoginPage();
            LoginPage.LogIn(User);
            AddReportStep(test[0]);

            //Step 2
            NavBarPage.NavigateToNewPostPage();
            AddReportStep(test[1]);

            //Step 3
            NewPostPage.PopulateNewPostFields(post);
            AddReportStep(test[2]);

            //Step 4
            NewPostPage.ClickPublishArticleButton();
            AddReportStep(test[3]);

            //Step 5
            ArticlePage.DeleteArticle();
            AddReportStep(test[4]);

            //Step 5
            NavBarPage.NavigateToSettingPage();
            SettingPage.Logout();
            AddReportStep(test[5]);
        }
    }
}