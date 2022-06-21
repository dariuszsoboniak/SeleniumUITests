using NUnit.Framework;
using SeleniumUITests.Utilities;

namespace SeleniumUITests.Tests
{
    public class LogInAndLogOutUserTest1 : Base
    {
        [Test]
        public void LogInAndLogOutUserTest_1()
        {
            //Step 1
            NavBarPage.NavigateToLoginPage();
            
            //Step 2
            LoginPage.EnterEmail(User.Email);

            //Step 3
            LoginPage.EnterPassword(User.Password);

            //Step 4
            LoginPage.ClickLoginButton();

            //Step 6
            NavBarPage.NavigateToSettingPage();

            //Step 7
            SettingPage.Logout();
        }
    }
}