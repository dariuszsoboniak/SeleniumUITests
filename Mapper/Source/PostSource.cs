using System.Collections.Generic;

namespace SeleniumUITests.Mapper.Source
{
    public  class PostSource
    {
        public string ArticleTitle { get; set; }
        public string SubTitle { get; set; }
        public string Article { get; set; }
        public List<string> Tags { get; set; }
    }
}
