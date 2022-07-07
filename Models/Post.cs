using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUITests.Models
{
    public class Post
    {
        public string ArticleTitle { get; set; }
        public string SubTitle { get; set; }
        public string Article { get; set; }
        public List<string> Tags { get; set; }

        public Post(string articleTitle, string subTitle, string article, List<string> tags)
        {
            ArticleTitle = articleTitle;
            SubTitle = subTitle;
            Article = article;
            Tags = tags;
        }

    }
}
