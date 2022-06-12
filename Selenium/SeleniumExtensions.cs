using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumUITests.Selenium
{
    public static class SeleniumExtensions
    {
        public static bool IsDisplayed(this IWebElement contex)
        {
            return contex.Displayed;
        }
    }
}
