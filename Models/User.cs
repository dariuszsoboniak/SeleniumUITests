using System;
using System.Collections.Generic;

namespace SeleniumUITests.Models
{
    public class User
    {
        public User(
            string userName,
            string password,
            string email)
        {
            UserName = userName;
            Password = password;
            Email = email;

        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class TestData
    {
        public Dictionary<string, Dictionary<string, User>> Users { get; set; }
    }

    public class UserSource
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class TestDataSource
    {
        public Dictionary<string, Dictionary<string, UserSource>> Users { get; set; }
    }

    public class TestDataMapper
    {
        public TestData Map(TestDataSource source)
        {
            var result = new TestData();

            result.Users = MapDictionaryOfDicionaries(source.Users, sourceItem => MapUser(sourceItem, result));

            return result;

        }

        private static User MapUser(UserSource source, TestData testData)
        {
            return new User(source.UserName, source.Password, source.Email);
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
