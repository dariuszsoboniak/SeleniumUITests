using NUnit.Framework;
using SeleniumUITests.Helpers;
using SeleniumUITests.Utilities;

namespace SeleniumUITests.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class LogInAndLogOutUserTest1 : Base
    {
        [Test]
        public void LogInAndLogOutUserTest_1()
        {
            var test = CsvReaderHelper.ReadStepsFromCsv("LogInAndLogOutUserTest_1");

            //Step 1
            NavBarPage.NavigateToLoginPage();
            AddReportStep(test[0]);

            //Step 2
            LoginPage.EnterEmail(User.Email);
            AddReportStep(test[1]);

            //Step 3
            LoginPage.EnterPassword(User.Password);
            AddReportStep(test[2]);

            //Step 4
            LoginPage.ClickLoginButton();
            AddReportStep(test[3]);

            //Step 5
            NavBarPage.NavigateToSettingPage();
            AddReportStep(test[4]);

            //Step 6
            SettingPage.Logout();
            AddReportStep(test[5]);
        }
    }
}