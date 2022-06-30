using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumUITests.Models;
using SeleniumUITests.PageObjects;
using SeleniumUITests.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumUITests.Utilities
{
    public class Base
    {
        private IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public void SetupReport()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportpath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportpath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
        }

        [SetUp]
        public void Setup()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            var browserName = System.Configuration.ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);

            driver.Url = System.Configuration.ConfigurationManager.AppSettings["url"];

            var testDataSource = new TestDataSource();
            DataLoader.LoadTestData().Bind(testDataSource);
            var mapper = new TestDataMapper();

            TestData = mapper.Map(testDataSource);
            User = TestData.Users["base"]["admin"];
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LoginPage = new LoginPageDriver(driver);
            NavBarPage = new NavBarPageDriver(driver);
            SettingPage = new SettingPageDriver(driver);
        }

        public void InitBrowser(string browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }

        public User User;
        public TestData TestData;

        [TearDown]
        public void Dispose()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;


            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if(status == TestStatus.Failed)
            {
                test.Fail("Test failed", CaptureScreenShot(driver, fileName));
                test.Log(Status.Fail, stackTrace);
            }
            else if (status == TestStatus.Passed)
            {

            }

            extent.Flush();

            driver.Close();
            driver.Quit();
        }

        public MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenShot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, screenShotName).Build();
        }

        public LoginPageDriver LoginPage;
        public NavBarPageDriver NavBarPage;
        public SettingPageDriver SettingPage;
    }
}
