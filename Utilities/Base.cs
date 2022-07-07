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
using SeleniumUITests.Mapper;
using SeleniumUITests.Models;
using SeleniumUITests.PageObjects;
using SeleniumUITests.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumUITests.Utilities
{
    public class Base
    {
        private IWebDriver driver;
        private ExtentReports extent;
        private ExtentTest test;
        private readonly string browserName = System.Configuration.ConfigurationManager.AppSettings["browser"];
        private readonly string url = System.Configuration.ConfigurationManager.AppSettings["url"];

        [OneTimeSetUp]
        public void SetupReport()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportpath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportpath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Browser", browserName);
            extent.AddSystemInfo("Environment", url);
        }

        [SetUp]
        public void Setup()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            InitBrowser(browserName);

            driver.Url = url;

            var testDataSource = new TestDataSource();
            DataLoader.LoadTestData().Bind(testDataSource);
            var mapper = new TestDataMapper();

            TestData = mapper.Map(testDataSource);
            User = TestData.Users["base"]["admin"];
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LoginPage = new LoginPageDriver(driver);
            NavBarPage = new NavBarPageDriver(driver);
            SettingPage = new SettingPageDriver(driver);
            RegistrationPage = new RegistrationPageDriver(driver);
            NewPostPage = new NewPostPageDriver(driver);
            ArticlePage = new ArticlePageDriver(driver);
            UserPage = new UserPageDriver(driver);
            UserFeedPage = new UserFeedPageDriver(driver);
        }

        public LoginPageDriver LoginPage;
        public NavBarPageDriver NavBarPage;
        public SettingPageDriver SettingPage;
        public RegistrationPageDriver RegistrationPage;
        public NewPostPageDriver NewPostPage;
        public ArticlePageDriver ArticlePage;
        public UserPageDriver UserPage;
        public UserFeedPageDriver UserFeedPage;

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
                test.Fail("Test failed", CaptureScreenShotFromPath(driver, fileName));
                test.Log(Status.Fail, stackTrace);
            }

            extent.Flush();

            driver.Close();
            driver.Quit();
        }

        public MediaEntityModelProvider CaptureScreenShotFromPath(IWebDriver driver, string screenShotName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportpath = projectDirectory + "//Screenshots";

            ITakesScreenshot ts = (ITakesScreenshot)driver;
            ts.GetScreenshot().SaveAsFile(reportpath+$"//{TestContext.CurrentContext.Test.Name}//{screenShotName}.png");
            return MediaEntityBuilder.CreateScreenCaptureFromPath(reportpath + $"//{TestContext.CurrentContext.Test.Name}//{screenShotName}.png", screenShotName).Build();
        }

        public void AddReportStep(Steps steps)
        {
            test.Info($"Step {steps.Step}");
            test.Info("Action: " + steps.Action);
            test.Info("Expected Result: " + steps.Result);
            test.Info("Screenshot: ", CaptureScreenShotFromPath(driver, $"Step_{steps.Step}"));
        }
    }
}
