using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
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

        [SetUp]
        public void Setup()
        {
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
            driver.Close();
            driver.Quit();
        }


        public LoginPageDriver LoginPage;
        public NavBarPageDriver NavBarPage;
        public SettingPageDriver SettingPage;
    }
}
