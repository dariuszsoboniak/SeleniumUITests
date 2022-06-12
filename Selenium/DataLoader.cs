using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SeleniumUITests.Selenium
{
    public static class DataLoader
    {
        public static IConfigurationRoot LoadTestData()
        {
            var testDataBuldier = new ConfigurationBuilder();
            var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData");
            testDataBuldier.SetBasePath(basePath);

            testDataBuldier.AddJsonFile("testData.json");

            return testDataBuldier.Build();
        }
    }
}
