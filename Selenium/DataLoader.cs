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

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string testDataPath = projectDirectory + "\\TestData";
            testDataBuldier.SetBasePath(testDataPath);

            testDataBuldier.AddJsonFile("testData.json");

            return testDataBuldier.Build();
        }
    }
}
