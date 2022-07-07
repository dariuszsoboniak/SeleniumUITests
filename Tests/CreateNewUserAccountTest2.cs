using NUnit.Framework;
using SeleniumUITests.Helpers;
using SeleniumUITests.Utilities;
using System;

namespace SeleniumUITests.Tests
{
    public class CreateNewUserAccountTest2 : Base
    {
        [Test]
        public void CreateNewUserAccountTest_2()
        {
            var test = CsvReaderHelper.ReadStepsFromCsv("CreateNewUserAccountTest_2");

            //Step 1
            NavBarPage.NavigateToRegisterPage();
            AddReportStep(test[0]);

            //Step 2
            Guid g = Guid.NewGuid();
            RegistrationPage.EnterUserName($"Test_User_{g}");
            AddReportStep(test[1]);

            //Step 3
            
            RegistrationPage.EnterEmail($"{g}@gmail.com");
            AddReportStep(test[2]);

            //Step 4
            RegistrationPage.EnterPassword("haslo");
            AddReportStep(test[3]);

            //Step 5
            RegistrationPage.ClickSignUpButton();
            AddReportStep(test[4]);
        }
    }
}