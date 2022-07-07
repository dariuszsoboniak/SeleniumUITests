using System;
using System.Threading;
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
        [SetUp]
        public void Setup()
        {
            currenTestName = TestContext.CurrentContext.Test.Name;
            SetupReport(currenTestName);
            test = extent.CreateTest(currenTestName);
            InitBrowser(browserName);

            driver.Value.Url = url;

            var testDataSource = new TestDataSource();
            DataLoader.LoadTestData().Bind(testDataSource);
            var mapper = new TestDataMapper();

            TestData = mapper.Map(testDataSource);
            User = TestData.Users["base"]["admin"];
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            LoginPage = new LoginPageDriver(driver.Value);
            NavBarPage = new NavBarPageDriver(driver.Value);
            SettingPage = new SettingPageDriver(driver.Value);
            RegistrationPage = new RegistrationPageDriver(driver.Value);
            NewPostPage = new NewPostPageDriver(driver.Value);
            ArticlePage = new ArticlePageDriver(driver.Value);
            UserPage = new UserPageDriver(driver.Value);
            UserFeedPage = new UserFeedPageDriver(driver.Value);
        }

        [TearDown]
        public void Dispose()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;


            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if(status == TestStatus.Failed)
            {
                test.Fail("Test failed", CaptureScreenShotFromPath(driver.Value, fileName));
                test.Log(Status.Fail, stackTrace);
            }

            extent.Flush();

            driver.Value.Close();
            driver.Value.Quit();
        }

        public MediaEntityModelProvider CaptureScreenShotFromPath(IWebDriver driver, string screenShotName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string reportpath = workingDirectory + $"//Reports//{currenTestName}";

            ITakesScreenshot ts = (ITakesScreenshot)driver;
            ts.GetScreenshot().SaveAsFile(reportpath+$"//{screenShotName}.png");
            return MediaEntityBuilder.CreateScreenCaptureFromPath(reportpath + $"//{screenShotName}.png", screenShotName).Build();
        }

        public void AddReportStep(Steps steps)
        {
            test.Info($"Step {steps.Step}");
            test.Info("Action: " + steps.Action);
            test.Info("Expected Result: " + steps.Result);
            test.Info("Screenshot: ", CaptureScreenShotFromPath(driver.Value, $"Step_{steps.Step}"));
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;
            }
        }

        public void SetupReport(string testName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string reportpath = workingDirectory + $"//Reports//{testName}//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportpath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Browser", browserName);
            extent.AddSystemInfo("Environment", url);
        }

        private ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        private readonly string browserName = System.Configuration.ConfigurationManager.AppSettings["browser"];
        private readonly string url = System.Configuration.ConfigurationManager.AppSettings["url"];
        private string currenTestName;
        private ExtentReports extent;
        private ExtentTest test;
        public User User;
        public TestData TestData;

        public LoginPageDriver LoginPage;
        public NavBarPageDriver NavBarPage;
        public SettingPageDriver SettingPage;
        public RegistrationPageDriver RegistrationPage;
        public NewPostPageDriver NewPostPage;
        public ArticlePageDriver ArticlePage;
        public UserPageDriver UserPage;
        public UserFeedPageDriver UserFeedPage;
    }
}
