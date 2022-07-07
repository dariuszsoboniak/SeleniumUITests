using SeleniumUITests.Mapper.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUITests.Mapper
{
    public class TestDataSource
    {
        public Dictionary<string, Dictionary<string, UserSource>> Users { get; set; }
        public Dictionary<string, Dictionary<string, PostSource>> Posts { get; set; }
    }
}
