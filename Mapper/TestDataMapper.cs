using SeleniumUITests.Mapper.Source;
using SeleniumUITests.Models;
using System;
using System.Collections.Generic;

namespace SeleniumUITests.Mapper
{
    public class TestDataMapper
    {
        public TestData Map(TestDataSource source)
        {
            var result = new TestData();

            result.Users = MapDictionaryOfDicionaries(source.Users, sourceItem => MapUser(sourceItem, result));
            result.Posts = MapDictionaryOfDicionaries(source.Posts, sourceItem => MapPost(sourceItem, result));

            return result;
        }

        private static User MapUser(UserSource source, TestData testData)
        {
            return new User(source.UserName, source.Password, source.Email);
        }

        private static Post MapPost(PostSource source, TestData testData)
        {
            return new Post(source.ArticleTitle, source.SubTitle, source.Article, source.Tags);
        }

        private static Dictionary<string, Dictionary<string, TTarget>> MapDictionaryOfDicionaries<TSource, TTarget>(Dictionary<string, Dictionary<string, TSource>> source, Func<TSource, TTarget> mappingFunc)
        {
            var result = new Dictionary<string, Dictionary<string, TTarget>>();

            foreach (var sourceGroupPair in source)
            {
                var resultGroup = new Dictionary<string, TTarget>();
                foreach (var sourcePair in sourceGroupPair.Value)
                {
                    var resultObj = mappingFunc(sourcePair.Value);
                    resultGroup.Add(sourcePair.Key, resultObj);
                }

                result.Add(sourceGroupPair.Key, resultGroup);
            }

            return result;
        }
    }
}
