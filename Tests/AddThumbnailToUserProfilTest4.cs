using NUnit.Framework;
using SeleniumUITests.Helpers;
using SeleniumUITests.Utilities;

namespace SeleniumUITests.Tests
{
    public class AddThumbnailToUserProfilTest4 : Base
    {
        [Test]
        public void AddThumbnailToUserProfilTest_4()
        {
            var test = CsvReaderHelper.ReadStepsFromCsv("AddThumbnailToUserProfilTest_4");

            //Step 1
            NavBarPage.NavigateToLoginPage();
            LoginPage.LogIn(User);
            AddReportStep(test[0]);

            //Step 2
            NavBarPage.NavigateToUserPage();
            AddReportStep(test[1]);

            //Step 3
            UserPage.ClickOnEditProfileSettingButton();
            AddReportStep(test[2]);

            //Step 4
            var pictureUrl = "https://repository-images.githubusercontent.com/446826327/d331bcef-08f6-4b67-a54b-526388ae125d";
            SettingPage.PasteUrlPicture(pictureUrl);
            AddReportStep(test[3]);

            //Step 5
            SettingPage.ClickUpdateSettingButton();
            UserFeedPage.VerifyYourFeedTabIsDisplayed();
            NavBarPage.VerifyThumbnailIsDispayed(pictureUrl);
            AddReportStep(test[4]);
        }

        [TearDown]
        public void RestorEmptyUrlField()
        {
            NavBarPage.NavigateToUserPage();
            UserPage.ClickOnEditProfileSettingButton();
            SettingPage.PasteUrlPicture("https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Question_mark_%28black%29.svg/800px-Question_mark_%28black%29.svg.png");
            SettingPage.ClickUpdateSettingButton();
        }
        
  
    }
}