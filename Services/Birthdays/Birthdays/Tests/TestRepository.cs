using BirthdayService;
using BirthdayService.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using System;
using Xunit;

namespace Tests
{
    public class TestRepository
    {
        IServiceProvider serviceProvider;
        IConfiguration config;
        Configurations tstConfigs;

        public TestRepository(IConfiguration configuration)
        {
            var tstConfigs = new Configurations();
            
            configuration.Bind(config);
        }

        [Fact]
        public void TestGetAllUsers()
        {
          

        }

        [Fact]
        public void TestCreate()
        {
            var birthdayContext = new BirthdayContext(tstConfigs.MongoDB);

            var repo = new BirthdayRepository(birthdayContext);
            var before = repo.GetNextId();
            repo.Create(new Birthday { Date = System.DateTime.Now, Email = "test@nowhere.com", Name = "Test person" }).GetAwaiter().GetResult();
            var after = birthdayContext.Users.CountDocumentsAsync(new BsonDocument());
            Assert.Equal(before, after);

        }
    }
}
