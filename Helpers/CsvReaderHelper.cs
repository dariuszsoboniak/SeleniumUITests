using CsvHelper;
using SeleniumUITests.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SeleniumUITests.Helpers
{
    public class CsvReaderHelper
    {
        public static List<Steps> ReadStepsFromCsv(string testName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportpath = projectDirectory + "//TestSteps";

            using (var reader = new StreamReader(reportpath + $"//{testName}.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Steps>().ToList();
            }
        }
    }
}
