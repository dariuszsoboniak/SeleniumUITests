using SeleniumUITests.Models;
using System.Collections.Generic;

namespace SeleniumUITests.Mapper
{
    public class TestData
    {
        public Dictionary<string, Dictionary<string, User>> Users { get; set; }
        public Dictionary<string, Dictionary<string, Post>> Posts { get; set; }
    }
}
